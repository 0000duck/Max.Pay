using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Web.Presentation.Common
{
    /// <summary>
    /// 全站cookie工具类，建议新增cookie都在此类中维护，便于统一管理，避免定义cookie过多，导致浏览器cookie丢失。
    /// </summary>
    public class CookieUtil
    {
        private static string GetCookie(string cookieName)
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[cookieName];
            return (cookie != null) ? cookie.Value : "";
        }
        private static void SetCookie(string cookieName, string cookieValue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName)
            {
                Value = cookieValue,
                Expires = expires
            };
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 车险保险公司cookie
        /// </summary>
        public static int InsurerEnumCookie
        {
            get
            {
                return GetCookie("InsurerEnum").TryInt(0).Value;
            }
            set
            {
                SetCookie("InsurerEnum", value.ToString(), DateTime.Now.AddDays(1.0));
            }
        }

        /// <summary>
        /// 设置车贷商户推荐码cookie
        /// </summary>
        /// <param name="cookieValue"></param>
        /// <param name="expires"></param>
        public static void SetCarLoanMerchantCode(string cookieValue, DateTime expires)
        {
            SetCookie("ccode", cookieValue, expires);
        }

        /// <summary>
        /// 获取车贷商户推荐码cookie
        /// </summary>
        /// <returns></returns>
        public static string GetCarLoanMerchantCode()
        {
            return GetCookie("ccode");
        }
    }
}