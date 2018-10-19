using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Account
{
    public class AccountAddModel
    {
        [Display(Name = "创建时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        [Display(Name = "邮箱")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "手机号")]
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")] 
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "密码")]
        [StringLength(20)]
        public string Password { get; set; }
       
      
        [Display(Name = "确认密码")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(40)]
        public string RealName { get; set; }

        [Display(Name = "用户状态(0 正常 1 锁定)")]
        [Required]
        public int Status { get; set; }

        //[Display(Name = "用户编号")]
        //[Key]
        //[StringLength(50)]
        //public string SystemUserId { get; set; }

        [Display(Name = "帐号")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "是否超级管理员(0 普通管理员 1 超级管理员)")]
        [Required]
        public int UserType { get; set; }
    }

    public class AccountEditModel
    {
        [Display(Name = "创建时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        [Display(Name = "邮箱")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "手机号")]
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        public string Mobile { get; set; }

   
        [Display(Name = "密码")]
        [StringLength(20)]
        public string Password { get; set; }


        [Display(Name = "确认密码")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(40)]
        public string RealName { get; set; }

        [Display(Name = "用户状态(0 正常 1 锁定)")]
        [Required]
        public int Status { get; set; }

        [Display(Name = "用户编号")]
        [Key]
        [Required]
        [StringLength(50)]
        public string SystemUserId { get; set; }

        [Display(Name = "帐号")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "是否超级管理员(0 普通管理员 1 超级管理员)")]
        [Required]
        public int UserType { get; set; }
    }

    public class AccountRolesModel
    {
        [Display(Name = "用户编号")]
        [Required]
        [StringLength(50)]
        public string SystemUserId { get; set; }

        [Display(Name = "帐号")]
        public string UserName { get; set; }

        [Display(Name = "角色")]
        public string[] Roles { get; set; }


    }

    public class AccountPermsModel
    {
        public int SystemType { get; set; }
        public string RoleName { get; set; }
        public string PermName { get; set; }
        public string PermCode { get; set; }
    }
}