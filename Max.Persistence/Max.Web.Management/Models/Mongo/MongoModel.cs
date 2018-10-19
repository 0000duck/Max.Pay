using Max.Framework.NoSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace Max.Web.Management.Models.Mongo
{

    #region MongoDatabaseModel

    public class MongoDatabaseModel
    {
        public string name { get; set; }
        public float sizeOnDisk { get; set; }
        public bool empty { get; set; }
    }
    #endregion

    #region MongoCollectionModel

    public class MongoCollectionModel
    {
        public string name { get; set; }
        public MongoCollectionModel_options options { get; set; }
    }

    public class MongoCollectionModel_options
    {
        public bool capped { get; set; }
        public long size { get; set; }
    }

    #endregion


    #region MongoParams

    public class MongoParams
    {
        public string database { get; set; }

        public string collection { get; set; }

        public string json { get; set; }
    }
    #endregion

    #region ApiLog日志Model

    public class ApiLogModel : MongoEntity
    {
        //public new string _id { get; set; }
        public string RequestId { get; set; }
        public string Cmd { get; set; }
        public string UserDataStr { get; set; }
        public ApiLogUserData UserData { get; set; }
        public string RequestDataStr { get; set; }
        public object RequestJson { get; set; }
        public object Response { get; set; }
        public double Duration { get; set; }
        public bool IsError { get; set; }

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


    public class MongoApiLogParams
    {
        public string database { get; set; }
        public string collection { get; set; }
        public string EPlusAccountId { get; set; }
        public string IDCard { get; set; }
        public string InstitutionNo { get; set; }
        public string Mobile { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string UserId { get; set; }
        public string Usrnbr { get; set; }
        public double? Duration { get; set; }

        public int GreaterThanLess { get; set; }

        private DateTime? _logTimeStart = DateTime.Now.AddDays(-7);
        public DateTime? LogTimeStart
        {
            get { return _logTimeStart; }
            set { _logTimeStart = value; }
        }
        public DateTime? LogTimeEnd { get; set; }
        public int? IsError { get; set; }
    }

    public class ZJLogParams
    {
        public string Database { get; set; }
        public string Collection { get; set; }
        public string RequestId { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public int? IsError { get; set; }
        public double Duration { get; set; }
        public DateTime? LogTimeStart { get; set; }
        public DateTime? LogTimeEnd { get; set; }
    }
    public class ZJLogModel : MongoEntity
    {
        public string Cmd { get; set; }
        public string RequestId { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public bool IsError { get; set; }
        public double Duration { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }
    }
    public class CfcaApiLogModel : MongoEntity
    {
        public string Cmd { get; set; }
        public string RequestId { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public bool IsError { get; set; }
        public double Duration { get; set; }
        public string RequestXml { get; set; }
        public string ResponesXml { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }
    }
    public class CfcaApiLogParams
    {
        public string Database { get; set; }
        public string Collection { get; set; }
        public string RequestId { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public int? IsError { get; set; }
        public double Duration { get; set; }
        public DateTime? LogTimeStart { get; set; }
        public DateTime? LogTimeEnd { get; set; }
    }

    public class MinaLogParams
    {
        public string Database { get; set; }
        public string Collection { get; set; }
        public string RequestId { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public int? IsError { get; set; }
        public double Duration { get; set; }
        public DateTime? LogTimeStart { get; set; }
        public DateTime? LogTimeEnd { get; set; }
    }
    public class MinaLogModel : MongoEntity
    {
        public string Cmd { get; set; }
        public string RequestId { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public bool IsError { get; set; }
        public double Duration { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }
    }

    public class ZTBApiLogMessage : MongoEntity
    {
        /// <summary>
        /// 业务模块名称
        /// </summary>
        public string BusinessModule { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// 请求参数Json
        /// </summary>
        public string RequestJson { get; set; }
        /// <summary>
        /// 返回参数Json
        /// </summary>
        public string ResponseJson { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMsg { get; set; }

        public double Duration { get; set; }

        public int? SyncHasData { get; set; }
    }
    #endregion

}