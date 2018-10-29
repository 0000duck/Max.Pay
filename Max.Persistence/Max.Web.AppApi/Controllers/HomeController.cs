using Max.Web.AppApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Max.Framework;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Web.Routing;
using System.Web;
using Max.Web.AppApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using log4net;
using Max.Framework.DAL;
using Max.Framework.ESB;
using Max.Web.AppApi.App_Start;
using Max.BUS.Message.Log;
using System.Diagnostics;
using Max.Service.Payment;
using Max.Models.Payment;

namespace Max.Web.AppApi.Controllers
{
    public class HomeController : ApiController
    {
        private static ILog log = LogManager.GetLogger(typeof(ProcessController));
        private IServiceBus bus;
        private IProcessorFactory factory;
        private MerchantService _merchantService;
        private PayProductService _payProductService;
        private MerchantPayProductService _merchantPayProductService;
        private PayChannelService _payChannelService;

        public HomeController(
            IProcessorFactory factory,
            IServiceBus bus,
             MerchantService merchantService,
             PayProductService payProductService,
             MerchantPayProductService merchantPayProductService,
             PayChannelService payChannelService
             )
        {
            this.factory = factory;
            this.bus = bus;
            this._merchantService = merchantService;
            this._payProductService = payProductService;
            this._merchantPayProductService = merchantPayProductService;
            this._payChannelService = payChannelService;
        }



        [HttpPost]
        public BaseResponse Index([FromBody] RequestPayModel model)
        {
            var watcher = new Stopwatch();
            watcher.Start();

            var response = new BaseResponse();
            BaseResponse exResponse = null;

            var requestId = string.Empty;
            var requestDataJson = string.Empty;
            var userDataJson = string.Empty;
            var userData = new UserData();
            var requestData = new RequestData();
            var logMsg = new ApiLogMessage();
            var bizCode = string.Empty;
            var urlEncodedUserData = string.Empty;
            var urlEncodedRequestData = string.Empty;
            var parmUserData = string.Empty;
            var parmRequestData = string.Empty;
            BaseRequest baseRequest = null;
            Merchant merchant = null;
            PayChannel payChannel = null;
            try
            {
               
                //验证参数
                var errMsg = "";
                if (!ModelVerify(model, out errMsg))
                {
                    response = BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, errMsg, null, 0);
                    return response;
                }
                
                //商户校验
                if (!MerchantVerify(model, merchant, payChannel, out errMsg))
                {
                    response = BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, errMsg, null, 0);
                    return response;
                }

                //验证签名
                if (!VerifySign(model, merchant))
                {
                    response = BaseResponse.Create(ApiEnum.ResponseCode.解析报文错误, "签名不正确", null, 0);
                    return response;
                }
                var processor = this.factory.Create(payChannel.MerchantInfo);
                response = processor.Process(baseRequest);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                response = BaseResponse.Create(ApiEnum.ResponseCode.系统内部错误, "不好意思，程序开小差，正在重启", 0);
                exResponse = BaseResponse.Create(ApiEnum.ResponseCode.系统内部错误, ex.ToString(), 0);
                logMsg.IsError = true;
            }
            finally
            {
                //WriteRequestInfo(userData, requestData, requestId, bizCode);

                watcher.Stop();
                var duration = watcher.Elapsed.TotalMilliseconds;

                var logStr = string.Empty;
                logStr += string.Format("【请求报文】RequestId：{0}", requestId) + Environment.NewLine;
                logStr += string.Format("UserData：{0}", urlEncodedUserData) + Environment.NewLine;
                logStr += string.Format("RequestData：{0}", urlEncodedRequestData) + Environment.NewLine;
                logStr += string.Format("【响应报文】{0}", response.ToJson());
                logStr += string.Format("【耗时】{0}毫秒", duration);
                log.Info(logStr.ToString());


                logMsg.UserDataStr = urlEncodedUserData;
                logMsg.RequestDataStr = urlEncodedRequestData;
                logMsg.RequestId = requestId;
                logMsg.LogTime = DateTime.Now;
                if (!requestData.IsNull())
                {
                    logMsg.Cmd = requestData.cmd;
                }
                if (!baseRequest.IsNull() && !baseRequest.UserData.IsNull())
                {
                    logMsg.UserData = new ApiLogUserData
                    {
                        UserId = baseRequest.UserData.UserId,
                        Mobile = baseRequest.UserData.Mobile,
                        RealName = baseRequest.UserData.RealName,
                        NickName = baseRequest.UserData.NickName,
                        IDCard = baseRequest.UserData.IDCard,
                        EPlusAccountId = baseRequest.UserData.EPlusAccountId,
                        InstitutionNo = baseRequest.UserData.InstitutionNo,
                        Usrnbr = baseRequest.UserData.Usrnbr
                    };
                }
                logMsg.RequestJson = requestDataJson;
                logMsg.Response = exResponse.IsNull() ? response.ToJson() : exResponse.ToJson();
                logMsg.Duration = duration;

                if (AppConfig.LogType == LogType.MQ)
                {
                    try
                    {
                        this.bus.Publish(logMsg);
                    }
                    catch (Exception ex)
                    {
                        log.Error("写入MQ失败，RequestId：{0}\r\n{1}".Fmt(requestData, ex.ToString()));
                    }
                }
            }

            return response;
        }

        #region
        private T GetObject<T>(string jsonStr)
        {
            var res = default(T);
            try
            {
                if (!string.IsNullOrWhiteSpace(jsonStr))
                {
                    res = jsonStr.FromJson<T>();
                }
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool ModelVerify(object model, out string msg)
        {
            msg = "";
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            var errMsg = new StringBuilder();
            if (!isValid)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    ValidationResult r = results[i];
                    errMsg.Append(r.ErrorMessage + ";");
                }
                msg = errMsg.ToString();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        private bool VerifySign(RequestPayModel model, Merchant merchant)
        {
            var t = model.GetType();
            var p = t.GetProperties();
            var fieids = p.OrderBy(c => c.Name);
            StringBuilder sb = new StringBuilder();
            foreach (var k in fieids)
            {
                string v = "";
                var obj = k.GetValue(model);
                if (!obj.IsNull())
                {
                    v = obj.ToString();
                }
                if (k.Name != "Sign" && !v.IsNullOrWhiteSpace())
                {
                    sb.AppendFormat("{0}={1}&", k.Name, v);
                }
            }

            var signStr = sb.AppendFormat("key={0}", merchant.Md5Key).ToString();
            var md5sign = signStr.EncToMD5();

            return md5sign.ToLower() == model.Sign.ToLower();
        }

        /// <summary>
        /// 验证商户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="merchant"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool MerchantVerify(RequestPayModel model, Merchant merchant, PayChannel payChannel, out string msg)
        {
            msg = "";
            merchant = this._merchantService.Get(c => c.MerchantNo == model.MerchantNo);
            if (merchant.IsNull())
            {
                msg = "商户不存在";
                return false;
            }
            if (merchant.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
            {
                msg = "商户不可用";
                return false;
            }

            //支付方式验证
            var payProduct = this._payProductService.Get(c => c.ServiceCode == model.PayType);
            if (payProduct.IsNull() || payProduct.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
            {
                msg = "支付方式{0}不可用".Fmt(model.PayType);
                return false;
            }

            //商户是否开通该支付方式
            var merchantPayProduct = this._merchantPayProductService.Get(c => c.MerchantId == merchant.MerchantId && c.ServiceId == payProduct.ServiceId);
            if (merchantPayProduct.IsNull() || merchantPayProduct.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
            {
                msg = "商户未开通该支付方式";
                return false;
            }

            //支付路由验证
            payChannel = this._payChannelService.Get(c => c.ChannelId == merchantPayProduct.PayChannelId);
            if (payChannel.IsNull() || payChannel.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
            {
                msg = "支付渠道不可用";
                return false;
            }
            return true;
        }
        #endregion
    }
}
