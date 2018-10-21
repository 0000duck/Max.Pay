using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Common
{
    public class ApiEnum
    {
        public enum ResponseCode
        {
            处理成功 = 100,
            处理失败 = 999,
            解析报文错误 = 200,
            无效调用凭证 = 201,
            无效交易类型 = 202,
            参数不正确 = 203,
            系统内部错误 = 210,
            用户无支付密码 = 211,
            支付密码错误 = 212,
            支付失败 = 213,
            EPlus接口错误 = 214,
            账号已冻结 = 229,
            密码错误 = 230,
            用户没有实名认证 = 231,
            用户不是白名单 = 232,
            检查通过 = 0,
            白名单项目非白名单用户 = 1,
            新手项目非新手用户 = 2,
            高收益项目无高收益券 = 3,
            高收益项目有高收益券没选择 = 4,
            可投份额不足 = 5,
            项目不存在 = 6,
            用户没有申请预约 = 7,
            用户不存在 = 300
        }

        public enum ShowMode
        {
            浮层 = 1,
            广告弹窗 = 4
        }

        public enum BizCode
        {
            #region 资产

            #region My

            [Description("My.Register")]
            用户注册 = 10001,

            [Description("My.BookingProjectList")]
            预约投标项目列表 = 13001,

            [Description("My.Booking")]
            预约投标预约申请 = 13002,

            [Description("My.BookingRecordList")]
            预约投标记录列表 = 13003,

            [Description("My.CancelBookingRecprd")]
            预约投标取消预约 = 13004,

            [Description("My.BookingProjectStatus")]
            预约投标预约状态 = 13006,

            [Description("My.IDCardAuth")]
            身份证信息认证 = 14001,

            [Description("My.FaceRecognition")]
            人脸识别 = 14004,

            [Description("My.LastInvest[V4.0.0]")]
            获取最近回款的投资资产_V400 = 15001,

            [Description("My.LastInvest")]
            获取最近回款的投资资产 = 15002,

            [Description("My.SMSCodeLogin")]
            验证码登录 = 10003,

            [Description("My.PwdLogin")]
            密码登录 = 10002,

            [Description("My.VerifyCode")]
            获取验证码 = 10004,

            [Description("My.SMMaxBookingAmout")]
            当前摇钱宝最大预约额 = 13005,

            [Description("My.CheckPayPwd")]
            检查支付密码是否正确 = 10005,

            [Description("My.CheckCoupon")]
            检测用户是否有优惠券 = 10006,

            [Description("My.Coupons")]
            优惠券列表 = 10007,

            [Description("My.SetPayPwd")]
            设置支付密码 = 10008,

            [Description("My.InvestList[V4.0.0]")]
            投资记录_V400 = 10009,

            [Description("My.InvestList")]
            投资记录 = 11009,

            [Description("My.OrderDetail")]
            投资项目详情 = 10010,

            [Description("My.BankCard")]
            我的银行卡列表 = 10011,

            [Description("Metadata.BankList")]
            开户行列表 = 10014,

            [Description("MetaData.BranchBankList")]
            开户支行列表 = 10015,

            [Description("My.CheckVerifyCode")]
            检测验证码是否正确 = 10018,

            [Description("My.CheckMobileRegister")]
            手机号是否注册过 = 10019,

            #endregion

            #region Invest

            [Description("Invest.ProjectList")]
            获取投资列表 = 11000,

            [Description("Invest.ProjectInfo")]
            获取项目详情 = 11001,

            [Description("Invest.ProjectTenderProgress[V4.0.0]")]
            获取投资项目进度_V400 = 11003,

            [Description("Invest.ProjectTenderProgress")]
            获取投资项目进度 = 11013,

            [Description("Invest.CreateOrder")]
            创建订单 = 12001,

            [Description("Invest.PayOrder")]
            支付 = 12002,

            [Description("Invest.MyIncome")]
            我的投资收益列表 = 12003,

            [Description("Invest.ProjectHomeList")]
            投资列表首页 = 11002,

            [Description("Invest.CheckCreateOrder")]
            检测创建订单条件 = 12004,

            [Description("Invest.PaySucessInfo")]
            投资成功信息 = 12005,

            [Description("Invest.CouponProjectList")]
            优惠券可用投资列表 = 11004,

            [Description("Invest.HomeInfo")]
            投资首页广告数据 = 11005,

            [Description("Invest.CheckInvest")]
            检测投资条件 = 11006,

            #endregion

            #endregion

            #region 闪惠App接口

            [Description("Mall.MyCart")]
            我的购物车 = 20001,
            [Description("Mall.CheckCartSubmitOrder")]
            购物车结算检查 = 20002,
            [Description("Mall.MyCartNum")]
            获取购物车商品的数量 = 20003,
            [Description("Mall.ModifyMyCart")]
            修改购物车商品数量 = 20004,
            [Description("Mall.DeleItemInCart")]
            删除购物车商品 = 20005,
            [Description("Mall.AddItemInCart")]
            添加购物车商品 = 20006,
            [Description("Mall.HomeChannels")]
            闪惠首页顶部栏目获取 = 20007,


            [Description("Mall.MyAddress")]
            获取收件地址接口 = 21001,
            [Description("Mall.AddAddress")]
            添加收货地址接口 = 21002,
            [Description("Mall.DeleteAddress")]
            删除收货地址接口 = 21003,
            [Description("Mall.UpdateAddress")]
            修改收货地址接口 = 21004,
            [Description("Mall.Provinces")]
            获取省市区街道接口 = 21005,
            [Description("Mall.AreaId")]
            获取省市区ID = 21006,

            [Description("Mall.GiftCard")]
            礼品卡列表 = 22001,
            [Description("Mall.GiftCardCategory")]
            礼品卡类别 = 22002,
            [Description("Mall.DeleteGiftCard")]
            删除礼品卡 = 22003,
            [Description("Mall.GiftCardDetail")]
            礼品卡详情 = 22004,
            [Description("Mall.ProductInfo")]
            普通商品详情 = 22005,
            [Description("Mall.RechargeInfo")]
            直充商品详情 = 22006,
            [Description("Mall.CheckAddressDeliver")]
            区域是否配送 = 22007,
            [Description("Mall.Favorite")]
            关注商品或者商户 = 22008,
            [Description("Mall.FavoriteProducts")]
            我的关注_商品 = 22009,
            [Description("Mall.FavoriteSuppliers")]
            我的关注_商户 = 22010,
            [Description("Mall.CancelFavorite")]
            取消关注商品或则商户 = 22011,
            [Description("Mall.HasFavorite")]
            商品商户是否被关注 = 22012,

            [Description("Mall.CancelOrder")]
            取消订单 = 23002,
            [Description("Mall.Refund")]
            申请退款 = 23003,
            [Description("Mall.ConfirmReceipt")]
            确认收货 = 23004,
            [Description("Mall.DeleteOrder")]
            删除订单 = 23005,

            [Description("Mall.CheckProductSubmitOrder")]
            商品立即购买检测 = 24001,
            [Description("Mall.SubmitOrder")]
            提交订单 = 24002,
            [Description("Mall.RechargeSubmitOrder")]
            直充商品下单 = 24003,
            [Description("Mall.HasProductOrder")]
            零元商品是否已被领取 = 24004,
            [Description("Mall.MyOrder")]
            我的订单 = 24011,
            [Description("Mall.OrderInfo")]
            订单详情 = 24012,
            [Description("Mall.MyOrderAmount")]
            相关订单数量 = 24013,

            #region 闪惠V3.1.1版本
            [Description("Mall.MyOrderV311")]
            我的订单v311 = 24014,
            [Description("Mall.OrderInfoV311")]
            订单详情v311 = 24015,
            #endregion



            [Description("Mall.Coupons")]
            订单优惠券 = 25001,
            [Description("Mall.CheckCoupon")]
            检查优惠券数量 = 25003,
            [Description("Mall.MailInfo")]
            我的信用 = 25002,

            [Description("Mall.Pay")]
            订单支付 = 26000,
            [Description("Mall.GlobalPeriodization")]
            订单提交支付类型选择 = 26002,
            [Description("My.PayConfirmInfo")]
            订单列表支付信息 = 26003,

            #region 售后相关接口 27开头
            [Description("Mall.ApplicationReturn")]
            申请退货 = 27000,
            [Description("Mall.AfterSaleProgress")]
            售后进度 = 27001,
            [Description("Mall.CheckApplicationReturnInfo")]
            申请退货页面信息检测 = 27002,
            [Description("Mall.ProductReturnAddress")]
            设置退货地址by京东 = 27003,
            [Description("Mall.SetReturnAddress")]
            设置退货地址by快递 = 27004,
            [Description("Mall.CancelAfterSaleProgress")]
            取消售后申请 = 27005,
            [Description("Mall.DefaultAddress")]
            对应下单收货地址 = 27006,

            #endregion

            #endregion

            #region 个人中心

            #region 黄晓柠

            [Description("My.BaseInfo")]
            获取用户基本信息 = 31001,

            [Description("My.CheckBaseInfo")]
            获取我的特殊字段的数量和开通情况 = 31002,

            [Description("My.ModifyUserAvatar")]
            修改用户头像 = 31003,

            [Description("My.NewNickName")]
            修改用户昵称 = 31004,

            [Description("My.ModiEmail")]
            修改用户邮箱 = 31005,

            [Description("Msg.MyMessage")]
            获取或刷新最新消息 = 31006,

            [Description("Msg.List")]
            获取或刷新消息列表 = 31007,

            [Description("My.Credit")]
            获取我的投资信用与授信信用 = 31008,

            [Description("My.ModiMobile")]
            修改用户手机号 = 31009,

            

            [Description("App.PushMessageInfos")]
            获取总未读消息数量 = 91000,

            [Description("App.HandlePushMessageCount")]
            读取栏目消息并返回未读消息数 = 91001,

            #endregion


            #region 陈斌

            [Description("My.GetMyRPList")]
            红包列表 = 32001,
            [Description("My.WithdrawRP")]
            红包提现 = 32002,
            [Description("My.GetRPCashTime")]
            获取申请时间及到账时间 = 32003,
            [Description("My.CheckDrawRPBankCard")]
            检测红包对应指定银行卡号 = 32004,

            [Description("My.JoinCorpApply")]
            申请加入企业 = 32005,
            [Description("My.UndoJoinApply")]
            退出申请 = 32006,
            [Description("My.QuitCorp")]
            退出企业 = 32007,
            [Description("My.CorpInfo")]
            企业开通相关信息 = 32008,

            [Description("My.AuthIdEPlus")]
            实名认证 = 32009,

            [Description("My.SetLoginPwd")]
            设置登录密码 = 32010,

            [Description("My.UpdateLoginPwd")]
            修改登录密码 = 32011,

            [Description("My.UpdatePayPwd")]
            修改支付密码 = 32012,

            #endregion

            [Description("My.ModiRecommender")]
            修改用户推荐人 = 31010,

            [Description("App.ShowRecommender")]
            是否显示输入推荐人 = 31011,

            [Description("My.CheckModiMobileShow")]
            检测修改用户手机号的提示信息 = 31012,

            [Description("My.CheckSpecialInfo")]
            获取特殊字段信息 = 31013,

            #region 吕梓榕
            [Description("My.SetDigitPwd")]
            设置数字密码 = 32013,

            [Description("My.UpdateDigitPwd")]
            修改数字密码 = 32014,

            [Description("My.OpenDigitPwd")]
            关闭数字密码 = 32015,

            [Description("My.SetFingerPwd")]
            设置指纹密码 = 32016,

            #endregion

            [Description("App.ShareInfo")]
            获取分享信息 = 33001,
            [Description("My.AllCoupons")]
            所有优惠券列表 = 33002,

            [Description("App.Feedback")]
            意见反馈 = 34001,

            [Description("My.SecureLevel")]
            账户安全中心安全等级 = 34002,

            [Description("My.DeleBankCard")]
            删除银行卡 = 34003,

            [Description("App.UploadFile")]
            公共图片上传 = 35001,

            [Description("My.BankcardInfo")]
            我的单张银行卡信息 = 34004,

            #region 微信管理
            [Description("My.GetBindingSnsAccountList")]
            获取第三方账号列表 = 36001,

            [Description("My.BindSnsPlat")]
            绑定微信 = 36002,

            [Description("My.SnsPlatLogin")]
            微信登录 = 36003,

            [Description("My.CheckHasBindSnsPlat")]
            是否绑定手机号码 = 36004,

            [Description("My.SnsPlatBindMobile")]
            绑定手机号码 = 36005,

            [Description("My.UnBindSnsPlat")]
            解绑微信 = 36006,
            #endregion

            #endregion


            #region 公共公共广告位
            [Description("App.CommonAdListV3")]
            获取公共广告位信息 = 10012,
            [Description("App.HomeInfo")]
            首页广告数据 = 10013,
            #endregion

            #region 授权管理
            [Description("My.CreditExInfo")]
            我的授权信息 = 40001,

            [Description("CreditEx.RepaymentInfo")]
            基本还款信息 = 40002,

            [Description("CreditEx.RepayRecordList")]
            还款记录 = 40003,

            [Description("CreditEx.PeriodizationInfo")]
            账单详情 = 40004,

            #region 彭昌燊
            //[Description("CreditEx.ConfirmRepay")]
            //确定还款 = 40005,
            [Description("CreditEx.SetRepayBankCard")]
            设置还款银行卡 = 40006,
            [Description("CreditEx.RepayRecordDetail")]
            还款详情 = 40007,
            [Description("CreditEx.RepayBankCardInfo")]
            还款银行卡信息 = 40008,
            #endregion
            [Description("EmployeeLoan.Info")]
            员工贷基本信息 = 40009,

            [Description("CreditEx.UploadIdCardPhoto")]
            上传身份证 = 40010,

            [Description("CreditEx.ConfirmUploadIdCard")]
            确认提交身份证 = 40011,

            [Description("CreditEx.MyUploadIdCardPhotos")]
            我上传的身份证图片 = 40012,

            [Description("CreditEx.PeriodizationInfoList")]
            月度账单列表 = 40013,

            [Description("CreditEx.ConfirmRepay")]
            手动还款确认还款 = 40014,

            [Description("CreditEx.RepayResult")]
            手动还款结果详情 = 40018,



            [Description("CreditEx.PeriodizationOrderList")]
            月度账单下的订单列表 = 40017,

            [Description("CreditEx.PeriodizationOrderDetail")]
            账单明细详情 = 40015,

            [Description("CreditEx.BillDetailsList")]
            授信账单列表 = 40016,


            #endregion

            #region 现金贷

            [Description("CreditEx.SpecialBankCard")]
            特定银行卡信息 = 41001,

            #endregion

            #region 车险

            [Description("VehicleInsurance.PayOrder")]
            车险支付 = 60001,

            #endregion

            #region 摇钱宝
            [Description("MoneyShake.Shake")]
            摇一摇 = 50001,

            [Description("MoneyShake.ShareAddInterest")]
            加息后分享再加息 = 50003,
            //[Description("App.HomeNotices")]
            //摇钱宝公告 = 50004,
            [Description("MoneyShake.AccessInfo")]
            摇钱宝存入取出功能基本状态信息 = 50005,

            [Description("MoneyShake.RemainderTips")]
            摇钱宝余额提示 = 50006,
            [Description("MoneyShake.HomeNotices")]
            摇钱宝首页公告 = 50007,
            [Description("MoneyShake.ShakeImgs")]
            摇钱宝背景图和形象图 = 50010,

            [Description("MoneyShake.CheckPayAmount")]
            摇钱宝存入取出支付前检测金额 = 50019,
            [Description("MoneyShake.RecordBankInfo")]
            摇钱宝存入取出详情银行卡信息 = 50022,


            [Description("MoneyShake.ShareAddShakeTimes")]
            摇钱宝首次分享获得摇奖机会 = 50023,

            [Description("ShakeMoney.ShareInfo")]
            摇钱宝右上角分享 = 50025,

            [Description("Metadata.HotCitys")]
            银行卡相关的热门城市 = 50026,

            [Description("Metadata.HotCityInfo")]
            通过城市名获取城市省份编号信息 = 50027,
            #endregion

            [Description("Statistics.launch")]
            app启动 = 10016,

            [Description("App.Upgrade")]
            查询版本更新信息 = 10020,

            [Description("App.GlobalConfigs")]
            全局动态配置信息 = 70001,

            [Description("App.PostErrorLog")]
            记录APP的错误日志 = 70002,

            #region 系统全局公告接口
            [Description("App.HomeNotices")]
            全局公告 = 10086,
            #endregion

            #region 通用支付接口
            [Description("App.Pay")]
            通用支付接口 = 50024,
            #endregion

            #region 通用支付组件

            [Description("App.PayLayout")]
            支付控件布局与数据接口 = 19000,

            [Description("App.CommonPay")]
            公共支付接口 = 19001,

            [Description("My.CommonBankCard")]
            通用银行卡列表 = 19002,

            [Description("App.SubmitBusinessData")]
            公共业务数据提交 = 19003,
            #endregion

            #region 根据城市推荐银行信息
            [Description("Metadata.RecommendBankInfo")]
            根据城市推荐银行信息 = 55555,
            #endregion

            #region MAX支付自有数据统计相关接口
            [Description("Statistics.AdsVisit")]
            APP广告位点击统计接口 = 66666,
            #endregion

            #region 工资定期存入

            #region 获取设置工资存入的基本条件
            [Description("Wage.DepositLimitInfo")]
            获取设置工资存入的基本条件 = 80001,
            #endregion

            #region 设置与修改工资存入
            [Description("Wage.SetIncrementInfo")]
            设置与修改工资存入 = 80002,
            #endregion

            #region 获取工资存入基本信息
            [Description("Wage.IncrementInfo")]
            获取工资存入基本信息 = 80003,
            #endregion

            #region 终止工资存入计划
            [Description("Wage.StopIncrement")]
            终止工资存入计划 = 80004,
            #endregion

            #region 获取设置工资存入的日期列表
            [Description("Wage.DaysList")]
            获取设置工资存入的日期列表 = 80005,
            #endregion
            #region 获取工资存入记录
            [Description("Wage.IncrementRecord")]
            获取工资存入记录 = 80006,
            #endregion
            #endregion

            #region 信息流

            [Description("App.InfoFlow")]
            获取首页信息流数据 = 99901,
            [Description("App.SpecifyUserInfo")]
            首页用户相关信息 = 99902,
            #endregion

            [Description("App.PageInfos")]
            获取app页面相关信息 = 99903,


            #region 智投宝 30001 ~ 30999

            [Description("SmartInvest.InvestList")]
            投资项目列表 = 30002,

            [Description("SmartInvest.PaySucessInfo")]
            智投宝_投资成功信息 = 30003,

            [Description("SmartInvest.CreateOrder")]
            智投宝_创建投资订单 = 30004,

            [Description("SmartInvest.ProjectList")]
            智投宝项目列表 = 30005,

            [Description("SmartInvest.ProjectInfo")]
            智投宝项目详情 = 30006,

            [Description("SmartInvest.CheckCreateOrder")]
            智投宝_检测创建订单条件 = 30007,

            [Description("SmartInvest.OrderDetail")]
            智投宝_投资详情 = 30008,
            #endregion
        }

        public enum AppCheckState
        {
            弹出信息 = 0,
            弹出广告 = 1,
            信用不足 = 2,
            实名认证 = 3,
            信用额度不足 = 4,
            投资信用额度不足 = 5,
            肖像认证 = 6
        }


        /// <summary>
        /// 购物车结算检查+订单提交检查
        /// </summary>
        public enum MallOrderCheckResult
        {
            成功 = 1,
            用户未登录 = 2,
            用户信用额度不足 = 3,
            非新手用户不能购买新手商品 = 4,
            没有特权券不能购买特权商品 = 5,
            库存不足 = 6,
            超过最大限购数量 = 7,
            购物车没有商品 = 8,
            商品已经下架 = 9,
            商户合作终止 = 10,
            参数错误 = 11,
            商品不存在 = 12,
            收货地址不存在 = 13,
            没有实名认证 = 14,
            卡券库存不足 = 15,
            优惠券不存在 = 16,
            优惠券已使用或者已过期 = 17,
            优惠券已禁用 = 18,
            没有找到优惠券对应的商品 = 19,
            商品ID错误 = 20,
            异常错误 = 21,
            请输入手机号码 = 22,
            请输入正确手机号码 = 23,
            请输入加油卡号 = 24,
            直充类型错误 = 25,
            充值项目不存在 = 26,
            充值方式不存在 = 27,
            不存在任何充值项 = 28,
            不存在该充值面值 = 29,
            所选充值面值的商品已下架 = 30,
            所选充值面值的商品已售罄 = 31,
            单笔充值总金额超出限制 = 32,
            该商品不支持使用优惠券 = 33,
            所选优惠券仓库不存在 = 34,
            该商品不能使用该优惠券 = 35,
            所选优惠券仓库已禁用 = 36,
            所选优惠券不属于当前下单用户 = 37,
            本地下单失败 = 38,
            暂不支持指定号码充值 = 39,
            发票信息填写错误 = 40,
        }

        public enum Request31002Type
        {
            我的红包 = 1,
            优惠券 = 2,
            是否开通摇钱宝 = 3,
            我的信用 = 4,
            未读消息数量 = 5,
            肖像认证 = 6,
            实名认证 = 7,
            安全中心等级 = 8,
            微信信息 = 9,
            用户唯一ID = 10,
            是否是摇钱宝新用户 = 11,
            数字密码 = 12,
            指纹支付 = 13,
            推荐人信息 = 14,
            是否设置了工资定投 = 15,
            是否显示工资定投过度页 = 16
        }

        public enum Request31013Type
        {
            是否设置了工资定投 = 15,
            是否显示工资定投过度页 = 16
        }

        public enum LoginErrorType
        {
            正常 = 0,
            密码错误 = 1,
            账户冻结 = 2,
            参数错误 = 3,
            未设置登录密码 = 4,
        }

        public enum DealResult
        {
            失败 = 0,
            成功 = 1
        }

        /// <summary>
        /// 特殊场景状态码
        /// </summary>        
        public enum SpecialSceneStatusCode
        {
            EPlus实名认证 = 1,
            支付密码错误 = 10,
            余额不足 = 11
        }
    }
}