using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Roles
{
    public class RoleParams
    {
        public string RoleName { get; set; }
    }
    public class RoleUsersParams
    {
        public string UserName { get; set; }
    }
    public class LogParams
    {
        public string Keyword { get; set; }
        public string CreatedBy { get; set; }
        public int? LogType { get; set; }
        public DateTime? CreateTimeStart { get; set; }
        public DateTime? CreateTimeEnd { get; set; }
    }
}