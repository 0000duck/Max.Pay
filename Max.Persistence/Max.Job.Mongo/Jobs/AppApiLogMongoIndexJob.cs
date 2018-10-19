using Common.Logging;
using Quartz;
using System;
using Max.Framework;
using Max.Framework.NoSql;

namespace Max.Job.Mongo.Jobs
{
    /// <summary>
    /// 创建AppApi的mongo日志索引
    /// </summary>
    [DisallowConcurrentExecution]
    public class AppApiLogMongoIndexJob : IJob
    {
        private const string INDEX_NAME = "AUTO_LOGTIME_MOBILE";
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AppApiLogMongoIndexJob));
        private IMongoProxy _mongoProxy;

        public AppApiLogMongoIndexJob(IMongoProxy mongoProxy)
        {
            _mongoProxy = mongoProxy;
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.Info(string.Format("开始创建AppApi日志Mongo索引。。。"));

                var dbName = "ApiLog{0}".Fmt(DateTime.Now.ToString("yyyyMM"));

                var connections = _mongoProxy.ListConnections(dbName);

                if (connections != null && connections.Count > 0)
                {
                    foreach (var connection in connections)
                    {
                        var collectionName = connection.FromJson<ConnectionModel>().name;

                        var indexNames = _mongoProxy.GetIndexNames(dbName, collectionName);

                        if (!indexNames.Contains(INDEX_NAME))
                        {
                            _mongoProxy.CreateIndex(dbName, collectionName, INDEX_NAME, "{LogTime:-1, Mobile:1}");
                        }
                    }
                }

                _logger.Info("创建AppApi日志Mongo索引完成");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("创建AppApi日志Mongo索引出错，{0}", ex.Message));
            }
        }
    }

    #region 辅助类
    internal class ConnectionModel
    {
        public string name { get; set; }
        public ConnectionOptions options { get; set; }
    }

    internal class ConnectionOptions
    {
        public bool capped { get; set; }
        public long size { get; set; }
    }
    #endregion
}
