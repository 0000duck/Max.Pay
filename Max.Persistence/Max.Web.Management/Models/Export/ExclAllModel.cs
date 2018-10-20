using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Max.Models.Payment.Common;

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

    public class ExportBank
    {
        [Display(Name = "银行名称")]
        public string BankName { get; set; }
        [Display(Name = "银行代码")]
        public string BankCode { get; set; }
        [Display(Name = "联行号")]
        public string SeqNo { get; set; }
    }

    public class ExportMerchant
    {
        [Display(Name = "商户名称")]
        public string MerchantName { get; set; }
        [Display(Name = "商户号")]
        public string MerchantNo { get; set; }
        [Display(Name = "代理")]
        public string AgentNo { get; set; }
        [Display(Name = "电话")]
        public string Mobile { get; set; }
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        [Display(Name = "QQ")]
        public string QQ { get; set; }
        [Display(Name = "创建时间")]
        public string CreateTime { get; set; }

    }
}


