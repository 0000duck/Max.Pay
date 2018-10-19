using Max.Models.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Account
{
    public class ListParams
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public int? UserType { get; set; }
        public int? UserStatus { get; set; }
        public DateTime? CreateTimeStart { get; set; }
        public DateTime? CreateTimeEnd { get; set; }
    }
}