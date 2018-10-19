using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Business.Response
{
    /// <summary>
    /// 支付接口返回参数
    /// </summary>
    public class Response60001
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNO { get; set; }

        /// <summary>
        /// 返回剩余的错误次数
        /// </summary>
        public int? remainingCount { get; set; }

        /// <summary>
        /// 解冻倒数时间返回剩余分钟
        /// </summary>
        public string RemainingMinutes { get; set; }

    }
}