using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Max.Web.PayApi.Common
{
    public class AESUtil
    {
        public static byte[] _key1 = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt)
        {
            // 256-AES key    
            // byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = _key1;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt)
        {
            // 256-AES key    
            // byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = _key1;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        private static string IV = "12345678qianduan"; //偏移量,可自行修改
        private static string Key = "qianduan12345678";
        /// <summary>  
        /// AES加密
        /// </summary>  
        /// <param name="plainBytes">被加密的明文</param>  
        /// <param name="key">密钥(16字节)</param>  
        /// <returns>密文</returns>  
        public static string AESEncrypt(String toEncrypt)
        {
            try
            {
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(Key);
                byte[] ivArray = UTF8Encoding.UTF8.GetBytes(IV);
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                RijndaelManaged rDel = new RijndaelManaged();
                rDel.BlockSize = 128;
                rDel.KeySize = 256;
                rDel.FeedbackSize = 128;
                rDel.Padding = PaddingMode.PKCS7;
                rDel.Key = keyArray;
                rDel.IV = ivArray;
                rDel.Mode = CipherMode.CBC;

                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        /// <summary>  
        /// AES解密
        /// </summary>  
        /// <param name="encryptedBytes">被加密的明文</param>  
        /// <param name="key">密钥(16字节)</param>  
        /// <returns>明文</returns>  
        public static string AESDecrypt(String toDecrypt)
        {
            try
            {
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(Key);
                byte[] ivArray = UTF8Encoding.UTF8.GetBytes(IV);
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);


                RijndaelManaged rDel = new RijndaelManaged();
                rDel.BlockSize = 128;
                rDel.KeySize = 256;
                rDel.FeedbackSize = 128;
                rDel.Padding = PaddingMode.PKCS7;
                rDel.Key = keyArray;
                rDel.IV = ivArray;
                rDel.Mode = CipherMode.CBC;

                ICryptoTransform cTransform = rDel.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return "";
            }
        }  
    }
}