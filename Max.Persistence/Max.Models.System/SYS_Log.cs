/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_Log 
    {

        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="LogId")]
        public string LogId{ get; set; }

        [Required]
        [Display(Name="LogType")]
        public int LogType{ get; set; }

        [Required]
        [Display(Name="Remark")]
        public string Remark{ get; set; }

         [StringLength(64)]
        [Display(Name="CreatedBy")]
        public string CreatedBy{ get; set; }

        [Required]
        [Display(Name="CreateTime")]
        public DateTime CreateTime{ get; set; }

         [StringLength(128)]
        [Display(Name="KeyWord")]
        public string KeyWord{ get; set; }

    }
}