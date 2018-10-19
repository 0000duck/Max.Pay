using Max.Web.OpenApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Business.Request
{
    public class Request20001 : BaseRequest
    {
        /// <summary>
        /// 报文头Head
        /// </summary>
        public ReqHead Head { get; set; }
        /// <summary>
        /// 报文体
        /// </summary>
        public ReqBody Body { get; set; }
 
    }

    #region 报文头
    /// <summary>
    /// 报文头Head
    /// </summary>
    public class ReqHead
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string BusiCode { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 下单渠道
        /// </summary>
        public string ChannelType { get; set; }
        /// <summary>
        /// 接口编码
        /// </summary>
        public string Cmd { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public string ReqTime { get; set; }
    }
    #endregion

    #region 报文体
    /// <summary>
    /// 报文体
    /// </summary>
    public class ReqBody
    {
        /// <summary>
        /// 订单信息
        /// </summary>
        public ReqOrder OrderInfo { get; set; }
        /// <summary>
        /// 付款人信息
        /// </summary>
        public ReqPayer PayerInfo { get; set; }
        /// <summary>
        /// 投保单信息
        /// </summary>
        public ReqProduct Product { get; set; }
    }
    #endregion

    #region 订单信息
    /// <summary>
    /// 订单信息Body:OrderInfo
    /// </summary>
    public class ReqOrder
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public string OrderAmount { get; set; }
        /// <summary>
        /// 渠道类型
        /// </summary>
        public string ChannelType { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string ChannelName { get; set; }
        /// <summary>
        /// 推荐人信息
        /// </summary>
        public string RecommendInfo { get; set; }
    }
    #endregion

    #region 付款人信息
    /// <summary>
    /// 付款人信息Body:PayerInfo
    /// </summary>
    public class ReqPayer
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertNo { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }
    }
    #endregion

    #region 商品信息
    /// <summary>
    /// 商品信息（投保单信息）
    /// </summary>
    public class ReqProduct
    {
        /// <summary>
        /// 投保人/被保人/车主 详细信息
        /// </summary>
        public List<ReqUser> UserList { get; set; }
        /// <summary>
        /// 收件信息
        /// </summary>
        public ReqRecipients Recipients { get; set; }
        /// <summary>
        /// 车辆信息
        /// </summary>
        public ReqCarInfo CarInfo { get; set; }
        /// <summary>
        /// 投保单（交强险、商业险）基本信息
        /// </summary>
        public List<ReqBICI> BasicInsuranceList { get; set; }
        /// <summary>
        /// 商业险详细信息
        /// </summary>
        public List<ReqCoverage> CoverageInfoList { get; set; }
        /// <summary>
        /// 车船税基本信息
        /// </summary>
        public ReqTaxInfo TaxInfo { get; set; }
    }
    #endregion

    #region 投保人/被保人/车主信息
    /// <summary>
    /// 投保人/被保人/车主 详细信息
    /// </summary>
    public class ReqUser
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertNo { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }
    }
    #endregion

    #region 配送信息

    /// <summary>
    /// 收件信息Recipients
    /// </summary>
    public class ReqRecipients
    {
        /// <summary>
        /// 收件地址
        /// </summary>
        public string RecipientsAddress { get; set; }
        /// <summary>
        /// 收件人名称
        /// </summary>
        public string RecipientsName { get; set; }
        /// <summary>
        /// 收件人电话
        /// </summary>
        public string RecipientsTel { get; set; }
    }
    #endregion

    #region 车辆信息
    /// <summary>
    /// 车辆信息CarInfo
    /// </summary>
    public class ReqCarInfo
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        public string RackNo { get; set; }
        /// <summary>
        /// 车型代码
        /// </summary>
        public string VehicleCode { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string VehicleName { get; set; }
        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNo { get; set; }
        /// <summary>
        /// 是否上牌
        /// </summary>
        public string IsLisence { get; set; }
        /// <summary>
        /// 行使城市
        /// </summary>
        public string DriverArea { get; set; }
        /// <summary>
        /// 是否过户
        /// </summary>
        public string IsTransferCar { get; set; }
        /// <summary>
        /// 过户日期
        /// </summary>
        public string TransferDate { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegisterData { get; set; }
        /// <summary>
        /// 行使城市代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 车辆年份
        /// </summary>
        public string CarMakerYear { get; set; }
        /// <summary>
        /// 新车购置价
        /// </summary>
        public string CarPrice { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        public string CarSetNum { get; set; }
        /// <summary>
        /// 整车质量
        /// </summary>
        public string CarQuality { get; set; }
        /// <summary>
        /// 排量
        /// </summary>
        public string CarDisplacement { get; set; }
        /// <summary>
        /// 制造厂商
        /// </summary>
        public string CarMaker { get; set; }
        /// <summary>
        /// 车辆描述
        /// </summary>
        public string CarRemark { get; set; }
    }
    #endregion

    #region 交商险基本信息
    /// <summary>
    /// 投保单（交强险、商业险）基本信息BasicInsuranceList
    /// </summary>
    public class ReqBICI
    {
        /// <summary>
        /// 保险类型
        /// </summary>
        public string InsuranceType { get; set; }
        /// <summary>
        /// 商业查询码
        /// </summary>
        public string QuerySequeceNo { get; set; }
        /// <summary>
        /// 保险起期
        /// </summary>
        public string InsrncBeginTime { get; set; }
        /// <summary>
        /// 保险止期
        /// </summary>
        public string InsrncEndTime { get; set; }
        /// <summary>
        /// 投保单号
        /// </summary>
        public string PlyAppNo { get; set; }
        /// <summary>
        /// 投保时间
        /// </summary>
        public string AppTime { get; set; }
        /// <summary>
        /// 核保状态
        /// </summary>
        public string UdrMark { get; set; }
        /// <summary>
        /// 是否交商同保
        /// </summary>
        public string JsFlag { get; set; }
        /// <summary>
        /// 保额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 保费
        /// </summary>
        public string Premium { get; set; }
        /// <summary>
        /// 报价单号
        /// </summary>
        public string CalAppNo { get; set; }
        /// <summary>
        /// 收据流水号
        /// </summary>
        public string ReceiptNo { get; set; }
    }
    #endregion

    #region 商业险详细信息
    /// <summary>
    /// 商业险详细信息CoverageInfoList
    /// </summary>
    public class ReqCoverage
    {
        /// <summary>
        /// 险种代码
        /// </summary>
        public string InsrncCode { get; set; }
        /// <summary>
        /// 保险金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 是否不计免赔
        /// </summary>
        public string FranchiseFlag { get; set; }
        /// <summary>
        /// 不计免赔金额
        /// </summary>
        public string NonDeductibleAmt { get; set; }
        /// <summary>
        /// 不计免赔保费
        /// </summary>
        public string NonDeductiblePremium { get; set; }
        /// <summary>
        /// 费率
        /// </summary>
        public string Rate { get; set; }
        /// <summary>
        /// 基本保费
        /// </summary>
        public string BasePremium { get; set; }
        /// <summary>
        /// 折前保费
        /// </summary>
        public string BeforePremium { get; set; }
        /// <summary>
        /// 应缴保费
        /// </summary>
        public string PayPremium { get; set; }
    }
    #endregion

    #region 车船税信息
    /// <summary>
    /// 车船税基本信息TaxInfo
    /// </summary>
    public class ReqTaxInfo
    {
        /// <summary>
        /// 减免税标识
        /// </summary>
        public string TaxType { get; set; }
        /// <summary>
        /// 滞纳金
        /// </summary>
        public string LateFee { get; set; }
        /// <summary>
        /// 当年应缴
        /// </summary>
        public string CurrentTax { get; set; }
        /// <summary>
        /// 上年应缴
        /// </summary>
        public string FormerTax { get; set; }
        /// <summary>
        /// 合计应缴
        /// </summary>
        public string SumUpTax { get; set; }
        /// <summary>
        /// 减免金额
        /// </summary>
        public string MinusTaxAmt { get; set; }
        /// <summary>
        /// 车辆分类
        /// </summary>
        public string AxVhlType { get; set; }
    }
    #endregion
}