using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi
{
    public enum PayResult
    {
        支付失败 = 0,
        支付成功 = 1,
        处理中 = 2
    }

    public enum CallBackTradeType
    {
        现金结算状态回调 = 7,
        还款状态回调 = 8,
        刷卡支付 = 9
    }
}