using log4net;
using Max.BUS.Message.Log;
using Max.Framework;
using Max.Framework.ESB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Max.Web.OpenApi.Common.CarLoan;
using Max.Web.OpenApi.Models.OpenApiModels;

namespace Max.Web.OpenApi.Controllers
{
    public class CarLoanController : ApiController
    {
        // 明文是交易请求数据，表现格式为JSON格式，其中包含Head、Body节点，放在报文中用DES加密方式以UTF-8编码、base64输出结果
        private const string CARLOAN_REQUESTDATA_KEY = "RequestData";

        // 明文交易请求数据的MD5加密字符串，用于校验RequestData是否合法
        private const string CARLOAN_CHECKSUM_KEY = "CheckSum";

        private static readonly ILog Logger = LogManager.GetLogger(typeof(CarLoanController));

        private readonly IServiceBus _bus;

        public CarLoanController(IServiceBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public CarLoanBaseResponse Index()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //var startTimestamp = Stopwatch.GetTimestamp();
            var requestData = HttpContext.Current.Request.Form[CARLOAN_REQUESTDATA_KEY];
            var checkSum = HttpContext.Current.Request.Form[CARLOAN_CHECKSUM_KEY];
            var param = string.Format("{0}={1}&{2}={3}", CARLOAN_REQUESTDATA_KEY, requestData ?? "", CARLOAN_CHECKSUM_KEY, checkSum ?? "");
            //var msg = new CarLoanOpenApiMessage
            //{
            //    Request = param,
            //    IsError = 0,
            //    RequestTime = DateTime.Now,
            //    LogType = (int)CarLoanLogTypeEnum.OpenApi
            //};

            string requestJson = null;
            CarLoanBaseResponse resp = null;
            CarLoanFormData formData = null;
            ServiceResult result = null;

            try
            {
                result = Verify(requestData, checkSum, out requestJson, out formData);
                //msg.RequestJson = requestJson;

                if (!result.Success)
                {
                    resp = new CarLoanBaseResponse
                    {
                        Code = CarLoanBaseResponse.ResponseCode.参数不正确,
                        Message = result.Message
                    };

                    if (formData != null && formData.Head != null)
                    {
                        //msg.InstitutionNo = formData.Head.InstitutionNo;
                        //msg.BizCode = formData.Head.BizCode;
                    }
                }
                else
                {
                    switch (formData.Head.BizCode)
                    {
                        case (int)CarLoanOpenApiEnums.BizCode.进件审核状态查询:
                            var orderAuditStatusRequest = formData.Body.FromJson<CarLoanOrderAuditStatusRequest>();
                            //resp = _openApiService.QueryOrderAuditStatus(orderAuditStatusRequest);
                            break;
                        case (int)CarLoanOpenApiEnums.BizCode.进件申请:
                            var createOrderRequest = formData.Body.FromJson<CarLoanCreateOrderRequest>();
                            //resp = _openApiService.UpdateOrInsertOrder(createOrderRequest);
                            break;
                        case (int)CarLoanOpenApiEnums.BizCode.进件还款信息查询:
                            var queryInstallmentListRequest = formData.Body.FromJson<CarLoanInstallmentListRequest>();
                            //resp = _openApiService.QueryInstallmentList(queryInstallmentListRequest);
                            break;
                    }

                    //msg.InstitutionNo = formData.Head.InstitutionNo;
                    //msg.BizCode = formData.Head.BizCode;
                }
            }
            catch (Exception e)
            {
                Logger.Error("【车贷OpenAPI】", e);

                //msg.IsError = 1;
                //msg.ErrorMsg = e.Message;

                resp = new CarLoanBaseResponse
                {
                    Code = CarLoanBaseResponse.ResponseCode.系统内部错误,
                    Message = "系统内部错误"
                };
            }
            finally
            {
                stopwatch.Stop();

                //var duration = stopwatch.Elapsed.TotalMilliseconds;
                //var endTimestamp = Stopwatch.GetTimestamp();

                //msg.ResponseTime = DateTime.Now;
                //msg.Response = resp.ToJson();
                //msg.Code = (int)resp.Code;
                //msg.Duration = stopwatch.Elapsed.TotalMilliseconds;

                LogInText(param, result, formData, resp);
                //LogInMongo(msg);
            }


            return resp;
        }

        //private void LogInMongo(CarLoanOpenApiMessage msg)
        //{
        //    try
        //    {
        //        _bus.Publish<ICarLoanMessage>(msg);
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.Error("【车贷OpenAPI】写入MQ失败，RequestId：{0}\r\n{1}".Fmt(msg.ToJson(), e.ToString()), e);
        //    }
        //}

        private void LogInText(string param, ServiceResult result, CarLoanFormData formData, CarLoanBaseResponse resp)
        {
            var builder = new StringBuilder();

            builder.AppendLine("【请求参数】").AppendLine(param);

            builder.AppendLine("【参数校验】");
            builder.AppendLine(result != null ? result.ToJson(true) : "校验失败，NULL");

            builder.AppendLine("【参数解密】");
            builder.AppendLine(formData != null ? formData.ToJson(true) : "报文解析失败");

            builder.AppendLine("【返回报文】");
            builder.AppendLine(resp != null ? resp.ToJson(true) : "NULL");

            Logger.Info("【车贷OpenAPI】" + builder.ToString());
        }

        private ServiceResult Verify(string requestData, string checkSum, out string requestJson, out CarLoanFormData formData)
        {
            formData = null;
            requestJson = null;

            var result = new ServiceResult();

            if (string.IsNullOrEmpty(requestData) || string.IsNullOrEmpty(checkSum))
            {
                return result.IsFailed("缺少必要参数");
            }

            try
            {
                requestJson = CarLoanOpenApiHelper.DecryptRequestData(requestData);
            }
            catch
            {
                return result.IsFailed("报文格式不正确");
            }

            if (string.IsNullOrEmpty(requestJson))
            {
                return result.IsFailed("无法解析报文");
            }

            var jObj = JObject.Parse(requestJson);

            if (jObj != null)
            {
                formData = new CarLoanFormData();

                if (jObj["Head"] != null)
                {
                    formData.Head = JsonConvert.DeserializeObject<CarLoanRequestHeader>(jObj["Head"].ToString());
                }
                if (jObj["Body"] != null)
                {
                    formData.Body = jObj["Body"].ToString(Formatting.None);
                }

                result = CarLoanOpenApiHelper.VerifyFormData(formData);

                if (result.Success)
                {
                    return !CarLoanOpenApiHelper.VerifyCheckSum(requestJson, checkSum) ? result.IsFailed("无效调用凭证") : result.IsSucceed();
                }

                return result;
            }

            return result.IsFailed("解析报文失败");

          
        }
    }
}
