/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class Transaction 
    {

        /// <summary>
        /// 交易记录ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="交易记录ID")]
        public string TransactionId{ get; set; }

        /// <summary>
        /// 交易记录类型(支付=1，结算=2)
        /// </summary>
        [Required]
        [Display(Name="交易记录类型(支付=1，结算=2)")]
        public int TransType{ get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [Required]
        [Display(Name="交易金额")]
        public decimal TransAmount{ get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [Required]
        [Display(Name="订单金额")]
        public decimal OrderAmount{ get; set; }

        /// <summary>
        /// 转账手续费
        /// </summary>
        [Required]
        [Display(Name="转账手续费")]
        public decimal TransFee{ get; set; }

        /// <summary>
        /// 产品手续费
        /// </summary>
        [Required]
        [Display(Name="产品手续费")]
        public decimal ServiceFee{ get; set; }

        /// <summary>
        /// costFee
        /// </summary>
        [Required]
        [Display(Name="costFee")]
        public decimal costFee{ get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [CharacterLength(100)]
        [Display(Name="备注")]
        public string Remark{ get; set; }

        /// <summary>
        /// optName
        /// </summary>
        [CharacterLength(100)]
        [Display(Name="optName")]
        public string optName{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

    }
}