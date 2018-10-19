using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.OpenApi.Models.OpenApiModels
{
    /// <summary>
    /// 进件申请
    /// </summary>
    public class CarLoanCreateOrderRequest
    {
        /// <summary>
        /// 进件类型 0为新进件、1为重新上传
        /// </summary>
        [Required]
        public int IncomingType { get; set; }

        /// <summary>
        /// 钱端订单号，提交进件申请通过后由钱端系统返回，如进件类型为重新上传时，需上传钱端订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 推荐码，代理商渠道需返回推荐码，作为佣金结算的商户识别和订单渠道识别，如缺少推荐码则无需生成推广单，无需进行佣金结算。
        /// </summary>
        public string RecommandCode { get; set; }

        /// <summary>
        /// 商品信息，用户所购买的商品描述信息
        /// </summary>
        [Required]
        public string ProductInfo { get; set; }

        /// <summary>
        /// 原始订单号，由安邦系统生成本次进件申请的唯一标识
        /// </summary>
        [Required]
        public string ApplyNo { get; set; }

        /// <summary>
        /// 贷款人姓名，发起贷款的申请人姓名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 贷款人证件类型 int Y   贷款人的证件类型 1身份证
        /// </summary>
        [Required]
        public int CertType { get; set; }

        /// <summary>
        /// 贷款认证件号码 varchar(18) Y 贷款人的证件号
        /// </summary>
        [Required]
        public string CertNo { get; set; }

        /// <summary>
        /// 贷款人手机号  varchar(11) Y 发起贷款申请人手机号
        /// </summary>
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// 合同签署时间  datetime Y   用户签署融租租赁合同的时间
        /// </summary>
        [Required]
        public DateTime ContractSignedAt { get; set; }

        /// <summary>
        /// 融资租赁合同编号 Y   融租租赁合同递件编号，如现系统支持生成电子合同，编号需对应电子合同编号
        /// </summary>
        [Required]
        public string FinanceContractNo { get; set; }

        /// <summary>
        /// 抵押合同编号 Y   抵押合同递件编号，如现系统支持生成电子合同，编号需对应电子合同编号
        /// </summary>
        [Required]
        public string MortgageContractNo { get; set; }

        /// <summary>
        /// 资产转让清单编号 varchar(36) Y 递件编号，如现系统支持生成电子合同，编号需对应电子合同编号
        /// </summary>
        [Required]
        public string ProtocolNo { get; set; }

        /// <summary>
        /// 保单号 varchar(36) Y 履约保险单递件编号，如现系统支持生成电子合同，编号需对应电子合同编号
        /// </summary>
        [Required]
        public string PolicyNo { get; set; }

        /// <summary>
        /// 保费金额 decimal Y   履约保险单保险费
        /// </summary>
        [Required]
        public decimal InsuranceAmount { get; set; }

        /// <summary>
        /// 订单总额 decimal Y   商品总额（车辆总价）
        /// </summary>
        [Required]
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 首付金额    decimal Y   用户已支付的首付款，需对应首付款凭证
        /// </summary>
        [Required]
        public decimal FirstPaymentAmount { get; set; }

        /// <summary>
        /// 贷款金额 decimal Y   用户所需借款本金
        /// </summary>
        [Required]
        public decimal LoanAmount { get; set; }

        /// <summary>
        /// 分期期数 int Y   用户进行还款的期数（12 24 36）
        /// </summary>
        [Required]
        public int SplitCount { get; set; }

        /// <summary>
        /// 分期还款费率  decimal Y   用户进行还款的手续费率 单位（%）
        /// </summary>
        [Required]
        public decimal InstallmentRate { get; set; }

        /// <summary>
        /// 计划开始还款日 datetime Y   用户进行还款的起始日，第一笔账单到期日
        /// </summary>
        [Required]
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// 融资租赁公司id varchar(36) N 如线上不提供，依据钱端业务平台保险公司及融资租赁公司对应关系匹配订单融资租赁公司，需与线下提供进行校验；目前安邦保险对应联通租赁
        /// </summary>
        public string FinanceMerchantId { get; set; }

        /// <summary>
        /// 是否为代理商垫资 int N   如为是，则贷款结算商户为如为代理商账户；为否，则贷款结算商户为推荐码对应的经销商结算商户 0否 1是
        /// </summary>
        public int IsLoan { get; set; }

        /// <summary>
        /// 尾款结算商户编号 varchar(36) Y 如为代理商垫资，则尾款结算至代理商，传送代理商商户编号，可无需传送结算账户信息
        /// </summary>
        [Required]
        public string SettlementMerchantNo { get; set; }

        /// <summary>
        /// 尾款结算商户名称 nvarchar(36)    Y 如非代理商垫资，则尾款结算至经销商，需传送结算账户信息
        /// </summary>
        [Required]
        public string SettlementMerchantName { get; set; }

        /// <summary>
        ///  尾款结算账户类型 int Y   目前依据结算通道要求，需区分个人类型和企业类型 1企业 2个人
        /// </summary>
        [Required]
        public int SettlementAccountType { get; set; }

        /// <summary>
        /// 结算开户账户 nvarchar(36)    Y 企业开户户名信息
        /// </summary>
        [Required]
        public string SettlementAccountName { get; set; }

        /// <summary>
        /// 结算账户银行名称    nvarchar(36)    Y 依据支付通道提供标准数据传输，钱端系统作校准
        /// </summary>
        [Required]
        public string SettlementBankName { get; set; }

        /// <summary>
        /// 结算账户银行所在省 nvarchar(36)    Y 依据支付通道提供标准数据传输，钱端系统作校准
        /// </summary>
        [Required]
        public string SettlementBankProvince { get; set; }

        /// <summary>
        /// 结算账户银行所在市 nvarchar(36)    Y 依据支付通道提供标准数据传输，钱端系统作校准
        /// </summary>
        [Required]
        public string SettlementBankCity { get; set; }

        /// <summary>
        /// 结算银行支行名称 nvarchar(48)    Y 依据支付通道提供标准数据传输，钱端系统作校准
        /// </summary>
        [Required]
        public string SettlementBranchBankName { get; set; }

        /// <summary>
        /// 结算账户银行卡号
        /// </summary>
        public string SettlementBankNo { get; set; }

        /// <summary>
        /// 保险公司
        /// </summary>
        public string InsuranceCompany { get; set; }

    }
}
