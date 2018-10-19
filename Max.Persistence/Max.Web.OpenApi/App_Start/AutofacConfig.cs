using Autofac;
using Max.Framework;
using Max.Framework.Caching;
using Max.Framework.DAL;
using Max.Framework.DAL.SqlServer;
using Max.Framework.Redis;
using Max.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Max.Web.OpenApi.Common;
using System.Text.RegularExpressions;
using Max.Framework.ServiceBus;
using Max.Framework.ESB;

namespace Max.Web.OpenApi.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(configuration);

            foreach (var con in ConfigUtil.GetConnStrings())
                builder.Register(c => new SqlConnection(con.Value))
                    .Named<IDbConnection>(con.Key)
                    .InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.Register<Func<string, IDbConnection>>(c =>
            {
                var ic = c.Resolve<IComponentContext>();
                return named => ic.ResolveNamed<IDbConnection>(named);
            });
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            RedisProxy.Initialize();
            var redis = new RedisProxy();
            builder.Register(c => redis).As<ICache>().SingleInstance();
            builder.Register(c => redis).As<IRedisProxy>().SingleInstance();

            builder.RegisterType<ServiceBus>().As<IServiceBus>().SingleInstance();

            var assemblies = BuildManager.GetReferencedAssemblies()
                .Cast<Assembly>()
                .Where(a => a.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(typeof(IService))) != null)
                .ToArray();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Contains(typeof(IService)))
                .AsSelf()
                .InstancePerRequest();
            
            #region API Processor Register

            builder.RegisterType<ProcessorFactory>().As<IProcessorFactory>().InstancePerRequest();

            foreach (var type in ProcessorUtil.GetProcessors())
            {
                builder.RegisterType(type)
                    .Named<IProcessor>(ProcessorUtil.GetBizCode(type))
                    .InstancePerRequest();
            }
            
            builder.Register<Func<string, IProcessor>>(c =>
            {
                var ic = c.Resolve<IComponentContext>();
                return name => ic.ResolveNamed<IProcessor>(name);
            });

            #endregion


            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

      
    }

    
}