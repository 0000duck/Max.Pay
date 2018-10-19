using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string SystemUserId { get; set; }

        [Required]
        [Display(Name="原密码")]
        [StringLength(20, MinimumLength=5)]
        public string Password { get; set; }

        [Required]
        [Display(Name="新密码")]
        [StringLength(20, MinimumLength=5)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name="确认密码")]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}