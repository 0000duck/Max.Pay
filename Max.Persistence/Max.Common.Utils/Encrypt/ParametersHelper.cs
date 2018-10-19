using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Common.Utils.Encrypt
{
    public static class ParametersHelper
    {
        /**
         * 用户ID参数DES加密密钥（h5页面之间的参数传输加密）
         */
        public const string UserIdDesSecretKey = "iu85Bmjx";

        /**
         * APP信用模块DES加密密钥（APP与h5之间的参数传输加密）
         */
        public const string AppCreditDesSecretKey = "";

        #region h5页面参数加/解密

        /// <summary>
        /// 对用户ID进行DES加密
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string EncryptUserIdByDes(string userId)
        {
            if (userId.IsNullOrEmpty())
            {
                return "";
            }

            string val = userId + "," + DateTime.Now.Ticks;
            return CryptographyUtils.DesEncrypt(val, UserIdDesSecretKey);
        }

        /// <summary>
        /// 对用户ID进行DES解密
        /// </summary>
        /// <param name="encryptUserId"></param>
        /// <returns></returns>
        public static string DecryptUserIdByDes(string encryptUserId)
        {
            if (encryptUserId.IsNullOrEmpty())
            {
                return "";
            }

            try
            {
                string val = CryptographyUtils.DesDecrypt(encryptUserId, UserIdDesSecretKey);
                string[] vals = val.Split(',');

                if (vals.Length == 2)
                {
                    return vals[0];
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            return "";
        }
        #endregion

        #region APP参数加/解密

        /// <summary>
        /// 对手机号进行DES加密
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string EncryptMobileFromApp(string mobile)
        {
            return mobile.IsNullOrEmpty() ? "" : CryptographyUtils.DesEncrypt(mobile, AppCreditDesSecretKey);
        }

        /// <summary>
        /// 对手机号进行DES解密
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string DecryptMobileFromApp(string mobile)
        {
            if (mobile.IsNullOrEmpty())
            {
                return "";
            }

            try
            {
                string val = CryptographyUtils.DesDecrypt(mobile, AppCreditDesSecretKey);

                if (!val.IsNullOrEmpty())
                {
                    return val;
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            return "";
        }

        #endregion

        #region 格式化参数

        /// <summary>
        /// 格式化身份证号码
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public static string FormatIdCardNo(string idCardNo)
        {
            if (string.IsNullOrEmpty(idCardNo))
            {
                return string.Empty;
            }

            int len = idCardNo.Length;

            if (len != 15 && len != 18)
            {
                return idCardNo;
            }

            return idCardNo.Substring(0, 2).PadRight(len - 5, '*') + idCardNo.Substring(len - 3);
        }

        /// <summary>
        /// 格式化姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            int length = name.Length;
            return length < 2 ? name : name.Substring(length - 1).PadLeft(length, '*');
        }

        /// <summary>
        /// 格式化银行卡号最后len位数字
        /// </summary>
        /// <param name="bankCardNo"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string FormatBankCardNo(string bankCardNo, int len)
        {
            if (string.IsNullOrEmpty(bankCardNo))
            {
                return string.Empty;
            }

            int length = bankCardNo.Length;

            if (len >= length)
            {
                return bankCardNo;
            }

            return bankCardNo.Substring(length - len);
        }

        /// <summary>
        /// 格式化银行卡号
        /// </summary>
        /// <param name="bankCardNo"></param>
        /// <param name="frontLen"></param>
        /// <param name="backLen"></param>
        /// <returns></returns>
        public static string FormatBankCardNo(string bankCardNo, int frontLen, int backLen)
        {
            if (string.IsNullOrEmpty(bankCardNo))
            {
                return string.Empty;
            }

            int length = bankCardNo.Length;

            if (frontLen + backLen >= length)
            {
                return bankCardNo;
            }

            return bankCardNo.Substring(0, frontLen).PadRight(length - backLen, '*') +
                   bankCardNo.Substring(length - backLen);
        }
        #endregion
    }
}