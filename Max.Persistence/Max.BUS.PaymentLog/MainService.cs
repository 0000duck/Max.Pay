using log4net;
using Max.BUS.Message.Log;
using Max.Framework.ESB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Framework;
using Max.Framework.NoSql;

namespace Max.BUS.PaymentLog
{
    public class MainService
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));
        private IServiceBus bus;
        private IMongoProxy mongo;
        public MainService(IServiceBus bus, IMongoProxy mongo)
        {
            this.bus = bus;
            this.mongo = mongo;
        }

        public bool Start()
        {
            try
            {
                this.bus.Subscribe<IPaymentMessage>("", msg =>
                {
                    log.Info(msg.ToJson());
                    //var dbName = "PaymentLog" + DateTime.Now.ToString("yyyyMM");
                    //if (msg.CompanyType == 1)
                    //{
                    //    dbName = dbName + "_HuaAn";
                    //}
                    //else if (msg.CompanyType == 2)
                    //{
                    //    dbName = dbName + "_Sunlight";
                    //}
                    ////业务日志
                    //else if (msg.CompanyType == 99)
                    //{
                    //    dbName = "CarBusinessLog" + DateTime.Now.ToString("yyyyMM");
                    //}
                    //else
                    //{
                    //    dbName = dbName + "_" + msg.CompanyType;
                    //}

                    var dbName = GetDbName(msg.CompanyType);

                    var colName = msg.BusinessModule ?? "Default";
                    //mongo.InsertOne(dbName, colName, msg);
                    var Msg = msg as MongoEntity;
                    mongo.InsertOne(dbName, colName, Msg);
                });

               
                log.Info("服务已启动");
                return true;
            }
            catch (Exception ex)
            {
                log.Error("服务启动失败", ex);
                return false;
            }
        }

        public bool Stop()
        {
            return true;
        }

        private string GetDbName(int type)
        {
            string dbName = type.ToString();
            string dc = "PaymentLog" + DateTime.Now.ToString("yyyyMM");
            switch (type)
            {
                case 1:
                    dbName = dc + "_HuaAn";
                    break;
                case 2:
                    dbName = dc + "_Sunlight";
                    break;
                case 3:
                    dbName = dc + "_AnBang";
                    break;
                case 4:
                    dbName = dc + "_TianAn";
                    break;
                case 99:
                    dbName = "CarBusinessLog" + DateTime.Now.ToString("yyyyMM");
                    break;
                default:
                    dbName = dc + "_" + type.ToString();
                    break;
            }
            return dbName;
        }
    }
}
