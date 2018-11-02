using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Business.Response
{
    /// <summary>
    /// 支付接口返回参数
    /// </summary>
    public class Response20001
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNO { get; set; }

        public decimal Amount { get; set; }

    }
}