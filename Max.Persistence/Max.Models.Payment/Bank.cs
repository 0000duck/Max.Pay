/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class Bank 
    {

        /// <summary>
        /// 银行ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="银行ID")]
        public string BankId{ get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="银行代码")]
        public string BankCode{ get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="银行名称")]
        public string BankName{ get; set; }

        /// <summary>
        /// 联行号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="联行号")]
        public string SeqNo{ get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [Display(Name="状态")]
        public int Status{ get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        [Display(Name="是否删除")]
        public int Isdelete{ get; set; }

    }
}