/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class Merchant 
    {

        /// <summary>
        /// 商户id
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户id")]
        public string MerchantId{ get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="商户号")]
        public string MerchantNo{ get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name="商户名称")]
        public string MerchantName{ get; set; }

        /// <summary>
        /// 代理ID
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="代理ID")]
        public string AgentId{ get; set; }

        /// <summary>
        /// 代理编号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="代理编号")]
        public string AgentNo{ get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="电话")]
        public string Mobile{ get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="QQ")]
        public string QQ{ get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="邮箱")]
        public string Email{ get; set; }

        /// <summary>
        /// 商户站点
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="商户站点")]
        public string Website{ get; set; }

        /// <summary>
        /// 商户秘钥
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="商户秘钥")]
        public string Md5Key{ get; set; }

        /// <summary>
        /// 提现密码
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="提现密码")]
        public string WithdrawPwd{ get; set; }

        /// <summary>
        /// 后台IP白名单
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="后台IP白名单")]
        public string BackWhiteIp{ get; set; }

        /// <summary>
        /// Api IP白名单
        /// </summary>
        [CharacterLength(500)]
        [Display(Name="Api IP白名单")]
        public string ApiWhiteIp{ get; set; }

        /// <summary>
        /// 商户状态
        /// </summary>
        [Required]
        [Display(Name="商户状态")]
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

    }
}