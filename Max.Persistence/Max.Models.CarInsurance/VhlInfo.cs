/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.CarInsurance
{
    public class VhlInfo 
    {

        /// <summary>
        /// 标编号
        /// </summary>
        [Key]
        [Required]
        [CharacterLength(36)]
        [Display(Name="标编号")]
        public string VhlId{ get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Required]
        [CharacterLength(36)]
        [Display(Name="订单编号")]
        public string OrderId{ get; set; }

        /// <summary>
        /// 车架号/VIN码
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="车架号/VIN码")]
        public string VhlFrm{ get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="发动机号")]
        public string EngNO{ get; set; }

        /// <summary>
        /// 厂牌车型名称
        /// </summary>
        [StringLength(50)]
        [Display(Name="厂牌车型名称")]
        public string BranName{ get; set; }

        /// <summary>
        /// 初次登记日期
        /// </summary>
        [Display(Name="初次登记日期")]
        public DateTime? FristRegTime{ get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="车辆类型")]
        public string VhlType{ get; set; }

        /// <summary>
        /// 行驶证车辆类型
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="行驶证车辆类型")]
        public string VhlDesc{ get; set; }

        /// <summary>
        /// 号牌种类
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="号牌种类")]
        public string VehicleType{ get; set; }

        /// <summary>
        /// 所属性质
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="所属性质")]
        public string BelongType{ get; set; }

        /// <summary>
        /// 使用性质
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="使用性质")]
        public string UseType{ get; set; }

        /// <summary>
        /// 核定载客数
        /// </summary>
        [Required]
        [Display(Name="核定载客数")]
        public int SetNum{ get; set; }

        /// <summary>
        /// 排气量
        /// </summary>
        [CharacterLength(10)]
        [Display(Name="排气量")]
        public string ExtMsr{ get; set; }

        /// <summary>
        /// 车身颜色
        /// </summary>
        [StringLength(20)]
        [Display(Name="车身颜色")]
        public string Color{ get; set; }

        /// <summary>
        /// 吨位数
        /// </summary>
        [CharacterLength(10)]
        [Display(Name="吨位数")]
        public string Tonnage{ get; set; }

        /// <summary>
        /// 功率
        /// </summary>
        [CharacterLength(10)]
        [Display(Name="功率")]
        public string Power{ get; set; }

        /// <summary>
        /// 转移登记日期
        /// </summary>
        [Display(Name="转移登记日期")]
        public DateTime? TransferDate{ get; set; }

        /// <summary>
        /// 车型代码(全国通用)
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="车型代码(全国通用)")]
        public string ShVhlCode{ get; set; }

        /// <summary>
        /// 新车购置价
        /// </summary>
        [Required]
        [Display(Name="新车购置价")]
        public decimal VhlPrice{ get; set; }

        /// <summary>
        /// 车辆实际价值
        /// </summary>
        [Required]
        [Display(Name="车辆实际价值")]
        public decimal ActualValue{ get; set; }

        /// <summary>
        /// 行驶证车主
        /// </summary>
        [StringLength(10)]
        [Display(Name="行驶证车主")]
        public string DrvOwner{ get; set; }

        /// <summary>
        /// 平台车型代码
        /// </summary>
        [CharacterLength(50)]
        [Display(Name="平台车型代码")]
        public string ModelCode{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name="创建时间")]
        public DateTime CreateTime{ get; set; }

    }
}