using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Web.Presentation.Common.LoanCommon
{
    public static class PayErrorFormat
    {
        public static string FromatError(string message)
        {
            if (message.IsNullOrWhiteSpace())
            {
                return "抱歉，交易失败，如有疑问，请咨询客服400-113-1118";
            }

            if (message.Contains("交易权限受限"))
            {
                return "抱歉，您的还款金额超过银行限额";
            }

            if (message.Contains("金额不足"))
            {
                return "抱歉，您的银行卡余额不足";
            }

            if (message.Contains("余额不足"))
            {
                return "抱歉，您的银行卡余额不足";
            }

            if (message.Contains("账户透支"))
            {
                return "抱歉，您的银行卡余额不足";
            }

            if (message.Contains("银行卡未开通认证支付"))
            {
                return "您未开通无卡支付，请先开通";
            }

            return "抱歉，交易失败，如有疑问，请咨询客服400-113-1118";
        }
    }
}