using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Max.Framework
{
    /// <summary>
    /// 为Management提供扩展成员
    /// <Author>MAX</Author>
    /// </summary>
    public static class ManageExtension
    {
        /// <summary>
        /// Base64加密和Url编码
        /// <Author>MAX</Author>
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string Base64Encript(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(str);
            var res = Convert.ToBase64String(bytes);
            return HttpUtility.UrlEncode(res);
        }
    }
}