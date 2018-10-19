/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_User 
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
        /// 帐号
        /// </summary>
        [Required]
          [CharacterLength(30)]
        [Display(Name="帐号")]
        public string UserName{ get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
          [CharacterLength(250)]
        [Display(Name="密码")]
        public string Password{ get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
         [StringLength(20)]
        [Display(Name="姓名")]
        public string RealName{ get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
          [CharacterLength(50)]
        [Display(Name="邮箱")]
        public string Email{ get; set; }

        /// <summary>
        /// 是否超级管理员(0 普通管理员 1 超级管理员)
        /// </summary>
        [Required]
        [Display(Name="是否超级管理员(0 普通管理员 1 超级管理员)")]
        public int UserType{ get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
          [CharacterLength(20)]
        [Display(Name="手机号")]
        public string Mobile{ get; set; }

        /// <summary>
        /// 用户状态(0 正常 1 锁定)
        /// </summary>
        [Required]
        [Display(Name="用户状态(0 正常 1 锁定)")]
        public int Status{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

    }
}