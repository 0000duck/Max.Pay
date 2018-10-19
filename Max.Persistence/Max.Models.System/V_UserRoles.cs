/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class V_UserRoles 
    {

        public string SystemRoleId{ get; set; }

        public string RoleName{ get; set; }

        public DateTime CreateTime{ get; set; }

        public string Permissions{ get; set; }

        public int RoleStatus{ get; set; }

        public string SystemUserId{ get; set; }

        public string UserName{ get; set; }

        public string RealName{ get; set; }

        public string Email{ get; set; }

        public int UserType{ get; set; }

        public string Mobile{ get; set; }

        public int UserStatus{ get; set; }

    }
}