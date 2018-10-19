using Max.Framework.Authorization;
using Max.Models.System.Common;
using Max.Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Max.Framework;
using Max.Service.Auth.Common;

namespace Max.Web.Management.Infrastructure
{
    public class GlobalAuthorizeAttribute : AuthorizeAttribute
    {
        private string actionUrl;
        private string rawUrl;
        private string unauthorizedMessage;

        public PermissionService permissionService { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContent");

            // 判断是否超级管理员
            var user = AuthorizeHelper.GetCurrentUser();
            if (user == null)
                return AuthResult(false, httpContext, 401);

            if (user.UserType == (int)UserType.超级管理员)
                return this.permissionService.IsSupperAdmin(user.UserId);

            var permissions = this.permissionService.GetPermissionCache(user.UserId);

            // 判断菜单权限
            if (!HasMenuPermission(permissions))
                return AuthResult(false, httpContext, 403);

            // 判断Action权限
            if (!HasActionPermission(permissions))
                return AuthResult(false, httpContext, 403);

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.actionUrl = PermissionUtil.CurrentPermissionUrl(filterContext);
            this.rawUrl = PermissionUtil.CurrentUrl(filterContext);

            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var url = FormsAuthentication.LoginUrl + "?ReturnUrl=" +
                      HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsoluteUri);

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 307;//ajax页面重定向
                filterContext.Result = GetJsonResult(url);
                return;
            }

            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                filterContext.Result = new RedirectResult(url);
                return;
            }

            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl + "?ReturnUrl=http://" +
             HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.Authority));
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool HasMenuPermission(string permissions)
        {
            /* 菜单权限
             * =========================
             * 1、是系统菜单才判断
             * 2、如果用户不拥有该菜单则没有权限
             * =========================*/
            var menus = this.permissionService.GetAllMenusCached();
            var url = ",{0},".Fmt(this.rawUrl);
            if (!menus.Contains(url) || this.rawUrl == "/")
                return true;
            if (!permissions.Contains(url))
            {
                unauthorizedMessage = "您没有访问菜单({0})的权限".Fmt(url.Trim(','));
                return false;
            }
            return true;
        }

        private bool HasActionPermission(string permissions)
        {
            /* 菜单权限
             * =========================
             * 1、定义了[Permission]标签的才判断
             * 2、判断用户是否拥有该权限
             * =========================*/
            var code = string.Empty;
            if (!PermissionUtil.PermissionUrls.TryGetValue(this.actionUrl, out code))
                return true;
            if (!permissions.Contains(",{0},".Fmt(code)))
            {
                unauthorizedMessage = "您没有权限({0})".Fmt((PermCode)int.Parse(code));
                return false;
            }
            return true;
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