/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_ActionPerms 
    {

        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="ActionId")]
        public string ActionId{ get; set; }

          [CharacterLength(1024)]
        [Display(Name="PermCode")]
        public string PermCode{ get; set; }

        [Required]
        [Display(Name="CreateTime")]
        public DateTime CreateTime{ get; set; }

    }
}