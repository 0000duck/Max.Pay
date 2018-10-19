using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Helpers
{
    public static class CommonHelper
    {
        /// <summary>
        /// 格式化身份证号码
        /// </summary>
        /// <param name="text"></param>
        /// <param name="frontLen"></param>
        /// <param name="backLen"></param>
        /// <returns></returns>
        public static string FormatString(string text, int frontLen, int backLen)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            int length = text.Length;

            if (frontLen + backLen > length)
            {
                return text;
            }

            return text.Substring(0, frontLen).PadRight(length - backLen, '*') + text.Substring(length - backLen);
        }

        /// <summary>
        /// 格式化银行卡号
        /// </summary>
        /// <param name="bankCardNo"></param>
        /// <param name="frontLen"></param>
        /// <param name="backLen"></param>
        /// <returns></returns>
        public static string FormatBankCardNo(string bankCardNo, int frontLen, int backLen)
        {
            if (string.IsNullOrEmpty(bankCardNo))
            {
                return string.Empty;
            }

            int length = bankCardNo.Length;

            if (frontLen + backLen >= length)
            {
                return bankCardNo;
            }

            return bankCardNo.Substring(0, frontLen).PadRight(length - backLen, '*') +
                   bankCardNo.Substring(length - backLen);
        }

    }
}