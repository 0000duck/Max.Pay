using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common.CarLoan
{
    public class CarLoanResponse
    {
        public CarLoanOpenApiEnums.ResponseCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public static CarLoanResponse Create(CarLoanOpenApiEnums.ResponseCode code, object data)
        {
            return Create(code, null, data);
        }

        public static CarLoanResponse Create(CarLoanOpenApiEnums.ResponseCode code, string message)
        {
            return Create(code, message, null);
        }

        public static CarLoanResponse Create(CarLoanOpenApiEnums.ResponseCode code, string message, object data)
        {
            return new CarLoanResponse
            {
                Code = code,
                Message = message,
                Data = data
            };
        }
    }
}