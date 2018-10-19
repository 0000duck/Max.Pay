/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_UserRoles 
    {

        /// <summary>
        /// 用户编号
        /// </summary>
        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="用户编号")]
        public string SystemUserId{ get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="角色编号")]
        public string SystemRoleId{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

    }
}