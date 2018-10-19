using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Max.Common.Utils.Encrypt
{
    public class Base64Utils
    {
        /// <summary> 
        /// 将字符串使用base64算法加密 
        /// </summary> 
        /// <param name="encodingName">编码类型（编码名称）</param>
        /// <param name="source">待加密的字符串</param>
        /// <returns>加密后的字符串</returns> 
        public static string EncodeBase64String(string source, string encodingName = "UTF-8")
        {
            byte[] bytes = Encoding.GetEncoding(encodingName).GetBytes(source); //将一组字符编码为一个字节序列. 
            return Convert.ToBase64String(bytes); //将8位无符号整数数组的子集转换为其等效的,以64为基的数字编码的字符串形式. 
        }

        /// <summary> 
        /// 将字符串使用base64算法解密 
        /// </summary> 
        /// <param name="encodingName">编码类型</param> 
        /// <param name="base64String">已用base64算法加密的字符串</param> 
        /// <returns>解密后的字符串</returns> 
        public static string DecodeBase64String(string base64String, string encodingName = "UTF-8")
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String); //将2进制编码转换为8位无符号整数数组. 
                return Encoding.GetEncoding(encodingName).GetString(bytes); //将指定字节数组中的一个字节序列解码为一个字符串。
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Base64加密和Url编码    
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string Base64Encript(string str)
        {
            return HttpUtility.UrlEncode(EncodeBase64String(str));
        }

        /// <summary>
        /// Base64字符串解码
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string Base64Decode(string str)
        {
            return HttpUtility.UrlDecode(DecodeBase64String(str));
        }
    }
}
