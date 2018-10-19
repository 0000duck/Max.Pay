using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Common
{
    public class BaseResponse
    {
        public string Successed { get; set; }
        public ApiEnum.ResponseCode ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public object Body { get; set; }

        public static BaseResponse Create(object data)
        {
            return Create(ApiEnum.ResponseCode.处理成功, null, data, 1);
        }

        public static BaseResponse Create(ApiEnum.ResponseCode code, int Successed = 1)
        {
            return Create(code, null, null, Successed);
        }

        public static BaseResponse Create(ApiEnum.ResponseCode code, string message, int Successed = 1)
        {
            return Create(code, message, null, Successed);
        }

        public static BaseResponse Create(ApiEnum.ResponseCode code, object data, int Successed = 1)
        {
            return Create(code, null, data, Successed);
        }

        public static BaseResponse Create(ApiEnum.ResponseCode code, string message, object data, int Successed = 1)
        {
            return new BaseResponse
            {
                Successed = Successed.ToString(),
                ErrorCode = code,
                ErrorMsg = string.IsNullOrEmpty(message) ? code.ToString() : message,
                Body = data
            };
        }
    }


    /// <summary>
    /// 网金返回的响应
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FundBaseResponse<T> {

        public int  Code { get; set; }

        public string Message { get; set; }

        public T Body { get; set; }
    
    }
}