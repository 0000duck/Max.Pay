using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="请输入用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage="请输入密码")]
        public string Password { get; set; }
    }
}