/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class PayOrder 
    {

        /// <summary>
        /// 系统订单ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(36)]
        [Display(Name="系统订单ID")]
        public string OrderId{ get; set; }

        /// <summary>
        /// 系统订单号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="系统订单号")]
        public string OrderNo{ get; set; }

        /// <summary>
        /// 代理编号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="代理编号")]
        public string AgentNo{ get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户ID")]
        public string MerchantId{ get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户订单号")]
        public string MerchantOrderNo{ get; set; }

        /// <summary>
        /// 商户订单时间
        /// </summary>
        [Required]
        [Display(Name="商户订单时间")]
        public DateTime MerchantOrderTime{ get; set; }

        /// <summary>
        /// 会员信息
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="会员信息")]
        public string MemberInfo{ get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="IP地址")]
        public string Ip{ get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="设备类型")]
        public string DeviceType{ get; set; }

        /// <summary>
        /// 银行信息
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="银行信息")]
        public string BankInfo{ get; set; }

        /// <summary>
        /// 银行编号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="银行编号")]
        public string BankCode{ get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        [Required]
        [CharacterLength(500)]
        [Display(Name="回调地址")]
        public string NotifyUrl{ get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="返回地址")]
        public string ReturnUrl{ get; set; }

        /// <summary>
        /// 预付金额
        /// </summary>
        [Required]
        [Display(Name="预付金额")]
        public decimal PreorderAmount{ get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [Required]
        [Display(Name="订单金额")]
        public decimal OrderAmount{ get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        [StringLength(100)]
        [Display(Name="订单描述")]
        public string OrderDescription{ get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [StringLength(100)]
        [Display(Name="扩展字段")]
        public string ExtendField{ get; set; }

        /// <summary>
        /// 服务产品ID
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="服务产品ID")]
        public string ServiceId{ get; set; }

        /// <summary>
        /// 渠道类型
        /// </summary>
        [Required]
        [Display(Name="渠道类型")]
        public int ChannelType{ get; set; }

        /// <summary>
        /// 渠道ID
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="渠道ID")]
        public string ChannelId{ get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        [Required]
        [CharacterLength(100)]
        [Display(Name="渠道名称")]
        public string ChannelName{ get; set; }

        /// <summary>
        /// 结算模式
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="结算模式")]
        public string SettleMode{ get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        [Display(Name="结算时间")]
        public DateTime? SettleDate{ get; set; }

        /// <summary>
        /// 费率模式
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="费率模式")]
        public string FeeMode{ get; set; }

        /// <summary>
        /// 转账费率
        /// </summary>
        [Required]
        [Display(Name="转账费率")]
        public decimal TransRate{ get; set; }

        /// <summary>
        /// 服务费率
        /// </summary>
        [Required]
        [Display(Name="服务费率")]
        public decimal ServiceRate{ get; set; }

        /// <summary>
        /// costRate
        /// </summary>
        [Required]
        [Display(Name="costRate")]
        public decimal costRate{ get; set; }

        /// <summary>
        /// 转账手续费
        /// </summary>
        [Required]
        [Display(Name="转账手续费")]
        public decimal TransFee{ get; set; }

        /// <summary>
        /// 产品服务手续费
        /// </summary>
        [Required]
        [Display(Name="产品服务手续费")]
        public decimal ServiceFee{ get; set; }

        /// <summary>
        /// costFee
        /// </summary>
        [Required]
        [Display(Name="costFee")]
        public decimal costFee{ get; set; }

        /// <summary>
        /// 实际所得金额(订单金额-手续费)
        /// </summary>
        [Required]
        [Display(Name="实际所得金额(订单金额-手续费)")]
        public decimal TransAmount{ get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        [Required]
        [Display(Name="支付状态")]
        public int PayStatus{ get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        [Display(Name="支付时间")]
        public DateTime? PayTime{ get; set; }

        /// <summary>
        /// 回调状态
        /// </summary>
        [Required]
        [Display(Name="回调状态")]
        public int NotifyStatus{ get; set; }

        /// <summary>
        /// settleToMerchant
        /// </summary>
        [Display(Name="settleToMerchant")]
        public int? settleToMerchant{ get; set; }

        /// <summary>
        /// settleToCustomer
        /// </summary>
        [Display(Name="settleToCustomer")]
        public int? settleToCustomer{ get; set; }

        /// <summary>
        /// 交易记录ID
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="交易记录ID")]
        public string TransactionId{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

        /// <summary>
        /// 回调次数
        /// </summary>
        [Required]
        [Display(Name="回调次数")]
        public int NotifyCount{ get; set; }

        /// <summary>
        /// 回调信息
        /// </summary>
        [StringLength(100)]
        [Display(Name="回调信息")]
        public string NotifyMsg{ get; set; }

        /// <summary>
        /// 查询次数
        /// </summary>
        [Required]
        [Display(Name="查询次数")]
        public int QueryCount{ get; set; }

        /// <summary>
        /// 回调时间
        /// </summary>
        [Display(Name="回调时间")]
        public DateTime? NotifyTime{ get; set; }

    }
}