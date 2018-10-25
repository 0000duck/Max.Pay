/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class Settlement 
    {

        /// <summary>
        /// 结算订单ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="结算订单ID")]
        public string OrderId{ get; set; }

        /// <summary>
        /// 结算订单号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="结算订单号")]
        public string OrderNo{ get; set; }

        /// <summary>
        /// 账户ID
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="账户ID")]
        public string AccountId{ get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户号")]
        public string MerchantNo{ get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户订单号")]
        public string MerchantOrderNo{ get; set; }

        /// <summary>
        /// 结算订单金额
        /// </summary>
        [Required]
        [Display(Name="结算订单金额")]
        public decimal OrderAmount{ get; set; }

        /// <summary>
        /// 转账手续费
        /// </summary>
        [Required]
        [Display(Name="转账手续费")]
        public decimal TransFee{ get; set; }

        /// <summary>
        /// 实际转账金额
        /// </summary>
        [Required]
        [Display(Name="实际转账金额")]
        public decimal TransAmount{ get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="账户名称")]
        public string AccountName{ get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="账号")]
        public string AccountNumber{ get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="银行")]
        public string BankName{ get; set; }

        /// <summary>
        /// 银行编码
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="银行编码")]
        public string BankCode{ get; set; }

        /// <summary>
        /// 支行
        /// </summary>
        [CharacterLength(100)]
        [Display(Name="支行")]
        public string BankBranchName{ get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="省份")]
        public string Province{ get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="城市")]
        public string City{ get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="手机号")]
        public string Mobile{ get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [StringLength(100)]
        [Display(Name="扩展字段")]
        public string ExtendField{ get; set; }

        /// <summary>
        /// 结算状态
        /// </summary>
        [Required]
        [Display(Name="结算状态")]
        public int SettleStatus{ get; set; }

        /// <summary>
        /// 查询次数
        /// </summary>
        [Required]
        [Display(Name="查询次数")]
        public int QueryCount{ get; set; }

        /// <summary>
        /// 回调状态
        /// </summary>
        [Required]
        [Display(Name="回调状态")]
        public int CallbackStatus{ get; set; }

        /// <summary>
        /// 回调次数
        /// </summary>
        [Required]
        [Display(Name="回调次数")]
        public int CallbackCount{ get; set; }

        /// <summary>
        /// 回调时间
        /// </summary>
        [Display(Name="回调时间")]
        public DateTime? CallbackTime{ get; set; }

        /// <summary>
        /// 回调信息
        /// </summary>
        [StringLength(100)]
        [Display(Name="回调信息")]
        public string CallbackMsg{ get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="创建人")]
        public string CreateBy{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [Required]
        [Display(Name="审核状态")]
        public int AuditStatus{ get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [Display(Name="审核时间")]
        public DateTime? AuditTime{ get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="审核人")]
        public string AuditBy{ get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="备注")]
        public string Remark{ get; set; }

    }
}