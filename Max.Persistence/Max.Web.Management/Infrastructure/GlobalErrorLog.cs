using Max.Framework.NoSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Infrastructure
{
    public class GlobalErrorLog : MongoEntity
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string Message { get; set; }

        public DateTime CreateTime { get; set; }
    }
}