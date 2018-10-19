using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Max.Web.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    //        routes.MapRoute(
    //    "Action1Html", // action伪静态    
    //    "{controller}/{action}.html",// 带有参数的 URL    
    //    new { controller = "Project", action = "ProjectManual", id = UrlParameter.Optional }// 参数默认值    
    //);
            routes.MapRoute(
               name: "Project",
               url: "ProjectDetail.html",
               defaults: new { controller = "Project", action = "ProjectManual" }
            );

            routes.MapRoute(
               name: "TransitRoute",
               url: "vip",
               defaults: new { controller = "TransferPage", action = "Index" }
            );

            routes.MapRoute(
              name: "ProjectRecord",
              url: "{controller}/{action}/{projectid}",
              defaults: new { controller = "Project", action = "ProjectManual" }
            ); 
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
