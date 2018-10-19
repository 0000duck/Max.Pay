using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Web.AppApi.Common
{
    public class VerifyResult
    {
        public ApiEnum.ResponseCode Code { get; set; }
        public bool IsPass { get; set; }
        public string ErrorMessage { get; set; }

        public static VerifyResult Create(bool isPass, ApiEnum.ResponseCode code, string errorMessage = null)
        {
            return new VerifyResult
            {
                IsPass = isPass,
                Code = code,
                ErrorMessage = errorMessage.IsNullOrEmpty() ? code.ToString() : errorMessage
            };
        }
    }
}