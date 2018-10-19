/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class OptLog 
    {

        /// <summary>
        /// 日志ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="日志ID")]
        public string LogId{ get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name="操作人")]
        public string OptName{ get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name="日志类型")]
        public string LogType{ get; set; }

        /// <summary>
        /// Ip地址
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="Ip地址")]
        public string Ip{ get; set; }

        /// <summary>
        /// 操作对象ID
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="操作对象ID")]
        public string OptObjectId{ get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Required]
        [StringLength(1000)]
        [Display(Name="日志内容")]
        public string LogContent{ get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        [Required]
        [Display(Name="日志时间")]
        public DateTime LogTime{ get; set; }

    }
}