using Autofac;
using System;
using System.Linq;
using Autofac.Integration.Mvc;
using System.Reflection;
using Max.Framework.DAL;
using Max.Framework.DAL.SqlServer;
using System.Web.Mvc;
using System.Web.Compilation;
using System.Data.SqlClient;
using Max.Framework.Utility;
using System.Data;
using Max.Framework.Caching;
using Max.Framework;
using Max.Framework.ESB;
using Max.Framework.Redis;
using Max.Framework.File;
using Max.Web.Presentation.Helpers;
using Max.Framework.Log;
using Max.Framework.MongoDb;
using Max.Framework.NoSql;
using Max.Framework.Memcache;
using Max.Framework.ServiceBus;

namespace Max.Web.Presentation.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();

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
            var memcache = new MemcacheProxy();
            builder.Register(c => redis).As<ICache>().SingleInstance();
            builder.Register(c => redis).As<IRedisProxy>().SingleInstance();
            builder.Register(c => memcache).As<IMemcacheProxy>().SingleInstance();

            builder.RegisterType<MongoProxy>().As<IMongoProxy>().SingleInstance();
            builder.RegisterType<Logger>().As<ILog>().SingleInstance();
            builder.RegisterType<ServiceBus>().As<IServiceBus>().SingleInstance();
            //builder.RegisterType<HuaAnInsuranceSupplier>().AsSelf().SingleInstance();
            builder.RegisterType<ExcelClient>().As<IExcelClient>().InstancePerRequest();

            var assemblies = BuildManager.GetReferencedAssemblies()
                .Cast<Assembly>()
                .Where(a => a.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(typeof(IService))) != null)
                .ToArray();

            builder.RegisterAssemblyTypes(assemblies)//查找程序集中以Svc结尾的类型
                .Where(t => t.GetInterfaces().Contains(typeof(IService)) && t.Name.EndsWith("Svc"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Contains(typeof(IService)))
                .AsSelf()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}