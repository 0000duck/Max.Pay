using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Max.Common.Utils.Encrypt
{
    public class AESUtils
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, string key)
        {
            if (string.IsNullOrEmpty(toEncrypt) || string.IsNullOrEmpty(key))
            {
                return toEncrypt;
            }
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = UTF8Encoding.UTF8.GetBytes(key);
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static byte[] EncryptByByte(string toEncrypt, string key)
        {
            if (string.IsNullOrEmpty(toEncrypt) || string.IsNullOrEmpty(key))
            {
                return null;
            }
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = Convert.FromBase64String(key);
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return resultArray;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt, string key)
        {
            if (string.IsNullOrEmpty(toDecrypt) || string.IsNullOrEmpty(key))
            {
                return toDecrypt;
            }
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = UTF8Encoding.UTF8.GetBytes(key);
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string DecryptByByte(byte[] toDecrypt, string key)
        {
            if (toDecrypt == null || toDecrypt.Length == 0)
            {
                return string.Empty;
            }

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = Convert.FromBase64String(key);
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecrypt, 0, toDecrypt.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
