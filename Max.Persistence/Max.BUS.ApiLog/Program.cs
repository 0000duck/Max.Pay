using Autofac;
using Max.Framework.ServiceBus;
using Max.Framework.DAL;
using Max.Framework.DAL.SqlServer;
using Max.Framework.ESB;
using Max.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Autofac;
using Max.Framework;
using Max.Framework.MongoDb;
using Max.Framework.NoSql;

namespace Max.BUS.ApiLog
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 注入设置

            var builder = new ContainerBuilder();
            builder.RegisterType<MainService>().AsSelf().SingleInstance();
            foreach (var con in ConfigUtil.GetConnStrings())
                builder.Register(c => new SqlConnection(con.Value))
                    .Named<IDbConnection>(con.Key)
                    .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.Register<Func<string, IDbConnection>>(c => named => c.ResolveNamed<IDbConnection>(named)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ServiceBus>().As<IServiceBus>().SingleInstance();
            builder.RegisterType<MongoProxy>().As<IMongoProxy>().SingleInstance();
            var container = builder.Build();

            #endregion

            HostFactory.Run(config =>
            {
                config.SetServiceName("serviceName".ValueOfAppSetting());
                config.UseAutofacContainer(container);

                config.Service<MainService>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}
