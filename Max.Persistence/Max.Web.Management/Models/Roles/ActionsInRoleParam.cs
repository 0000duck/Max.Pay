using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Roles
{
    public class ActionsInRoleParam
    {
        [Required]
        public string RoleId { get; set; }
        public string ActionIds { get; set; }
        public string PermCodes { get; set; }
        public int SystemId { get; set; }
    }
}