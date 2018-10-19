using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.ModelBinding;
using System.Web;

namespace Max.Web.Presentation.Helpers
{
    public class DesHelper
    {
        /**
         * 手机端回调手机号加密的key
         */
        public const string AppMobileDesSecretKey ="";


        /// <summary>
        /// DES加密
        /// <Author>周维</Author>
        /// </summary>
        /// <param name="text">字符文本</param>
        /// <param name="key">秘钥Key</param>
        /// <returns>经Url编码的密文(Base64 String)</returns>
        public static string DESEncryption(string text, string key)
        {
            var encryptText = Encoding.UTF8.GetBytes(text);
            using (var desSvc = new DESCryptoServiceProvider())
            {
                desSvc.Mode = CipherMode.CBC;
                desSvc.Padding = PaddingMode.PKCS7;
                desSvc.Key = Encoding.UTF8.GetBytes(key);
                desSvc.IV = Encoding.UTF8.GetBytes(key);
                using (var msEncrypt = new MemoryStream())
                {
                    var cryptEncrypt = new CryptoStream(msEncrypt, desSvc.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptEncrypt.Write(encryptText, 0, encryptText.Length);
                    cryptEncrypt.FlushFinalBlock();
                    cryptEncrypt.Close();
                    cryptEncrypt.Dispose();
                    var base64Str = Convert.ToBase64String(msEncrypt.ToArray());
                    return HttpUtility.UrlEncode(base64Str);
                }
            }
        }

        /// <summary>
        /// DES解密
        /// <Author>周维</Author>
        /// </summary>
        /// <param name="text">密文文本</param>
        /// <param name="key">秘钥Key</param>
        /// <returns>解密后的文本</returns>
        public static string DESDecryption(string text, string key)
        {
            var decryptText = Convert.FromBase64String(text);
            using (var desSvc = new DESCryptoServiceProvider())
            {
                desSvc.Mode = CipherMode.CBC;
                desSvc.Padding = PaddingMode.PKCS7;
                desSvc.Key = Encoding.UTF8.GetBytes(key);
                desSvc.IV = Encoding.UTF8.GetBytes(key);
                using (var msDecrypt = new MemoryStream())
                {
                    var cryptDecrypt = new CryptoStream(msDecrypt, desSvc.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptDecrypt.Write(decryptText, 0, decryptText.Length);
                    cryptDecrypt.FlushFinalBlock();
                    cryptDecrypt.Close();
                    cryptDecrypt.Dispose();
                    return Encoding.UTF8.GetString(msDecrypt.ToArray());
                }
            }
        }
    }


}