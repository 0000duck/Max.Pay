/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_PermissionGroup 
    {

        /// <summary>
        /// 权限组编号
        /// </summary>
        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="权限组编号")]
        public string GroupId{ get; set; }

        /// <summary>
        /// 权限组名称
        /// </summary>
        [Required]
         [StringLength(50)]
        [Display(Name="权限组名称")]
        public string GroupName{ get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        [Display(Name="权限列表")]
        public string Permissions{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

    }
}