using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Models.CarInsurance.Common
{
    public class Enums
    {

        /// <summary>
        /// 保单支付状态
        /// </summary>
        public enum InsuranceOrderPayStaus
        {
            待支付 = 0,
            支付成功 = 1,
            支付失败 = 2
        }

        /// <summary>
        /// 支付申请号获取状态
        /// </summary>
        public enum PayApplyNoStatus
        {
            未获取 = 0,
            获取成功 = 1,
            获取失败 = 2
        }

        /// <summary>
        /// 订单来源
        /// </summary>
        public enum OrderSourceType
        {
            钱端APP = 1,
            渠道 = 2,
            保险公司 = 3
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public enum OrderStatus
        {
            待支付 = 0,
            处理中 = 1,
            交易成功 = 2,
            交易失败 = 3,
            已取消订单 = 4
        }

        /// <summary>
        /// 撤单状态
        /// </summary>
        public enum RevokeStatus
        {
            无申请 = 0,
            撤单成功 = 1,
            撤单失败 = 2
        }

        /// <summary>
        /// app端展示保单状态
        /// </summary>
        public enum AppPlyStatus
        {
            未生效 = 0,
            生效中 = 1,
            已到期 = 2,
            已撤单 = 3,
            未知 = 4

        }

        /// <summary>
        /// 保险类型
        /// </summary>
        public enum InsuranceType
        {
            商业险 = 1,
            交强险 = 2,
            交商同保 = 3
        }


        /// <summary>
        /// 账单类型
        /// </summary>
        public enum BillType
        {
            综合 = 0,
            本金 = 1,
            手续费 = 2,
            利息 = 3
        }

        /// <summary>
        /// 支付渠道
        /// </summary>
        public enum PayChannel
        {
            摇钱宝支付 = 1,
            中金支付 = 2
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public enum PayType
        {
            银行卡 = 1
        }

        /// <summary>
        /// 支付状态
        /// </summary>
        public enum PayStatus
        {
            //未支付 = 0,
            //处理中 = 1,
            //支付到E家成功 = 2,
            //支付到银行卡成功 = 3,
            //支付失败 = 4,
            未支付 = 0,
            处理中 = 1,
            支付成功 = 2,
            支付失败 = 3

        }

        /// <summary>
        /// 还款状态
        /// </summary>
        public enum RePayStatus
        {
            待还款 = 0,
            已还款 = 1,
            还款中 = 2,
            还款失败 = 3,
            宽限期内逾期 = 4,
            宽限期外逾期 = 5,
            退保关闭 = 6,
            退保处理中 = 7
        }


        /// <summary>
        /// 还款方式
        /// </summary>
        public enum RePayType
        {
            自动还款 = 1,
            手动还款 = 2
        }


        /// <summary>
        /// 支付日志类型
        /// </summary>
        public enum PayLogType
        {
            订单支付 = 1,
            订单支付EPlus回调 = 2,
            订单支付银行卡回调 = 3,
            自动还款 = 4,
            自动还款回调 = 5,
            保费结算支付 = 6,
            保费结算EPlus回调 = 7,
            保费结算银行卡回调 = 8,
            退保结算支付 = 9,
            退保结算EPlus回调 = 10,
            退保结算银行卡回调 = 11,
            划扣车险账单金额 = 12,
            划扣车险账单金额回调 = 13,
            退保扫描 = 14,
            退保代收 = 15,
            退保代收回调 = 16,
            推荐人修改 = 20,
            华安配送信息发送 = 21,
            自动取消订单 = 22,
            华安FTP对账 = 23,
            阳光保单出单 = 31,
            阳光保单查询 = 32,
            阳光人工核保回调 = 40,
            自动垫资核算 = 41,
            自动垫资结算 = 42,
            自动保费核算 = 43,
            自动保费结算 = 44,
            获取中金结算流水 = 45,
            支付回调超时 = 46,
            获取中金结算流水超时 = 47,
            保费核算超时提醒 = 48,
            保费结算超时提醒 = 49,
            主动还款 = 50,
            更换银行卡 = 51,
            订单新用户关联 = 52,
            账单编辑 = 53,
            中金绑卡 = 54
        }

        /// <summary>
        /// 支付日志操作类型
        /// </summary>
        public enum LogOperaType
        {
            添加 = 1,
            修改 = 2,
            支付 = 3,
            回调 = 4,
            还款 = 5,
            划扣 = 6,
            代收 = 7
        }

        public enum AddOrEdit
        {
            添加 = 0,
            编辑 = 1
        }

        /// <summary>
        /// 证件类型
        /// </summary>
        public enum CertType
        {
            身份证 = 1
            //户口簿 = 2,
            //护照 = 3,
            //军官证士兵证 = 4,
            //港澳居民来往内地通行证 = 5,
            //台湾同胞来往内地通行证 = 6,
            //临时身份证 = 7,
            //外国人居留证 = 8,
            //警官证 = 9,
            //其他证件 = 10
        }

        /// <summary>
        /// 是否支持投保
        /// </summary>
        public enum IsSupportAreaEnable
        {
            是 = 1,
            否 = 0

        }

        /// <summary>
        /// 类型配置项便于树形控件选择所属类型
        /// </summary>
        public enum TreeNodesSelectType
        {
            支持投保 = 1,
            提前续保天数 = 2
        }
        /// <summary>
        /// 地址选择级别
        /// </summary>
        public enum AreaLevel
        {
            国家 = 0,
            省 = 1,
            市 = 2,
            区 = 3
        }

        /// <summary>
        /// 是否支持新商车
        /// </summary>
        public enum IsNewCar
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 通用是否枚举
        /// </summary>
        public enum YesOrNo
        {
            是 = 1,
            否 = 0
        }
        /// <summary>
        /// 订单操作日志
        /// </summary>
        public enum OrderLogType
        {
            订单生成 = 1,
            自动取消订单 = 2,
            手动取消订单 = 3,
            订单支付 = 4,
            订单支付回调 = 5,
            临时订单生成 = 6,
            订单补录审核 = 7
        }

        #region 投保险种

        /// <summary>
        /// 车辆损失险
        /// </summary>
        public enum CarLossEnum
        {
            不投保 = 0,
            投保 = 1
        }

        /// <summary>
        /// 商业第三者责任险
        /// </summary>
        public enum ThirdPartDutyEnum
        {
            不投保 = 0,
            万5 = 5,
            万10 = 10,
            万15 = 15,
            万20 = 20,
            万30 = 30,
            万50 = 50,
            万100 = 100,
            万150 = 150,
            万200 = 200,
            万250 = 250,
            万300 = 300,
            万350 = 350,
            万400 = 400,
            万450 = 450,
            万500 = 500
        }

        /// <summary>
        /// 全车盗抢险
        /// </summary>
        public enum RobberyEnum
        {
            不投保 = 0,
            投保 = 1
        }

        /// <summary>
        /// 司机座位责任险
        /// </summary>
        public enum DriverDutyEnum
        {
            不投保 = 0,
            万1 = 10000,
            万2 = 20000,
            万3 = 30000,
            万4 = 40000,
            万5 = 50000,
            万10 = 100000
        }

        /// <summary>
        /// 乘客座位责任险
        /// </summary>
        public enum PassengerEnum
        {
            不投保 = 0,
            万1 = 10000,
            万2 = 20000,
            万3 = 30000,
            万4 = 40000,
            万5 = 50000,
            万10 = 100000
        }

        /// <summary>
        /// 玻璃单独破碎险
        /// </summary>
        public enum GlassBrokenEnum
        {
            不投保 = 0,
            国产玻璃 = 1,
            进口玻璃 = 2
        }

        /// <summary>
        /// 自燃损失险
        /// </summary>
        public enum AutoignitionEnum
        {
            不投保 = 0,
            投保 = 1
        }

        /// <summary>
        /// 发动机涉水损失险
        /// </summary>
        public enum EngineEnum
        {
            不投保 = 0,
            投保 = 1
        }

        /// <summary>
        /// 修理期间费用补偿险
        /// </summary>
        public enum RepairEnum
        {
            不投保 = 0,
            元100和10天 = 1,
            元200和20天 = 2,
            元300和30天 = 3
        }

        /// <summary>
        /// 精神损失抚慰金责任险
        /// </summary>
        public enum SpiritEnum
        {
            不投保 = 0,
            万1 = 10000,
            万2 = 20000,
            万3 = 30000
        }

        /// <summary>
        /// 无法找到第三方特约险
        /// </summary>
        public enum NoFoundThirdPartEnum
        {
            不投保 = 0,
            投保 = 1
        }

        /// <summary>
        /// 划痕险
        /// </summary>
        public enum ScratchEnum
        {
            不投保 = 0,
            千2 = 2000,
            千5 = 5000,
            万1 = 10000,
            万2 = 20000,
        }
        /// <summary>
        /// 指定修理厂险
        /// </summary>
        public enum DesignatedEnum
        {
            不投保 = 0,
            投保 = 1
        }
        #endregion

        /// <summary>
        /// 是否过户车辆
        /// </summary>
        public enum IsTransferCar
        {
            非过户车辆 = 0,
            过户车辆 = 1
        }

        /// <summary>
        /// 订单支付方式
        /// </summary>
        public enum OrderPayMode
        {
            全额支付 = 1,
            部分支付 = 2
        }


        #region 清结算状态

        /// <summary>
        /// 垫资清算状态
        /// </summary>
        public enum DZClearStatus
        {
            未核算 = 0,
            已核算 = 1
        }
        /// <summary>
        /// 垫资结算状态
        /// </summary>
        public enum DZSettlementStatus
        {
            未结算 = 0,
            已结算 = 1
        }

        /// <summary>
        /// 保费清算状态
        /// </summary>
        public enum BFClearStatus
        {
            未核算 = 0,
            已核算 = 1
        }
        ///// <summary>
        ///// 订单表保费结算状态
        ///// </summary>
        //public enum OrderBFSettlementStatus
        //{
        //    未结算 = 0,
        //    已结算 = 3,
        //    结算处理中 = 2,
        //    结算失败 = 1
        //}

        /// <summary>
        /// 结算表结算状态
        /// </summary>
        public enum BFSettlementStatus
        {
            未结算 = 0,
            已结算 = 3,
            结算处理中 = 2,
            结算失败 = 1
        }

        ///// <summary>
        ///// E+支付状态
        ///// </summary>
        //public enum EPlusPayStatus
        //{
        //    未支付 = 0,
        //    处理中 = 1,
        //    支付成功 = 2,
        //    支付失败 = 3
        //}

        ///// <summary>
        ///// 保费结算支付状态
        ///// </summary>
        //public enum CarBFPayStaus
        //{
        //    未支付 = 0,
        //    处理中 = 1,
        //    支付成功 = 2,
        //    支付失败 = 3,
        //}

        ///// <summary>
        ///// 银行卡支付到账状态
        ///// </summary>
        //public enum BankCardPayStatus
        //{
        //    未支付 = 0,
        //    处理中 = 1,
        //    支付成功 = 2,
        //    支付失败 = 3,
        //}

        /// <summary>
        /// FTP状态
        /// </summary>
        public enum FTPStatus
        {
            未生成 = 0,
            生成成功 = 1,
            生成失败 = 2
        }

        /// <summary>
        /// 对账状态
        /// </summary>
        public enum ReconciliationStatus
        {
            未对账 = 0,
            对账成功 = 1,
            对账失败 = 2
        }

        /// <summary>
        /// 配送状态
        /// </summary>
        public enum DistributionStatus
        {
            未配送 = 0,
            配送成功 = 1,
            配送失败 = 2,
            部分成功 = 3
        }
        #endregion

        #region     分期期数
        public enum SplitCount
        {
            不分期 = 0,
            三期 = 3,
            六期 = 6,
            九期 = 9

        }

        #endregion

        #region 支付状态
        public enum AppPolicyPayStatus
        {
            待支付 = 0,
            全额支付 = 1,
            部分支付 = 2
            //未知 = 3
        }
        #endregion

        #region 日志

        /// <summary>
        /// 保险公司编码
        /// </summary>
        public enum InsuranceCompanyCode
        {
            华安保险 = 1,
            阳光保险 = 2,
            安邦保险 = 3,
            中华联合 = 4
        }

        /// <summary>
        /// 保险接口类型
        /// </summary>
        public enum InterfaceType
        {
            车型查询 = 1,
            折旧查询 = 2,
            保费计算 = 3,
            提交核保 = 4,
            获取支付申请号 = 5,
            配送 = 6,
            保单查询 = 7
        }
        #endregion

        /// <summary>
        /// 车险配置类型
        /// </summary>
        public enum InsuranceConfigType
        {
            逾期天数 = 1,
            佣金 = 2,
            自动清结算 = 3
        }

        /// <summary>
        /// 保险公司保险类型
        /// </summary>
        public enum CompanyInsuranceType
        {
            车险 = 1
        }

        /// <summary>
        /// 退保核算
        /// </summary>
        public enum CarRefundClearStatus
        {
            未核算 = 0,
            已核算 = 1
        }

        /// <summary>
        /// 退保结算
        /// </summary>
        public enum CarRefundSettleStatus
        {
            未结算 = 0,
            结算失败 = 1,
            结算处理中 = 2,
            已结算 = 3
        }

        ///// <summary>
        ///// 退保E+支付状态
        ///// </summary>
        //public enum CarRefundEPlusStatus
        //{
        //    未支付 = 0,
        //    处理中 = 1,
        //    支付成功 = 2,
        //    支付失败 = 3

        //}

        ///// <summary>
        ///// 退保银行卡支付状态
        ///// </summary>
        //public enum CarRefundBankStatus
        //{
        //    未支付 = 0,
        //    处理中 = 1,
        //    支付成功 = 2,
        //    支付失败 = 3
        //}



        /// <summary>
        /// 保单退保终止类型
        /// </summary>
        public enum RefundStopType
        {
            退保 = 1,
            保单终止 = 2
        }

        /// <summary>
        /// 保单退保终止原因类型
        /// </summary>
        public enum RefundStopReasonType
        {
            保单终止=0,
            用户申请 = 1,
            账单逾期退保 = 2
        }
        /// <summary>
        /// 保单退保状态
        /// </summary>
        public enum PolicyRefundStatus
        {
            无申请 = 0,
            待退保 = 1,
            退保处理中 = 2,
            退保成功 = 3,
            退保取消 = 4
        }
        /// <summary>
        /// 保单终止状态
        /// </summary>
        public enum PolicyStopStatus
        {
            无申请 = 0,
            待终止 = 1,
            终止处理中 = 2,
            终止成功 = 3,
            终止取消 = 4
        }
        /// <summary>
        /// 保单操作状态
        /// </summary>
        public enum OrderOperaStatus
        {
            核保通过 = 0,
            待退保 = 1,
            退保处理中 = 2,
            退保成功 = 3,
            待终止 = 4,
            终止处理中 = 5,
            终止成功 = 6,
            已到期 = 7,
            人工核保中 = 8,
            核保失败 = 9,
            承保确认 = 10

        }

        /// <summary>
        /// 退保终止日志类型
        /// </summary>
        public enum RefundStopLogOperaType
        {

            退保操作 = 1,
            退保处理 = 2,
            退保成功 = 3,
            退保取消 = 4,
            终止操作 = 5,
            终止处理 = 6,
            终止成功 = 7,
            终止取消 = 8,
            设置退保配置 = 9,
            编辑退保信息 = 10,
            编辑终止生效时间 = 11,
            编辑终止备注 = 12,
            编辑退保备注 = 13
        }
        /// <summary>
        /// 退保配置状态
        /// </summary>
        public enum CarRefundConfigStatus
        {

            未配置 = 1,
            已配置 = 2,
            已失效 = 3,
            已取消 = 5
        }

        /// <summary>
        /// 退款配置收款状态
        /// </summary>
        public enum CarRefundPosStatus
        {
            监控中 = 0,
            收款成功 = 1,
            收款失败 = 2,
            未检测到 = 3,
            超时失效 = 4,
            代收取消 = 5
        }

        /// <summary>
        /// 车险退款回调步骤
        /// </summary>
        public enum CarRefundCallBackStep
        {
            待查询 = 0,
            充值已查询到 = 1,
            账户信息已查询到 = 2,
            账户信息N小时未查询到 = 3
        }

        /// <summary>
        /// 车险退款回调通知
        /// </summary>
        public enum CarRefundCallBackPushStatus
        {
            待通知 = 0,
            充值已通知 = 1,
            账户信息已通知 = 2,
            账户信息N小时未查询到已通知 = 3
        }
        /// <summary>
        /// 是否支持过户车辆
        /// </summary>
        public enum IsSupportTransfer
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 是否支持新车投保
        /// </summary>
        public enum IsSupportNewCar
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 是否支持同省跨市投保
        /// </summary>
        public enum IsSupportStrideCity
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 是否支持白名单 2016-11-16 
        /// </summary>
        public enum IsWhiteList
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 
        /// </summary>
        public enum InsuranceDateRange
        {
            提前续保天数 = 90
        }

        /// <summary>
        /// 核保状态 统一
        /// </summary>
        public enum UnderwritingStatus
        {
            未核保 = 0,
            已核保 = 1,
            预核保 = 2,
            转人工 = 3,
            退回修改 = 4,
            核保失败 = 5
        }


        /// <summary>
        /// 统一通用车险险种代码
        /// </summary>
        public static class CarInsuranceKindCode
        {
            public const string 机动车交通事故责任强制保险 = "0357",
            车辆损失险 = "030101",
            商业第三者责任保险 = "030102",
            全车盗抢保险 = "030103",
            车上司机人员责任保险 = "030104",
            车上乘客人员责任保险 = "030105",
            玻璃单独破碎险 = "030107",
            自燃损失险 = "030108",
            新增设备损失险 = "030109",
            车身划痕损失险 = "030110",
            发动机涉水损失险 = "030111",
            修理期间费用补偿险 = "030112",
            车上货物责任险 = "030113",
            精神损害抚慰金责任险 = "030114",
            车辆损失保险无法找到第三方特约险 = "030115",
            指定修理厂险 = "030116",
            不计免赔率险 = "030119";
        }


        /// <summary>
        /// 统一通用车险险种代码枚举
        /// </summary>
        public enum CarInsuranceKindCodeEnum
        {

            机动车交通事故责任强制保险 = 0357,
            车辆损失险 = 030101,
            商业第三者责任保险 = 030102,
            全车盗抢保险 = 030103,
            车上司机人员责任保险 = 030104,
            车上乘客人员责任保险 = 030105,
            玻璃单独破碎险 = 030107,
            自燃损失险 = 030108,
            新增设备损失险 = 030109,
            车身划痕损失险 = 030110,
            发动机涉水损失险 = 030111,
            修理期间费用补偿险 = 030112,
            车上货物责任险 = 030113,
            精神损害抚慰金责任险 = 030114,
            车辆损失保险无法找到第三方特约险 = 030115,
            指定修理厂险 = 030116,
            不计免赔率险 = 030119
        }


        /// <summary>
        /// 是否不计免赔标记
        /// </summary>
        public enum IsFranchiseFlag
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 删除标志
        /// </summary>
        public enum IsDeleted
        {
            是 = 1,
            否 = 0
        }
        /// <summary>
        /// 保单出单状态
        /// </summary>
        public enum GeneratePolicyStatus
        {
            未出单 = 0,
            出单成功 = 1,
            出单失败 = 2
        }


        /// <summary>
        /// 车险公告配置是否启用
        /// </summary>
        public enum NoticeSettingIsEnable
        {
            禁用 = 0,
            启用 = 1
        }

        /// <summary>
        /// 车险banner配置是否启用
        /// </summary>
        public enum CarBannerSettingIsEnable
        {
            禁用 = 0,
            启用 = 1
        }

        /// <summary>
        /// 车险banner配置是否设置起始时间 不设置则永久有效
        /// </summary>
        public enum CarBannerIsSettingEnableTime
        {
            不设置 = 0,
            设置 = 1
        }

        /// <summary>
        /// 车险banner配置是否设置起始时间 不设置则永久有效
        /// </summary>
        public enum CarBannerIsJump
        {
            不跳转 = 0,
            跳转 = 1
        }

        /// <summary>
        /// 车险自动化清结算
        /// </summary>
        public enum CarSettleSetting
        {
            /// <summary>
            /// 开启自动化清结算
            /// </summary>
            开启 = 1,
            /// <summary>
            /// 禁用自动化清结算 人工清结算
            /// </summary>
            禁用 = 0
        }

        /// <summary>
        /// 交易通知--交易类型
        /// </summary>
        public enum CarDealType
        {
            支付预警 = 0,
            操作预警 = 1,
            异常通知 = 2,
            录入中金流水 = 3
        }
        /// <summary>
        /// 交易通知--业务场景
        /// </summary>
        public enum CarBusinessType
        {
            临时订单审核通过 = 5,
            临时订单审核通过_未分期 = 6,
            转人工订单 = 10,
            录入中金流水超时 = 20,
            支付回调超时 = 80,
            支付回调成功 = 81,
            支付回调失败 = 82,
            保费结算成功 = 90,
            保费结算失败 = 91,
            保费结算超时 = 92,
            保费核算超时 = 93,
            退保代收预警 = 94
        }

        /// <summary>
        /// 车险保费审核状态
        /// </summary>
        public enum BFSettleReAuditType
        {
            待初审 = 0,
            待复审 = 1,
            已复审 = 2
        }

        /// <summary>
        /// 交易通知配置是否启用
        /// </summary>
        public enum CarDealNoticeIsEnable
        {
            启用 = 1,
            禁用 = 0
        }
        /// <summary>
        /// 交易通知配置是否启用
        /// </summary>
        public enum CarDealNoticeIsFormat
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 保费结算方式
        /// </summary>
        public enum BFSettleType
        {
            手动结算 = 0,
            自动结算 = 1
        }

        /// <summary>
        /// 垫资清结算表删除标志
        /// </summary>
        public enum CarDzSettleIsDelete
        {
            未删除 = 0,
            已删除 = 1
        }

        /// <summary>
        /// 合作渠道类型
        /// </summary>
        public enum CarCooperateChannelType
        {
            无 = 0,
            线下4S店 = 1,
            招行 = 2,
            阳光保险 = 3,
            亲友 = 4
        }

        /// <summary>
        /// 合作状态
        /// </summary>
        public enum CarCooperateStatus
        {
            合作结束 = 0,
            合作中 = 1
        }

        public enum CarCooperateChannelShow
        {
            显示 = 1,
            隐藏 = 0
        }
        /// <summary>
        /// 投保单推送信息中的用户类型
        /// </summary>
        public static class CarPolicyPushUserType
        {
            public const string 投保人 = "1", 被保人 = "2", 车主 = "3";
        }
        /// <summary>
        /// 分期方式
        /// </summary>
        public enum InstallmentType
        {
            等本等手续费 = 1,
            等本一次性收取手续费 = 2,
            首付等本等手续费 = 3
        }

        #region 替代录单审核状态
        public enum TempOrderAuditStatus
        {
            审核不通过 = 0,
            审核通过 = 1,
            待审核 = 2,
            审核中 = 3,
            已取消 = 4
        }

        /// <summary>
        /// 补录状态，仅对EditStatus
        /// </summary>
        public enum TeamOrderEditAuditStatus
        {
            待补录 = 0,
            待审核 = 1,
            审核不通过 = 2,
            审核通过 = 3,
        }

        /// <summary>
        /// 操作类型:用来标识是后台运营进件审核和补录
        /// </summary>
        public enum OperateType
        {
            进件审核 = 0,
            补录审核 = 1
        }

        #endregion

        /// <summary>
        /// 是否启用 启用=1 禁用=0
        /// </summary>
        public enum IsEnable
        {
            启用 = 1,
            禁用 = 0
        }

        #region 商户管理
        /// <summary>
        /// 商户类型 0=企业账户，1=个人账户
        /// </summary>
        public enum AccountType
        {
            企业账户 = 0,
            个人账户 = 1
        }
        #endregion

        #region 车险流水号类型
        /// <summary>
        /// 车险流水号类型
        /// 类型 1：首期支付，2：保费结算，3：退保收款，4退保结算，5：分期扣款，6：主动还款，7终止扣款
        /// </summary>
        public enum SerialNumberType
        {
            首期支付 = 1,
            保费结算 = 2,
            退保收款 = 3,
            退保结算 = 4,
            分期扣款 = 5,
            主动还款 = 6,
            终止扣款 = 7
        }
        #endregion

        #region 业务类型
        public static class CFCACarBusinessType
        {
            public const string 首期支付 = "CXSQZF",
            保费结算 = "CXBFJS",
            退保结算 = "CXTBJS",
            分期扣款 = "CXFQKK",
            主动还款 = "CXZDHK",
            划扣账单 = "CXZZKK";
        }
        #endregion

        #region 结算查询类型
        /// <summary>
        /// 结算查询类型
        /// </summary>
        public enum CarSettleQueryType
        {
            保费结算查询 = 1,
            退保结算查询 = 2
        }
        #endregion

        #region 资金平台业务类型TradeTypeName
        /// <summary>
        /// 资金平台业务类型TradeTypeName
        /// 接口中TradeTypeName需要跟资金平台一一对应
        /// </summary>
        public static class TradeTypeName
        {
            public const string 车险首期付款 = "首期付款",
                车险自动还款 = "系统分期扣款",
                车险主动还款 = "用户主动还款",
                车险账单划扣 = "保单终止扣款",
                车险保费结算 = "保费结算",
                车险退保结算 = "退保结算",
                车险退保代收 = "退保收款";
        }
        #endregion

        #region 车险商户类型
        /// <summary>
        /// 车险商户类型
        /// </summary>
        public enum CarMerchantType
        {
            //商户类型要跟订单来源一致
            //钱端APP=1
            渠道 = 2,
            保险公司 = 3
        }
        #endregion

        #region 保费结算模式
        /// <summary>
        /// 保费结算模式
        /// </summary>
        public enum SettleModel
        {
            保费直付 = 0,
            渠道代刷 = 1
        }
        #endregion
    }
}
