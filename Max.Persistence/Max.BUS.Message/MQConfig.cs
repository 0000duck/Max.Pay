using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.BUS.Message
{
    /// <summary>
    /// 队列名称
    /// </summary>
    public static class MQConfig
    {
        // APP API 日志
        public const string LogApi_Queue = "log.api";
        public const string LogApi_Exchange = "ex.log.api";

        public const string LogInternalApi_Queue = "log.InternalApi";
        public const string LogInternalApi_Exchange = "ex.log.InternalApi";

        public const string LogOpenApi_Queue = "log.openapi";
        public const string LogOpenApi_Exchange = "ex.log.openapi";

        public const string LogAdmin_Queue = "log.admin";
        public const string LogAdmin_Exchange = "ex.log.admin";

        public const string RiskControl_Queue = "log.riskcontrol";
        public const string RiskControl_Exchange = "ex.log.riskcontrol";

        public const string EquipmentInfo_Queue = "log.EquipmentInfo";
        public const string EquipmentInfo_Exchange = "ex.log.EquipmentInfo";

        public const string Push_Sys_Queue = "push.sys.notification";
        public const string Push_Sys_Exchange = "ex.push.sys.notification";

        public const string Push_User_Queue = "push.user.notification";
        public const string Push_User_Exchange = "ex.push.user.notification";

        public const string CreditPayApiLog_Queue = "log.CreditPayApi";
        public const string CreditPayApiLog_Exchange = "ex.log.CreditPayApi";

        public const string CMC_Queue = "log.cmc";
        public const string CMC_Exchange = "ex.log.cmc";

        public const string Notification_Queue = "push.notification";
        public const string Notification_Exchange = "ex.push.notification";

        public const string CreditMsg_Queue = "log.CreditMessage";
        public const string CreditMsg_Exchange = "ex.log.CreditMessage";

        //闪惠订单支付和退款请求第三方接口日志
        public const string MallOrderPayAndRefund_Queue = "log.MallOrderPayAndRefund";
        public const string MallOrderPayAndRefund_Exchange = "ex.log.MallOrderPayAndRefund";

        //车险
        public const string CarInsurance_Queue = "log.CarInsurance";
        public const string CarInsurance_Exchange = "ex.log.CarInsurance";

        public const string CarRefundScan_Queue = "log.CarRefundScan";
        public const string CarRefundScan_Exchange = "ex.log.CarRefundScan";

        //摇钱宝LC API 日志
        public const string LcLogApi_Queue = "log.LcApi";
        public const string LcLogApi_Exchange = "ex.log.LcApi";

        // 信用异常重试机制
        public const string CreditRetry_Queue = "log.CreditRetry";
        public const string CreditRetry_Exchange = "ex.log.CreditRetry";

        //闪惠第三方订单接口日志
        public const string MallThirdPartyOrder_Queue = "log.MallThirdPartyOrder";
        public const string MallThirdPartyOrder_Exchange = "ex.log.MallThirdPartyOrder";

        //记录同盾命中规则
        public const string TongDunRiskDecision_Queue = "push.TongDunRiskDecision";
        public const string TongDunRiskDecision_Exchange = "ex.push.TongDunRiskDecision";

        // 发起中金支付Api日志
        public const string CFCA_Queue = "log.R_CFCA_Log";
        public const string CFCA_Exchange = "ex.log.R_CFCA_Log";

        // 发起网金融资平台Api日志
        public const string Financing_Queue = "log.Financing_Log";
        public const string Financing_Exchange = "ex.log.Financing_Log";

        // 发起中金支付Api日志
        public const string SZR_Queue = "log.SZR";
        public const string SZR_Exchange = "ex.log.SZR";

        //修改手机号同步消息
        public const string ModifyUserMobile_Queue = "log.ModifyUserMobile";
        public const string ModifyUserMobile_Exchange = "ex.log.ModifyUserMobile";

        // 车贷OpenApi
        public const string CarLoan_Log_Queue = "log.carloan";
        public const string CarLoan_Log_Exchange = "ex.log.carloan";

        //定向推送
        public const string DirectPushMessage_Queue = "push.DirectPushMessage";
        public const string DirectPushMessage_Exchange = "ex.push.DirectPushMessage";

        //错误预警
        public const string Common_ErrorNotice_Exchange = "Common.ErrorNotice.Exchange";
        public const string Common_ErrorNotice_Queue = "Common.ErrorNotice.Queue";

        // H5错误日志
        public const string H5_Log_Queue = "log.h5";
        public const string H5_Log_Exchange = "ex.log.h5";

        public const string FinanceInternalApi_Queue = "log.FinanceInnerApi";
        public const string FinanceInternalApi_Exchange = "ex.log.FinanceInnerApi";

        // 智投宝Api日志
        public const string ZTB_Log_Queue = "log.ZTBApi";
        public const string ZTB_Log_Exchange = "ex.log.ZTBApi";

    }
}
