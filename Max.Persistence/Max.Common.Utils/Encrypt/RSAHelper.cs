using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Max.Common.Utils.Encrypt
{
    public static class RSAHelper
    {

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="content">加密明文</param>
        /// <param name="rsaKey">公钥</param>
        /// <returns>返回密文</returns>
        public static string RSAEncryByType(string content, string rsaKey, RSAType type)
        {
            AsymmetricKeyParameter key;
            if (type == RSAType.公钥)
            {
                key = PublicKeyFactory.CreateKey(Convert.FromBase64String(rsaKey));
            }
            else
            {
                key = PrivateKeyFactory.CreateKey(Convert.FromBase64String(rsaKey));
            }
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");
            //私钥加密 
            c.Init(true, key);
            byte[] byteData = Encoding.UTF8.GetBytes(content);
            byteData = c.DoFinal(byteData, 0, byteData.Length);
            return Convert.ToBase64String(byteData);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="content">密文</param>
        /// <param name="rsaKey">公钥</param>
        /// <returns>明文</returns>
        public static string RSADecryByType(string content, string rsaKey, RSAType type)
        {
            try
            {
                MemoryStream bufferStream = new MemoryStream();
                byte[] bytData = Convert.FromBase64String(content);
                int inputLength = bytData.Length;

                AsymmetricKeyParameter key;
                if (type == RSAType.公钥)
                {
                    key = PublicKeyFactory.CreateKey(Convert.FromBase64String(rsaKey));
                }
                else
                {
                    key = PrivateKeyFactory.CreateKey(Convert.FromBase64String(rsaKey));
                }

                IBufferedCipher cipher = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");
                cipher.Init(false, key);
                int offSet = 0;
                byte[] cache;
                int i = 0;
                while (inputLength - offSet > 0)
                {
                    if (inputLength - offSet > 128)
                    {
                        cache = cipher.DoFinal(bytData, offSet, 128);
                    }
                    else
                    {
                        cache = cipher.DoFinal(bytData, offSet, inputLength - offSet);
                    }
                    bufferStream.Write(cache, 0, cache.Length);
                    i++;
                    offSet = i * 128;
                }
                byte[] decryptedData = bufferStream.ToArray();
                bufferStream.Close();
                return Encoding.UTF8.GetString(bufferStream.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    public enum RSAType
    {
        公钥 = 1,
        私钥 = 2
    }
}
