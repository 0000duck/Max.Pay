/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_Action 
    {

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="菜单编号")]
        public string ActionId{ get; set; }

        /// <summary>
        /// 父菜单
        /// </summary>
          [CharacterLength(36)]
        [Display(Name="父菜单")]
        public string ParentId{ get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
         [StringLength(50)]
        [Display(Name="菜单名称")]
        public string ActionName{ get; set; }

        /// <summary>
        /// 页面地址
        /// </summary>
        [Required]
          [CharacterLength(250)]
        [Display(Name="页面地址")]
        public string Url{ get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
          [CharacterLength(50)]
        [Display(Name="菜单图标")]
        public string IconClass{ get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        [Display(Name="排序")]
        public int Sort{ get; set; }

        /// <summary>
        /// 分级排序
        /// </summary>
        [Required]
          [CharacterLength(500)]
        [Display(Name="分级排序")]
        public string LevelSort{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

        [Required]
        [Display(Name="SystemId")]
        public int SystemId{ get; set; }

    }
}