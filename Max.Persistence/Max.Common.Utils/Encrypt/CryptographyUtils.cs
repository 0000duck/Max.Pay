﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Max.Common.Utils.Encrypt
{
    public static class CryptographyUtils
    {
        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="decryptString">要加密的字符串。</param>
        /// <param name="secretKey">密钥，且必须为8位。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static string DesEncrypt(string decryptString, string secretKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(decryptString);
                des.Key = Encoding.ASCII.GetBytes(secretKey);
                des.IV = Encoding.ASCII.GetBytes(secretKey);
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="encryptedString">要解密的以Base64</param>
        /// <param name="secretKey">密钥，且必须为8位。</param>
        /// <returns>已解密的字符串。</returns>
        public static string DesDecrypt(string encryptedString, string secretKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(encryptedString);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.ASCII.GetBytes(secretKey);
                des.IV = Encoding.ASCII.GetBytes(secretKey);
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        public static string MD5Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] data = md5.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(text));

                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return sb.ToString();
        }
    }
}