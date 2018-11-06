using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Business.Response
{
    /// <summary>
    /// 支付接口返回类
    /// </summary>
    public class PayResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string Data { get; set; }

        public static PayResponse IsSuccess()
        {
            return Create(true, null, null);
        }
        public static PayResponse IsSuccess(string data)
        {
            return Create(true, null, data);
        }
        public static PayResponse IsSuccess(string message, string data)
        {
            return Create(true, message, data);
        }
        public static PayResponse IsFailed()
        {
            return Create(false, null, null);
        }
        public static PayResponse IsFailed(string message, string data = null)
        {
            return Create(false, message, data);
        }

        private static PayResponse Create(bool isSuccess, string message, string data)
        {
            return new PayResponse
            {
                Success = isSuccess,
                Message = message,
                Data = data
            };
        }
    }
}