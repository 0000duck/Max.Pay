using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Max.Models.CarInsurance.Common;

namespace Max.Web.Management.Models.Export
{
    public class ExclAllModel
    {
    }
    public class ExportMenuPerms
    {
        [Display(Name = "菜单名称")]
        public string MenuName { get; set; }
        [Display(Name = "权限名称")]
        public string PermissionName { get; set; }
    }
}


