using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.PayApi.Business.Response
{
    /// <summary>
    /// 支付接口返回参数
    /// </summary>
    public class Response10001
    {
        /// <summary>
        /// 平台订单号
        /// </summary>
        public string OrderNO { get; set; }
        
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string MerchantOrderNO { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 支付链接
        /// </summary>
        public string PayUrl { get; set; }


        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

    }
}