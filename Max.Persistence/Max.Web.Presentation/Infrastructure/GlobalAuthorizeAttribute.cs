using Max.Framework.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Web.Presentation.Common;
using Max.Web.Presentation.Helpers;

namespace Max.Web.Presentation.Infrastructure
{
    public class GlobalAuthorizeAttribute : AuthorizeAttribute
    {
        private string unauthorizedMessage = "您的登录状态已超时，请重新登录";


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContent");

            if (httpContext.Request.Params["SignMobile"]!=null)
            {
                //判断是否在APP打开
                //string mobile = ParametersHelper.DecryptMobileFromApp(httpContext.Request.Params["SignMobile"]);
                //User user = UserService.Get(p => p.Mobile == mobile);

                //if (user != null)
                //{
                //    return true;
                //}
                return true;
            }
            else
            {
                // 判断是否已登录
                var userId = WapAuthorizeHelper.GetCurrentUserId();
                if (userId.IsNullOrEmpty())
                    return AuthResult(false, httpContext, 401);
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = GetJsonResult(unauthorizedMessage);
                return;
            }

            if (filterContext.HttpContext.Response.StatusCode == 401 && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = GetJsonResult(unauthorizedMessage);
                return;
            }

            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = GetJsonResult(unauthorizedMessage);
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool AuthResult(bool result, HttpContextBase httpContext, int statusCode)
        {
            httpContext.Response.StatusCode = statusCode;
            return result;
        }

        private JsonResult GetJsonResult(string message)
        {
            return new JsonResult
                {
                    Data = new { Success = false, Message = message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }
    }
}