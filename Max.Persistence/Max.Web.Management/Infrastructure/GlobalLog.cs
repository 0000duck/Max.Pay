using Max.Framework.NoSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Infrastructure
{
    public class GlobalLog : MongoEntity
    {
        /// <summary>
        /// 执行时间
        /// </summary>
        public int ExecTime { get; set; }

        /// <summary>
        /// 渲染时间
        /// </summary>
        public int RenderTime { get; set; }

        public string LocalIP { get; set; }

        public string Url { get; set; }

    }
}