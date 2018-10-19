using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common
{
    public class BaseResponse
    {
        public ApiEnum.ResponseCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static BaseResponse Create(ApiEnum.ResponseCode code, object data)
        {
            return Create(code, null, data);
        }

        public static BaseResponse Create(ApiEnum.ResponseCode code, string message)
        {
            return Create(code, message, null);
        }

        public static BaseResponse Create(ApiEnum.ResponseCode code, string message, object data)
        {
            return new BaseResponse
            {
                Code = code,
                Message = message,
                Data = data
            };
        }
    }
}