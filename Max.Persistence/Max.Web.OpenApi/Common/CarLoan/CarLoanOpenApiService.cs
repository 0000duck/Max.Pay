//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Max.BUS.Message.Log;
//using Max.Common.Utils.Encrypt;
//using Max.Framework;
//using Max.Service.CarLoan;

//namespace Max.Web.OpenApi.Common.CarLoan
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class CarLoanOpenApiService : IService
//    {


//        private string textLog = "";

//        private OpenApiLogMessage logMsg;

//        private readonly CarLoanOrderService _carLoanOrderService;

//        public CarLoanOpenApiService(CarLoanOrderService carLoanOrderService)
//        {
//            _carLoanOrderService = carLoanOrderService;
//        }


//        public BaseResponse Process(HttpContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("context", "找不到应用程序上下文");
//            }

//            CarLoanFormData formData;
//            var result = GetFormData(context, out formData);

//            return null;
//        }


//        private static ServiceResult GetFormData(HttpContext context, out CarLoanFormData formData)
//        {
//            var result = new ServiceResult();
//            formData = null;

//            var requestData = context.Request.Form[CARLOAN_REQUESTDATA_KEY];
//            var checkSum = context.Request.Form[CARLOAN_CHECKSUM_KEY];

//            if (string.IsNullOrEmpty(requestData) || string.IsNullOrEmpty(checkSum))
//            {
//                return result.IsFailed("缺少必要参数");
//            }

//            var json = DecryptRequestData(requestData);

//            if (string.IsNullOrEmpty(json))
//            {
//                return result.IsFailed("无法解析报文");
//            }

//            if (!VerifyCheckSum(json, checkSum))
//            {
//                return result.IsFailed("无效调用凭证");
//            }

//            formData = json.FromJson<CarLoanFormData>();

//            if (formData == null)
//            {
//                return result.IsFailed("解析报文失败");
//            }

//            result = VerifyFormData(formData);

//            if (result.Success)
//            {
//                return result.IsSucceed();
//            }

//            formData = null;
//            return result;
//        }


//        // 非法请求
//        //public BaseResponse Process()
//        //{
//        //    if (_context == null)
//        //    {
//        //        return BaseResponse.Create(ApiEnum.ResponseCode.系统内部错误, "找不到应用程序上下文");
//        //    }

//        //    var requestData = _context.Request.Form[CARLOAN_REQUESTDATA_KEY];
//        //    var checkSum = _context.Request.Form[CARLOAN_CHECKSUM_KEY];

//        //    if (string.IsNullOrEmpty(requestData) || string.IsNullOrEmpty(checkSum))
//        //    {
//        //        return BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, "缺少必要参数");
//        //    }

//        //    var json = DecryptRequestData(requestData);

//        //    if (string.IsNullOrEmpty(json))
//        //    {
//        //        return BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, "无法解析报文");
//        //    }

//        //    if (!VerifyCheckSum(json, checkSum))
//        //    {
//        //        return BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, "无效调用凭证");
//        //    }

//        //    var formData = json.FromJson<CarLoanFormData>();

//        //    if (formData == null)
//        //    {
//        //        return BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, "解析报文失败");
//        //    }
            
//        //    var result = VerifyFormData(formData);

//        //    if (!result.Success)
//        //    {
//        //        return BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, result.Message);
//        //    }


//        //    //// 处理
//        //    return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, "");
//        //}


//        /// <summary>
//        /// 报文解密
//        /// </summary>
//        /// <param name="requestData"></param>
//        /// <returns></returns>
//        private static string DecryptRequestData(string requestData)
//        {
//            // Base64 解码
//            var data = Base64Utils.DecodeBase64String(requestData);

//            if (string.IsNullOrEmpty(data))
//            {
//                return string.Empty;
//            }

//            // DES 解密
//            var json = CryptographyUtils.DesDecrypt(data, CARLOAN_DES_SECRET_KET);

//            if (string.IsNullOrEmpty(json))
//            {
//                return string.Empty;
//            }

//            return json;
//        }

//        /// <summary>
//        /// 校验报文内容
//        /// </summary>        
//        private static ServiceResult VerifyFormData(CarLoanFormData formData)
//        {
//            var result = new ServiceResult();

//            if (formData.Head == null)
//            {
//                return result.IsFailed("报文格式不正确");
//            }
//            if (string.IsNullOrEmpty(formData.Head.RequestAt))
//            {
//                return result.IsFailed("请求时间不能为空");
//            }
//            if (string.IsNullOrEmpty(formData.Head.BizCode))
//            {
//                return result.IsFailed("业务编码不能为空");
//            }
//            if (!Enum.IsDefined(typeof (CarLoanOpenApiEnums.BizCode), formData.Head.BizCode))
//            {
//                return result.IsFailed("业务编码不存在");
//            }
//            if (string.IsNullOrEmpty(formData.Head.InstitutionNo))
//            {
//                return result.IsFailed("机构号不能为空");
//            }
//            if (formData.Head.InstitutionNo != CarLoanInstitutionNo)
//            {
//                return result.IsFailed(string.Format("机构号[{0}]不存在", formData.Head.InstitutionNo));
//            }

//            return result.IsSucceed();
//        }

//        /// <summary>
//        /// 校验 CheckSum
//        /// </summary>
//        /// <returns></returns>
//        private static bool VerifyCheckSum(string json, string checkSum)
//        {
//            return CryptographyUtils.MD5Encrypt(json) == checkSum;
//        }
//    }
//}