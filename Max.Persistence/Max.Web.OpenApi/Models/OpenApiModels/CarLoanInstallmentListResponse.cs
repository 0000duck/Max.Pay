using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.OpenApi.Models.OpenApiModels
{
    public class CarLoanInstallmentListResponse : CarLoanBaseResponse
    {
        public List<OrderInstallment> Data { get; set; }

        public class OrderInstallment
        {
            /// <summary>
            /// 钱端订单号   varchar(36) Y 提交进件申请通过后由钱端系统返回
            /// </summary>
            public string OrderNo { get; set; }

            public List<InstallmentDetail> InstallmentList { get; set; }
        }

        public class InstallmentDetail
        {
            /// <summary>
            /// 账单还款日   datetime Y   每期账单还款日
            /// </summary>
            public string RepayDate { get; set; }

            /// <summary>
            /// 本期应还本金  Y   钱端订单对应每期账单的本期应还本金
            /// </summary>
            public decimal PrincipalAmount { get; set; }

            /// <summary>
            /// 本期应还利息 decimal Y   钱端订单对应每期账单的本期应还利息
            /// </summary>
            public decimal InterestAmount { get; set; }

            /// <summary>
            /// 实际还款金额 decimal Y   钱端订单对应每期账单的本期实际还款金额
            /// </summary>
            public decimal ActualAmount { get; set; }

            /// <summary>
            /// 逾期金额 decimal Y   钱端订单对应每期账单的待还金额
            /// </summary>
            public decimal OverdueAmount { get; set; }

            /// <summary>
            /// 逾期天数 int Y   钱端订单对应每期账单的逾期天数
            /// </summary>
            public int OverdueDays { get; set; }

            /// <summary>
            /// 罚息金额 decimal Y   钱端订单对应每期账单的逾期金额
            /// </summary>
            public decimal PunishAmount { get; set; }

            /// <summary>
            /// 剩余还款金额 decimal Y   钱端订单对应每期账单的剩余还款金额
            /// </summary>
            public decimal RemainAmount { get; set; }

            /// <summary>
            /// 剩余期数 int Y   钱端订单对应账单总期数-当月账单期数
            /// </summary>
            public int RemainPeriods { get; set; }

            /// <summary>
            /// 账单Id
            /// </summary>
            public string BillId { get; set; }
        }

    }
}
