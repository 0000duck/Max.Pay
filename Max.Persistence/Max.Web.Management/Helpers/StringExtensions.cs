using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Helpers
{
    public static class StringExtensions
    {
       
        public static string SubString(this Object str,int strLenth=10,string subStr="...")
        {
            if (str == null)
            {
                return "";
            }
            return str.ToString().Length > strLenth ? str.ToString().Substring(0, strLenth) + subStr : str.ToString();
        }

        public static string ToUiString(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "-";

            return input;
        }

        public static int? ToZeroIfNull(this int? value)
        {
            return value ?? 0;
        }

        public static decimal? ToZeroIfNull(this decimal? value)
        {
            return value ?? 0.00m;
        }

        public static string ToReportDate(this string value, string format = "yyyy-MM-dd")
        {
            DateTime dt;
            if (DateTime.TryParseExact(value, "yyyyMMdd",  CultureInfo.CurrentCulture, DateTimeStyles.None, out dt) )
            {
                return dt.ToString(format);
            }

            return string.Empty;
        }
    }
}