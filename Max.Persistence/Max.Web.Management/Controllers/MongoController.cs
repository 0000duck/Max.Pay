using MongoDB.Bson;
using MongoDB.Driver;
using Max.Framework;
using Max.Framework.MongoDb;
using Max.Framework.NoSql;
using Max.Web.Management.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Max.Web.Management.Infrastructure.Razor;
using Max.Web.Management.Infrastructure;
using Max.Framework.DAL;
using Max.Service.Auth.Common;

namespace Max.Web.Management.Controllers
{
    public class MongoController : BaseController
    {
        private IMongoProxy mongo;

        public MongoController(IMongoProxy mongo)
        {
            this.mongo = mongo;
        }

        #region Mongo缓存查询

        [HttpGet]
        [Permission(PermCode.Mongo缓存查询)]
        public ActionResult Index()
        {
            List<string> Database = ListDatabases();
            ViewBag.ListDatabases = Database;

            return DefaultView();
        }

        [HttpPost]
        [Permission(PermCode.Mongo缓存查询)]
        public ActionResult Index(Query<object, MongoParams> query)
        {
            if (string.IsNullOrEmpty(query.Params.collection) || string.IsNullOrEmpty(query.Params.database))
                return DefaultView();
            PageList<object> pagelist = mongo.PageListAsync(query.Params.database, query.Params.collection, query.Params.json, "", query.__pageIndex, query.__pageSize).Result;
            pagelist.UpdateQuery(query);
            return PageView(query);
        }

        #endregion

        #region ApiLog缓存查询

        [HttpGet]
        public ActionResult ApiLog()
        {
            List<string> Database = ListDatabases("Api");
            ViewBag.ListDatabases = Database;
            return DefaultApiLogView();
        }

        [HttpPost]
        [Permission(PermCode.Mongo缓存查询)]
        public ActionResult ApiLog(Query<ApiLogModel, MongoApiLogParams> query)
        {
            if (string.IsNullOrEmpty(query.Params.collection) || string.IsNullOrEmpty(query.Params.database))
                return DefaultView();

            #region 搜索条件
            Expression<Func<ApiLogModel, bool>> predicate = (ApiLogModel t) => true;
            if (!string.IsNullOrEmpty(query.Params.UserId))
                predicate = predicate.And(m => m.UserData.UserId.Contains(query.Params.UserId));
            if (!string.IsNullOrEmpty(query.Params.IDCard))
                predicate = predicate.And(m => m.UserData.IDCard.Contains(query.Params.IDCard));
            if (!string.IsNullOrEmpty(query.Params.Mobile))
                predicate = predicate.And(m => m.UserData.Mobile.Contains(query.Params.Mobile));
            if (!string.IsNullOrEmpty(query.Params.NickName))
                predicate = predicate.And(m => m.UserData.NickName.Contains(query.Params.NickName));
            if (!string.IsNullOrEmpty(query.Params.RealName))
                predicate = predicate.And(m => m.UserData.RealName.Contains(query.Params.RealName));
            if (!string.IsNullOrEmpty(query.Params.EPlusAccountId))
                predicate = predicate.And(m => m.UserData.EPlusAccountId.Contains(query.Params.EPlusAccountId));
            if (!string.IsNullOrEmpty(query.Params.InstitutionNo))
                predicate = predicate.And(m => m.UserData.InstitutionNo.Contains(query.Params.InstitutionNo));
            if (query.Params.Duration != null)
            {
                if (query.Params.GreaterThanLess == 1)
                    predicate = predicate.And(m => m.Duration > query.Params.Duration);
                else
                    predicate = predicate.And(m => m.Duration < query.Params.Duration);
            }
            if (query.Params.IsError.HasValue)
            {
                var isError = query.Params.IsError == 1;
                predicate = predicate.And(m => m.IsError == isError);
            }
            if (query.Params.LogTimeStart != null)
                predicate = predicate.And(m => m.LogTime >= query.Params.LogTimeStart);
            if (query.Params.LogTimeEnd != null)
                predicate = predicate.And(m => m.LogTime <= query.Params.LogTimeEnd);

            #endregion

            PageList<ApiLogModel> list = mongo.PageListAsync<ApiLogModel>(query.Params.database, query.Params.collection, predicate, query.__pageIndex, query.__pageSize, a => a.LogTime, true).Result;
            list.UpdateQuery(query);
            return PageView(query);
        }

        [ValidateInput(false)]
        public ActionResult ApiLogDetails(ApiLogModel model)
        {
            return View(model);
        }

        #endregion

        #region Mongo缓存删除

        [HttpGet]
        public ActionResult dblist()
        {
            var database = ListDatabasesInfo();
            return View(database);
        }
        [HttpPost]
        [Permission(PermCode.Mongo缓存清除)]
        public ActionResult DeleteDBForAjax(string dbname)
        {
            mongo.DropDatabase(dbname);
            return Json(new ServiceResult() { ResultCode = 0, Message = "删除成功" });
        }

        #endregion

        #region 内部方法

        [NonAction]
        public ActionResult DefaultApiLogView()
        {
            Query<ApiLogModel, MongoApiLogParams> query = new Query<ApiLogModel, MongoApiLogParams>();
            query.ItemList = null;
            query.__totalRecord = 0;
            query.__totalPage = 0;
            return PageView(query);
        }

        [NonAction]
        public ActionResult DefaultView()
        {
            Query<object, MongoParams> query = new Query<object, MongoParams>();
            query.ItemList = null;
            query.__totalRecord = 0;
            query.__totalPage = 0;
            return PageView(query);
        }

        public List<MongoDatabaseModel> ListDatabasesInfo()
        {
            List<MongoDatabaseModel> Databases = new List<MongoDatabaseModel>();
            foreach (var db in mongo.ListDatabase())
            {
                Databases.Add(db.FromJson<MongoDatabaseModel>());
            }
            return Databases;
        }

        public List<string> ListDatabases(string StartWithStr = "")
        {
            List<string> Databases = new List<string>();
            foreach (var db in mongo.ListDatabase())
            {
                var name = db.FromJson<MongoDatabaseModel>().name;
                if (StartWithStr != "")
                {
                    if (name.IndexOf(StartWithStr) == 0)
                        Databases.Add(name);
                }
                else
                {
                    Databases.Add(name);
                }
            }
            return Databases;
        }

        [HttpPost]
        public ActionResult ListConnectionsForAjax(string database)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            List<string> Collections = new List<string>();

            foreach (var collection in mongo.ListConnections(database))
            {
                Collections.Add(collection.FromJson<MongoCollectionModel>().name);
            }
            return Json(Collections);
        }

        #endregion
        
    }
}