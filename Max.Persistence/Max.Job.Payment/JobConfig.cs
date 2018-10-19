﻿using Autofac;
using Autofac.Extras.Quartz;
using log4net;
using Max.Framework;
using Max.Framework.DAL;
using Max.Framework.DAL.SqlServer;
using Max.Framework.Utility;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Xml;
using Topshelf.Quartz;
using Topshelf.ServiceConfigurators;
using System.Linq;
using Max.Framework.Redis;
using Max.Framework.Caching;
using Max.Framework.ESB;
using Max.Framework.MongoDb;
using Max.Framework.NoSql;
using Max.Framework.ServiceBus;

namespace Max.Job.Payment
{
    public class JobConfig
    {
        private static ILog log = LogManager.GetLogger(typeof(JobConfig));

        public static readonly string JobFile = "jobs.xml";
        public static readonly string JobNamespceFormat;
        public static readonly string ServiceName;
        public static readonly List<Job> JobList;

        static JobConfig()
        {
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JobFile);
            var xml = string.Empty;
            using (var reander = File.OpenText(xmlPath))
            {
                xml = reander.ReadToEnd();
            }

            var doc = new XmlDocument();
            doc.LoadXml(xml);

            // Windows 服务名称
            ServiceName = doc.SelectSingleNode("quartz/service").InnerText;
            // JOB 命名空间
            JobNamespceFormat = doc.SelectSingleNode("quartz/namespace").InnerText;
            // JOBS
            var nodes = doc.SelectNodes("quartz/jobs/job");
            JobList = new List<Job>();
            foreach (var node in nodes)
            {
                var el = (XmlElement)node;
                JobList.Add(new Job(el.GetAttribute("name"), el.InnerText));
            }

            log.Info("Jobs.xml 初始化完毕：\r\n" + JobList.ToJson());
        }

        public static void Schedule(IContainer container, ServiceConfigurator<JobService> svc)
        {
            svc.UsingQuartzJobFactory(() => container.Resolve<IJobFactory>());
            foreach (var job in JobList)
            {
                svc.ScheduleQuartzJob(q =>
                {
                    q.WithJob(JobBuilder.Create(Type.GetType(JobNamespceFormat.Fmt(job.Name)))
                        .WithIdentity(job.Name, ServiceName)
                        .Build);

                    q.AddTrigger(() => TriggerBuilder.Create()
                        .WithCronSchedule(job.Cron)
                        .Build());

                    log.InfoFormat("任务 {0} 已完成调度设置", JobNamespceFormat.Fmt(job.Name));
                });
            }
        }

        internal static ContainerBuilder ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(JobConfig).Assembly));
            builder.RegisterType<JobService>().AsSelf();
            foreach (var con in ConfigUtil.GetConnStrings())
                builder.Register(c => new SqlConnection(con.Value))
                    .Named<IDbConnection>(con.Key)
                    .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //builder.Register<Func<string, IDbConnection>>(c => named => c.ResolveNamed<IDbConnection>(named)).InstancePerLifetimeScope();
            builder.Register<Func<string, IDbConnection>>(c =>
            {
                var ic = c.Resolve<IComponentContext>();
                return named => ic.ResolveNamed<IDbConnection>(named);
            });
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //builder.RegisterType<HuaAnInsuranceSupplier>().AsSelf().SingleInstance();      
            var execDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(execDir, "Max.*.dll", SearchOption.TopDirectoryOnly);
            if (files.Length > 0)
            {
                var assemblies = new Assembly[files.Length];
                for (int i = 0; i < files.Length; i++)
                    assemblies[i] = Assembly.LoadFile(files[i]);

                builder.RegisterAssemblyTypes(assemblies)
                  .Where(t => t.GetInterfaces().Contains(typeof(IService)))
                  .AsSelf()
                  .InstancePerLifetimeScope();
            }
            RedisProxy.Initialize();
            var redis = new RedisProxy();
            builder.Register(c => redis).As<ICache>().SingleInstance();
            builder.Register(c => redis).As<IRedisProxy>().SingleInstance();
            builder.RegisterType<ServiceBus>().As<IServiceBus>().SingleInstance();
            builder.RegisterType<MongoProxy>().As<IMongoProxy>().SingleInstance();

            return builder;
        }
    }

    public class Job
    {
        public Job(string name, string cron)
        {
            this.Name = name;
            this.Cron = cron;
        }

        public string Name { get; set; }
        public string Cron { get; set; }
    }

    public class JobService
    {
        private static ILog log = LogManager.GetLogger(typeof(JobService));

        public bool Start()
        {
            log.Info("服务已启动");
            return true;
        }

        public bool Stop()
        {
            log.Info("服务已关闭");
            return false;
        }
    }

}
