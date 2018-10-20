/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class MerchantBankAccount 
    {

        /// <summary>
        /// 账户id
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="账户id")]
        public string AccountId{ get; set; }

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
        /// 身份证号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="身份证号")]
        public string IdCardNo{ get; set; }

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
        [Display(Name="MerchantId")]
        public string MerchantId{ get; set; }

    }
}