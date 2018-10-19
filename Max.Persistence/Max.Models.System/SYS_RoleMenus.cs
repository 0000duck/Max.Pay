/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_RoleMenus 
    {

        /// <summary>
        /// 角色编号
        /// </summary>
        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="角色编号")]
        public string RoleId{ get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="菜单编号")]
        public string ActionId{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

    }
}