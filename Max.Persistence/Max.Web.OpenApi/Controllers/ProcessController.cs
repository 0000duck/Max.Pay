using log4net;
using Max.BUS.Message.Log;
using Max.Framework;
using Max.Framework.ESB;
using Max.Web.OpenApi.App_Start;
using Max.Web.OpenApi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Max.Web.OpenApi.Controllers
{
    public class ProcessController : ApiController
    {
        private static ILog log = LogManager.GetLogger(typeof(ProcessController));
        private IServiceBus bus;
        private IProcessorFactory factory;

        public ProcessController(IProcessorFactory factory, IServiceBus bus)
        {
            this.factory = factory;
            this.bus = bus;
        }

        [HttpGet]
        [HttpPost]
        public BaseResponse Index()
        {
            var base64str = HttpContext.Current.Request.Params["RequestData"];
            BaseRequest request = null;
            BaseResponse response = null;
            VerifyResult verifyResult = null;
            var logMsg = new OpenApiLogMessage();
            logMsg.RequestDataStr = base64str;
            try
            {
                if (base64str.IsNullOrEmpty())
                    response = BaseResponse.Create(ApiEnum.ResponseCode.解析报文错误, "报文不能为空", null);

                verifyResult = Verify(base64str, out request);
                logMsg.RequestJson = request.ToJson();
                if (!verifyResult.IsPass)
                {
                    response = BaseResponse.Create(verifyResult.Code, verifyResult.ErrorMessage, null);
                }
                else
                {
                    var processor = this.factory.Create(request.BizCode);
                    response = processor.Process(request);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                response = BaseResponse.Create(ApiEnum.ResponseCode.系统内部错误, ex.Message, null);
            }
            finally
            {
                var logStr = new StringBuilder();
                logStr.AppendLine("【接受数据】").AppendLine(base64str);
                if (!verifyResult.IsNull())
                    logStr.AppendLine("【数据验证结果】").AppendLine(verifyResult.ToJson(true));
                if (!request.IsNull())
                    logStr.AppendLine("【数据请求明文】").AppendLine(request.ToJson(true));
                if (!response.IsNull())
                    logStr.AppendLine("【返回报文】").AppendLine(response.ToJson(true));

                log.Info(logStr.ToString());

                logMsg.Response = response.ToJson();

                if (AppConfig.LogType == LogType.MQ)
                {
                    try
                    {
                        this.bus.Publish(logMsg);
                    }
                    catch (Exception ex)
                    {
                        log.Error("写入MQ失败，RequestId：{0}\r\n{1}".Fmt(logMsg.RequestJson, ex.ToString()));
                    }
                }
            }
            return response;
        }

        #region 数据校验

        [NonAction]
        private bool Base64Verify(string requestStr, out string jsonStr, out BaseRequest baseRequest)
        {
            baseRequest = new BaseRequest();
            jsonStr = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(requestStr))
                    return false;
                jsonStr = Base64Utils.DecodeBase64String(requestStr);
                baseRequest = jsonStr.FromJson<BaseRequest>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [NonAction]
        private bool TokenVerify(BaseRequest baseRequest)
        {
            return true;
        }

        [NonAction]
        private VerifyResult ModelVerify(object model)
        {
            var verifyResult = new VerifyResult();
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
                return VerifyResult.Create(false, ApiEnum.ResponseCode.参数不正确, errMsg.ToString());
            }
            return VerifyResult.Create(true, ApiEnum.ResponseCode.处理成功);
        }

        [NonAction]
        protected VerifyResult Verify(string requestStr, out BaseRequest baseRequest)
        {
            var verifyResult = new VerifyResult { IsPass = true };

            // Base64 解码
            var jsonStr = string.Empty;
            if (!Base64Verify(requestStr, out jsonStr, out baseRequest))
            {
                return VerifyResult.Create(false, ApiEnum.ResponseCode.解析报文错误);
            }

            //机构号验证
            if (!TokenVerify(baseRequest))
            {
                return VerifyResult.Create(false, ApiEnum.ResponseCode.无效调用凭证);
            }

            try
            {
                return GetActualRequest(jsonStr, baseRequest.BizCode, out baseRequest);
            }
            catch (Exception ex)
            {
                return VerifyResult.Create(false, ApiEnum.ResponseCode.参数不正确, ex.Message);
            }
        }

        [NonAction]
        private VerifyResult GetActualRequest(string requestStr, string bizCode, out BaseRequest baseRequest)
        {
            baseRequest = ProcessorUtil.GetRequest(bizCode, requestStr);
            if (baseRequest == null)
                return VerifyResult.Create(false, ApiEnum.ResponseCode.无效交易类型);
            return ModelVerify(baseRequest);
        }

        #endregion
    }
}
