using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Max.Framework;

namespace Max.Web.Presentation.Common
{
    public static class CommonHelper
    {
        static Regex regx = new Regex(@"(?<=\d{4})\d+(?=\d{4})", RegexOptions.IgnoreCase);

        /// <summary>
        /// 格式化身份证号码
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public static string FormatIdCardNo(string idCardNo)
        {
            if (string.IsNullOrEmpty(idCardNo))
            {
                return string.Empty;
            }

            switch (idCardNo.Length)
            {
                case 15:
                    return idCardNo.Substring(0, 2) + "***********" + idCardNo.Substring(13);
                case 18:
                    return idCardNo.Substring(0, 2) + "**************" + idCardNo.Substring(16);
                default:
                    return idCardNo;
            }
        }

        /// <summary>
        /// 格式化姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            int length = name.Length;
            return length < 2 ? name : name.Substring(length - 1).PadLeft(length, '*');
        }

        /// <summary>
        /// 替换手机号中间4位为*号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string ReplacePhoneToStar(this string phone)
        {
            if (phone.IsNullOrEmpty())
            {
                return string.Empty;
            }
            return Regex.Replace(phone, @"(?im)(\d{3})(\d{4})(\d{4})", "$1****$3");
        }

        /// <summary>
        /// 格式化银行卡
        /// </summary>
        /// <param name="bankCark"></param>
        /// <returns></returns>
        public static string FmtBankCard(string bankCark)
        {
            if (string.IsNullOrEmpty(bankCark))
            {
                return string.Empty;
            }

            return bankCark.Length > 4 ? regx.Replace(bankCark, " **** **** ") : bankCark;
        }

        
    }
}