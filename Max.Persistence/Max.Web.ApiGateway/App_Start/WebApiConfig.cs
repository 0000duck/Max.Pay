using Max.Web.ApiGateway.Common.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Max.Web.ApiGateway.App_Start;
using Newtonsoft.Json.Converters;

namespace Max.Web.ApiGateway
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

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
