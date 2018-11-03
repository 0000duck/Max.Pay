using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Max.Web.PayApi.Common
{
    public static class MD5Util
    {
        /// <summary>
        /// MD5加密
        /// <Author>MAX</Author>
        /// </summary>
        /// <param name="text">待加密文本</param>
        /// <param name="capital">加密后的文本是否大写，true：大写 false：小写</param>
        /// <param name="digit">加密字符串的位数，默认：32位，否则：16位</param>
        /// <param name="encodingName">字符编码名称</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encryption(string text, bool capital = true, int digit = 32, string encodingName = "UTF-8")
        {
            var encoding = Encoding.GetEncoding(encodingName);
            using (var md5Svc = new MD5CryptoServiceProvider())
            {
                byte[] hashVals = md5Svc.ComputeHash(encoding.GetBytes(text));

                var sb = new StringBuilder(32);
                for (int i = 0; i < hashVals.Length; i++)
                {
                    if (capital)
                        sb.Append(hashVals[i].ToString("X2"));
                    else
                        sb.Append(hashVals[i].ToString("x2"));
                }

                return digit == 32 ? sb.ToString() : sb.ToString().Substring(8, 16);
            }
        }

    }
}