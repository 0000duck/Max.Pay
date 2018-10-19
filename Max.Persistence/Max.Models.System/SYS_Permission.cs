/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.System
{
    public class SYS_Permission 
    {

        [Key]
        [Required]
          [CharacterLength(36)]
        [Display(Name="PermId")]
        public string PermId{ get; set; }

        [Required]
         [StringLength(64)]
        [Display(Name="PermName")]
        public string PermName{ get; set; }

        [Required]
        [Display(Name="PermCode")]
        public int PermCode{ get; set; }

          [CharacterLength(36)]
        [Display(Name="Controller")]
        public string Controller{ get; set; }

        [Required]
        [Display(Name="SystemId")]
        public int SystemId{ get; set; }

        [Required]
        [Display(Name="Createtime")]
        public DateTime Createtime{ get; set; }

    }
}