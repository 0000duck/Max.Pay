using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Log
{
    public class LogParams
    {
        public DateTime? CreatedAtStart { get; set; }
        public DateTime? CreatedAtEnd { get; set; }
        public string UserName { get; set; }
        public int? LogSubType { get; set; }
        public int? LogType { get; set; }
    }
}