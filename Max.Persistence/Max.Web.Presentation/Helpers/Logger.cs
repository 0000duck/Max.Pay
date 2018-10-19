﻿using log4net;
using Max.Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;
using log4net.Appender;
using Max.Framework.MongoDb;
using Max.Framework.NoSql;

namespace Max.Web.Presentation.Helpers
{
    public class Logger : Max.Framework.Log.ILog
    {
        private static log4net.ILog _log = LogManager.GetLogger(typeof(Logger));
        private IMongoProxy mongo;

        public Logger(IMongoProxy mongo)
        {
            this.mongo = mongo;
        }

        public void WriteToFile(string message, string dir = "")
        {
            var appenders = LogManager.GetRepository().GetAppenders();
            var appender = appenders.First(i => i.Name == "InfoAppender") as RollingFileAppender;
            if (dir.IsNullOrEmpty())
                appender.File = "log4net/{0:yyyyMMdd}/";
            else
                appender.File = "log4net/{0:yyyyMMdd}/{1}/".Fmt(DateTime.Now, dir);
            appender.ActivateOptions();
            _log.Info(message);
        }

        public void WriteToMongo<T>(T message, string table) where T : MongoEntity
        {
            try
            {
                //this.mongo.InsertOne(DateTime.Now.ToString("yyyyMMdd"), table, message);
            }
            catch (Exception ex)
            {
                _log.Error("日志写入 Mongo 失败：\r\n{0}".Fmt(message.ToJson(true)), ex);
            }
        }


        public void WriteToMQ<T>(string queue, string message)
        {
            throw new NotImplementedException();
        }
    }
}