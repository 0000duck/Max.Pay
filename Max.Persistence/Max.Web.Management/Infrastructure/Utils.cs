using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace Max.Web.Management
{
    public static class Utils
    {
        #region CopyProperties复制对象属性
        /// <summary>
        /// 复制对象属性
        /// </summary>
        /// <typeparam name="TIn">输入类型</typeparam>
        /// <typeparam name="TOut">引用输出类型</typeparam>
        /// <param name="inEntity">输入实体</param>
        /// <param name="outEntity">输出实体</param>
        /// <param name="ignoreNull">为空不赋值,默认：True</param>
        public static void CopyProperties<TIn, TOut>(TIn inEntity, ref TOut outEntity, bool ignoreNull = true) where TOut : class, new()
        {
            if (outEntity == null)
                outEntity = new TOut();

            if (inEntity == null)
                return;

            PropertyInfo[] OutPropertyInfos = typeof(TOut).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] InPropertyInfos = typeof(TIn).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var pIn in InPropertyInfos)
            {
                foreach (var pOut in OutPropertyInfos)
                {
                    if (string.Compare(pOut.Name, pIn.Name, false) == 0)
                    {
                        if (!pOut.CanWrite) break;

                        if (ignoreNull && object.Equals(pIn.GetValue(inEntity, null), null)) break;

                        pOut.SetValue(outEntity, pIn.GetValue(inEntity, null), null);
                        break;
                    }
                }
            }
        }
        #endregion

        #region 正则过滤<script>标签
        /// <summary>
        /// 正则过滤script标签
        /// </summary>
        /// <param name="str">包含script标签的字符串</param>
        /// <returns>返回替换后的字符串</returns>
        public static string FilterScript(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            return Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 随机生成编号
        /// <summary>
        /// 随机生成编号（前缀+时间（毫秒级，举例：20160111081245023）+4位随机数字。），只负责生成，不进行重复性校验,批量生成需对生成的值进行数据库校验
        /// </summary>
        /// <param name="PreStr"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public static string GenerateCommonNo(string PreStr, int lenght = 4)
        {
            Random rd = new Random();
            string str = "0123456789";
            string Last_CommonNo = "";
            for (int i = 0; i < lenght; i++)
            {
                Last_CommonNo += str[rd.Next(str.Length)];
            }
            string CommonNo = string.Format("{0}{1}{2}", PreStr, DateTime.Now.ToString("yyyyMMddHHmmssfff"), Last_CommonNo);
            return CommonNo;
        }
        #endregion

        #region 格式化电话、证件号码、银行卡号

        public static string FmtMobile(this string mobile)
        {
            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            { 
                Regex regx = new Regex(@"(?<=\d{3}).+(?=\d{4})", RegexOptions.IgnoreCase);
                mobile = regx.Replace(mobile, "****");
            }

            return mobile;
        }

        public static string FmtCert(this string cert)
        {
            if (!string.IsNullOrEmpty(cert) && cert.Length > 10)
            {
                Regex regx = new Regex(@"(?<=\w{6}).+(?=\w{4})", RegexOptions.IgnoreCase);
                cert = regx.Replace(cert, "********");
            }

            return cert;
        }

        public static string FmtBankCard(this string bankCark)
        {
            if (!string.IsNullOrEmpty(bankCark) && bankCark.Length > 4)
            {
                Regex regx = new Regex(@"(?<=\d{4})\d+(?=\d{4})", RegexOptions.IgnoreCase);
                bankCark = regx.Replace(bankCark, " **** **** ");
            }

            return bankCark;
        }

        #endregion
    }
}
