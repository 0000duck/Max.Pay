using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Web.OpenApi.Common.CarLoan
{
    /// <summary>
    /// 车贷接口请求消息体
    /// </summary>
    public sealed class CarLoanFormData
    {
        /// <summary>
        /// 请求消息头
        /// </summary>
        public CarLoanRequestHeader Head { get; set; }

        /// <summary>
        /// 请求消息内容
        /// </summary>
        public string Body { get; set; }
    }
}