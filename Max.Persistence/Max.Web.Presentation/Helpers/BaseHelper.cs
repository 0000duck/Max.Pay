using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Max.Framework.Utility;
using Max.Framework;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Max.Web.Presentation.Helpers
{
    public class BaseHelper
    {
        /// <summary>
        /// 系统自带的手机判断方法未必跟钱端的一致，所以用钱端的判断方法
        /// </summary>
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
        public class QDMobileAttribute : ValidationAttribute
        {
            public QDMobileAttribute()
            { }

            public override bool IsValid(object value)
            {
                var obj = value as string;

                return obj.IsNullOrEmpty() ? false : obj.IsMobile();
            }
        }
    }

    /// <summary>
    /// 密码帮助类
    /// </summary>
    public class PWDHelper
    {
        /// <summary>
        /// 获取MD5字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            //MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hash.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 判断密码强度
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static int GetPwdstrength(string pwd)
        {
            int length = pwd.Length;
            if (length >= 12)
            {
                return 3;
            }
            else if (length >= 9)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static ServiceResult ValidPassword(string pwd)
        {
            ServiceResult result = new ServiceResult();
            result.IsSucceed();
            var validWhite = Regex.IsMatch(pwd, @"/\s/g", RegexOptions.IgnoreCase);
            if (validWhite)
                result.IsFailed("请输入6~15位字母、数字或者符号组合。");

            var validPayPwd = Regex.IsMatch(pwd,
                @"^(?![0-9]+$)(?![a-zA-Z]+$)(?![\W]+$)([0-9A-Za-z]{6,15}|[\d\W]{6,15}|[a-zA-Z\W]{6,15}|[A-Za-z\d\W]{6,15})$",
                RegexOptions.IgnoreCase);
            if (!validPayPwd)
                result.IsFailed("长度为6~15位，且必须包含字母、数字、字符中的任意两种以上；字母要区分大小写；");

            return result;
        }
    }


}