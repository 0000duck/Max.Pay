using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Max.Web.Presentation.Helpers
{
    public static class DecimalExtensions
    {
        public static string CurrencyFormatter(this decimal value)
        {
            string newString  = string.Format("{0:n}", value);
            if (Regex.IsMatch(newString, @"\."))
            {
                // 去掉尾部的0
                newString = Regex.Replace(newString, @"0+$", "");
                // 防止.结尾
                newString = Regex.Replace(newString, @"\.$", "");
            }
            return newString;
        }
    }
}