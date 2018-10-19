/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class NotifyRecord 
    {

        /// <summary>
        /// 请求ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="请求ID")]
        public string RequestId{ get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="订单ID")]
        public string OrderId{ get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="订单类型")]
        public string OrderType{ get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        [Required]
        [CharacterLength(500)]
        [Display(Name="回调地址")]
        public string NotifyUrl{ get; set; }

        /// <summary>
        /// 回调内容
        /// </summary>
        [Required]
        [CharacterLength(500)]
        [Display(Name="回调内容")]
        public string NotifyData{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

        /// <summary>
        /// 返回响应信息
        /// </summary>
        [Required]
        [CharacterLength(500)]
        [Display(Name="返回响应信息")]
        public string ResponseMsg{ get; set; }

        /// <summary>
        /// 回调时间
        /// </summary>
        [Required]
        [Display(Name="回调时间")]
        public DateTime NotifyTime{ get; set; }

        /// <summary>
        /// 回调状态
        /// </summary>
        [Required]
        [Display(Name="回调状态")]
        public int Status{ get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [StringLength(1000)]
        [Display(Name="备注信息")]
        public string Remark{ get; set; }

    }
}