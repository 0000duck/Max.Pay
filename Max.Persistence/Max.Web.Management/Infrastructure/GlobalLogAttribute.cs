using Max.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using System.IO;
using Max.Framework.Log;

namespace Max.Web.Management.Infrastructure
{
    public class GlobalLogAttribute : ActionFilterAttribute
    {
        private static bool debugLog = "debugLog".ValueOfAppSetting() == "1";
        private StringBuilder builder = new StringBuilder();

        public ILog log { get; set; }

        Stopwatch GetTimer(ControllerContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }
            var watch = new Stopwatch();
            context.HttpContext.Items[key] = watch;
            return watch;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (debugLog)
            {
                GetTimer(filterContext, "action").Start();
                builder.AppendLine("【请求参数】").AppendLine(filterContext.ActionParameters.Where(a=>!(a.Value is HttpPostedFileBase)).ToJson(true));
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (debugLog)
                GetTimer(filterContext, "action").Stop();
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (debugLog)
                GetTimer(filterContext, "render").Start();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (debugLog)
            {
                var watchRender = GetTimer(filterContext, "render");
                watchRender.Stop();
                var watchAction = GetTimer(filterContext, "action");

                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];

                builder.Append("【执行时间】").Append(watchAction.ElapsedMilliseconds).Append("ms").AppendLine();
                builder.Append("【渲染时间】").Append(watchRender.ElapsedMilliseconds).Append("ms").AppendLine();
                builder.Append("【本机IP】").Append(IPUtil.GetLocalIP()).AppendLine();
                builder.Append("【访问路径】").AppendLine(filterContext.HttpContext.Request.RawUrl);

                if (filterContext.HttpContext.Response.ContentType == "application/json")
                {
                    var json = filterContext.Result as ContentResult;
                    if (json != null)
                        builder.Append("【响应内容】").AppendLine(json.Content);
                }
                
                log.WriteToFile(builder.ToString(), "logs/{0}-{1}".Fmt(controllerName.ToLower(), actionName.ToLower()));
            }
        }
    }
}