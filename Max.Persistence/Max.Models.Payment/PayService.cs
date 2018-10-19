/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class PayService 
    {

        /// <summary>
        /// 产品ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="产品ID")]
        public string ServiceId{ get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="产品类型")]
        public string ServiceType{ get; set; }

        /// <summary>
        /// 产品代码
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="产品代码")]
        public string ServiceCode{ get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="产品名称")]
        public string ServiceName{ get; set; }

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