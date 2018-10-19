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
    /// 车险接口日志
    /// </summary>
    [Queue(MQConfig.CarInsurance_Queue, ExchangeName = MQConfig.CarInsurance_Exchange)]
    public class CarInsuranceLogMessage : MongoEntity, ICarInsuranceMessage
    {
        /// <summary>
        /// 保险公司 1华安 2阳光
        /// </summary>
        public int CompanyType { get; set; }

        public CarInsuranceLogUserData UserData { get; set; }

        /// <summary>
        /// 保险公司
        /// </summary>
        public int InsuranceCompay { get; set; }

        /// <summary>
        /// 接口编码
        /// </summary>
        public string InterfaceCode { get; set; }


        /// <summary>
        /// 业务模块名称
        /// </summary>
        public string BusinessModule { get; set; }



        /// <summary>
        /// 请求参数
        /// </summary>
        public string RequestData { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string ResponseData { get; set; }



        /// <summary>
        /// 接口返回的错误信息
        /// </summary>
        public string ResponseErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMsg { get; set; }

        /// <summary>
        /// 耗时毫秒
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }


        /// <summary>
        /// 加密请求报文
        /// </summary>
        public string RequestEncryptXml { get; set; }

        /// <summary>
        /// 加密响应报文
        /// </summary>
        public string ResponseEncryptXml { get; set; }
    }

    public class CarInsuranceLogUserData
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单流水号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string VehicleInfo { get; set; }
        /// <summary>
        /// 车辆登记日期
        /// </summary>
        public string RegisterDate { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string RackNo { get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNo { get; set; }

        /// <summary>
        /// 区域代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 是否过户车辆
        /// </summary>
        public string IsTransfer { get; set; }
        /// <summary>
        /// 过户日期
        /// </summary>
        public string TransferDate { get; set; }
    }
}
