using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Roles
{

    public class RolePermissionModel
    {
        [Display(Name = "权限列表")]
        public string[] Permissions { get; set; }
        [Display(Name = "角色名称")]
        [StringLength(100)]
        public string RoleName { get; set; }
        [Display(Name = "角色编号")]
        [StringLength(50)]
        public string SystemRoleId { get; set; }
    }
 
}