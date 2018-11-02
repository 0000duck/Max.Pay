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
        /// 平台订单号
        /// </summary>
        public string OrderNO { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string MerchantOrderNO { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantNo { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public int PayStatus { get; set; }

        /// <summary>
        /// 交易结果
        /// </summary>
        public string PayResult { get; set; }

    }
}