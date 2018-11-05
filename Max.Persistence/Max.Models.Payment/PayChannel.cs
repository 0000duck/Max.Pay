/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class PayChannel 
    {

        /// <summary>
        /// 支付渠道ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="支付渠道ID")]
        public string ChannelId{ get; set; }

        /// <summary>
        /// 支付渠道类型
        /// </summary>
        [Required]
        [Display(Name="支付渠道类型")]
        public int ChannelType{ get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        [Required]
        [CharacterLength(100)]
        [Display(Name="渠道名称")]
        public string ChannelName{ get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户号")]
        public string MerchantNo{ get; set; }

        /// <summary>
        /// 商户秘钥
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="商户秘钥")]
        public string MerchantKey{ get; set; }

        /// <summary>
        /// 商户信息
        /// </summary>
        [CharacterLength(100)]
        [Display(Name="商户信息")]
        public string MerchantInfo{ get; set; }

        /// <summary>
        /// 支付站点
        /// </summary>
        [Required]
        [CharacterLength(500)]
        [Display(Name="支付站点")]
        public string PaySite{ get; set; }

        /// <summary>
        /// 最小支付金额
        /// </summary>
        [Required]
        [Display(Name="最小支付金额")]
        public decimal MinOrderAmount{ get; set; }

        /// <summary>
        /// 最大支付金额
        /// </summary>
        [Required]
        [Display(Name="最大支付金额")]
        public decimal MaxOrderAmount{ get; set; }

        /// <summary>
        /// 结算模式
        /// </summary>
        [Required]
        [Display(Name="结算模式")]
        public int SettleMode{ get; set; }

        /// <summary>
        /// 手续费率
        /// </summary>
        [Required]
        [Display(Name="手续费率")]
        public decimal FeeRate{ get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [Display(Name="状态")]
        public int Status{ get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="备注")]
        public string Remark{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="创建人")]
        public string CreateBy{ get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name="更新时间")]
        public DateTime? UpdateTime{ get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="更新人")]
        public string UpdateBy{ get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        [Display(Name="是否删除")]
        public int Isdelete{ get; set; }

        [Required]
        [CharacterLength(50)]
        [Display(Name="ChannelCode")]
        public string ChannelCode{ get; set; }

    }
}