using Max.Web.OpenApi.Common.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Max.Web.OpenApi.App_Start;
using Newtonsoft.Json.Converters;

namespace Max.Web.OpenApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // JSON 序列化时间
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            jsonFormatter.SerializerSettings.Converters.Add(
                new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }
                );

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //手机直充路由配置
            config.Routes.MapHttpRoute(
                name: "RechargeApi",
                routeTemplate: "RechargeApi/{controller}/{id}",
                defaults: new { controller = "RechargeCallBack", action = "Index", id = RouteParameter.Optional }
            );
            //加油卡直充路由配置
            config.Routes.MapHttpRoute(
                name: "RefuelCardApi",
                routeTemplate: "RefuelCardApi/{controller}/{id}",
                defaults: new { controller = "RefuelCardCallBack", action = "Index", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Process", action = "Index", id = RouteParameter.Optional }
            );
            //阳光保险转人工核保回调路由配置
            config.Routes.MapHttpRoute(
                name: "SunlightApi",
                routeTemplate: "SunlightApi/{controller}/{action}",
                defaults: new { controller = "Sunlight", action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
