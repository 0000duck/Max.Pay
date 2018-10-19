using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Roles
{
    public class RoleActionsModel
    {
        public string ActionId { get; set; }

        public string ParentId { get; set; }

        public string ActionName { get; set; }

        public string Url { get; set; }

        public string IconClass { get; set; }

        public bool IsAssigned { get; set; }
    }
}