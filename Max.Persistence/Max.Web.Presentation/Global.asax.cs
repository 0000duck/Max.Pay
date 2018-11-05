using log4net;
using Max.Web.Presentation.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Max.BUS.Message.Log;
using Max.Framework.ESB;
using Max.Framework.ServiceBus;

namespace Max.Web.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ILog log = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.Register();
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();

        //    try
        //    {
        //        var httpError = exception as HttpException;

        //        if (httpError != null)
        //        {
        //            int httpCode = httpError.GetHttpCode();

        //            if (httpCode == 404)
        //            {
        //                Server.ClearError();
        //                return;
        //            }
        //        }

        //        var serviceBus = AutofacDependencyResolver.Current.GetService(typeof (IServiceBus)) as IServiceBus;
        //        //var msg = new H5ErrMessage
        //        //{
        //        //    UrlPath = HttpContext.Current.Request.RawUrl.Replace("?", "@*"),
        //        //    ErrMsg = exception.Message,
        //        //    ErrDetail = exception,
        //        //    ErrTime = DateTime.Now
        //        //};

        //        //serviceBus.Publish<IH5Message>(msg);
        //        Server.ClearError();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.ToString(), ex);
        //    }
        //    finally
        //    {
        //        Response.Redirect("/Error.html?s=app&aspxerrorpath=" + HttpContext.Current.Request.RawUrl.Replace("?", "@*"));
        //    }
        //}
    }
}
