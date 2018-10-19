using EasyNetQ;
using MongoDB.Bson.Serialization.Attributes;
using Max.Framework.NoSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.BUS.Message.Log
{
    [Queue(MQConfig.LogInternalApi_Queue, ExchangeName = MQConfig.LogInternalApi_Exchange)]
    public class OpenApiLogMessage : MongoEntity
    {
        public string BizCode { get; set; }

        public string Cmd { get; set; }

        /// <summary>
        /// 请求报文
        /// </summary>
        public string RequestDataStr { get; set; }

        public string RequestJson { get; set; }

        /// <summary>
        /// 返回
        /// </summary>
        public string Response { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }
    }
}
