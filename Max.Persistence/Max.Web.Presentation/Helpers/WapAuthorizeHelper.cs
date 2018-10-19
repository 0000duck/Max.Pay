using Max.Framework.Memcache;
using Max.Web.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using Max.Framework.Utility;
using Max.Framework;
using Max.Framework.Caching;
using Max.Framework.Memcache;

namespace Max.Web.Presentation.Helpers
{
       public class WapAuthorizeHelper
    {
        #region 初始化定义
        private static MemcacheProxy memcacheProxy;

        static WapAuthorizeHelper()
        {
            memcacheProxy = new MemcacheProxy();
        }

        #endregion

        #region 加密解密

        /// <summary>
        /// UserId加密
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        static string EncryptUserId(string userId)
        {
            string key = Base64Utils.EncodeBase64String(Guid.NewGuid().ToString());

            memcacheProxy.Set(key, userId, FormsAuthentication.Timeout.Seconds);

            return key;
        }

        /// <summary>
        /// UserId解密
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        static string DecryptUserId(string key)
        {
            string userId = memcacheProxy.Get(key);

            if (userId.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                // 延长时间
                memcacheProxy.Set(key, userId, FormsAuthentication.Timeout.Seconds);

                return userId;
            }
        }

        #endregion

        #region 公用方法

        private static WapUser GetCurrentUser()
        {
            if (HttpContext.Current == null)
                return null;

            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                WapUser user = ticket.UserData.FromJson<WapUser>();

                // 解密userId
                user.UserId = DecryptUserId(user.UserId);

                return user;
            }
            else
                return null;
        }

        public static string GetCurrentUserId()
        {
            WapUser user = GetCurrentUser();
            return user.IsNull() ? null : user.UserId;
        }

        public static void SignIn(WapUser user)
        {
            FormsAuthentication.Initialize();

            // 加密userId
            user.UserId = EncryptUserId(user.UserId);

            var ticket = new FormsAuthenticationTicket(
                1,
                user.UserId,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                false,
                user.ToJson(),
                FormsAuthentication.FormsCookiePath
            );

            var authCookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket)
            );

            authCookie.HttpOnly = true;
            authCookie.Path = FormsAuthentication.FormsCookiePath;
            authCookie.Secure = FormsAuthentication.RequireSSL;
            if (FormsAuthentication.CookieDomain != null)
            {
                authCookie.Domain = FormsAuthentication.CookieDomain;
            }

            authCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
        #endregion

    }



       public class WapUser
       {
           public WapUser()
           { }

           public string UserId { get; set; }
       }
}