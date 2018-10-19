using Max.Framework.Redis;
using Max.Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Framework.NoSql;
using Max.Framework.Log;
using Max.BUS.Message.Log;

namespace Max.Web.Management.Infrastructure
{
    public class GlobalErrorAttribute : HandleErrorAttribute
    {
        public ILog log { get; set; }

        private static bool debugErr = "debugErr".ValueOfAppSetting() == "1";

        public override void OnException(ExceptionContext filterContext)
        {
            if (!debugErr)
                return;

            if (!filterContext.IsChildAction && !filterContext.ExceptionHandled)
            {
                Exception innerException = filterContext.Exception;
                if ((new HttpException(null, innerException).GetHttpCode() == 500) && this.ExceptionType.IsInstanceOfType(innerException))
                {
                    var msg = new GlobalErrorLog();
                    msg.Controller = (string)filterContext.RouteData.Values["controller"];
                    msg.Action = (string)filterContext.RouteData.Values["action"];
                    msg.Message = filterContext.Exception.ToString();
                    msg.CreateTime = DateTime.Now;
                    log.WriteToMongo(msg, "{0}-{1}".Fmt(msg.Controller, msg.Action));

                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        var contentResult = new ContentResult();
                        contentResult.Content = innerException.Message;
                        filterContext.Result = contentResult;
                        filterContext.ExceptionHandled = true;
                        filterContext.HttpContext.Response.Clear();
                        filterContext.HttpContext.Response.StatusCode = 500;
                        filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    }
                }
            }
        }
    }
}