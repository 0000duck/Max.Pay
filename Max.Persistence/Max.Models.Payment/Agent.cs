/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class Agent 
    {

        /// <summary>
        /// 代理ID
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(50)]
        [Display(Name="代理ID")]
        public string AgentId{ get; set; }

        /// <summary>
        /// 代理编号
        /// </summary>
        [Required]
        [CharacterLength(50)]
        [Display(Name="代理编号")]
        public string AgentNo{ get; set; }

        /// <summary>
        /// 代理名称
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name="代理名称")]
        public string AgentName{ get; set; }

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

    }
}