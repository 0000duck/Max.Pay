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
    [Queue(MQConfig.LogApi_Queue, ExchangeName = MQConfig.LogApi_Exchange)]
    public class ApiLogMessage : MongoEntity
    {
        public string RequestId { get; set; }

        public string Cmd { get; set; }

        /// <summary>
        /// 用户信息报文
        /// </summary>
        public string UserDataStr { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public ApiLogUserData UserData { get; set; }

        /// <summary>
        /// 请求报文
        /// </summary>
        public string RequestDataStr { get; set; }

        public string RequestJson { get; set; }

        /// <summary>
        /// 耗时
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// 是否系统错误
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// 返回
        /// </summary>
        public string Response { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }
    }

    public class ApiLogUserData
    {
        public string EPlusAccountId { get; set; }
        public string IDCard { get; set; }
        public string InstitutionNo { get; set; }
        public string Mobile { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string UserId { get; set; }
        public string Usrnbr { get; set; }
    }
}
