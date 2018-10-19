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
    /// <summary>
    /// 车险业务日志实体
    /// </summary>
    [Queue(MQConfig.CarInsurance_Queue, ExchangeName = MQConfig.CarInsurance_Exchange)]
    public class CarBusinessLogMessage : MongoEntity, ICarInsuranceMessage
    {
        /// <summary>
        /// 日志类型 99 代表车险业务日志
        /// </summary>
        public int CompanyType { get; set; }


        /// <summary>
        /// 业务模块名称
        /// </summary>
        public string BusinessModule { get; set; }


        /// <summary>
        /// 日志类型(1账单支付，2还款支付)
        /// </summary>
        public int LogType { get; set; }

        /// <summary>
        /// 对象编号
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 操作类型(1添加 2修改 3回调)
        /// </summary>
        public int OperaType { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
    }

}
