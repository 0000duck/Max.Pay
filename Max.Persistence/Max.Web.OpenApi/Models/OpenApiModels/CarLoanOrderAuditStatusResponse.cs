using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.OpenApi.Models.OpenApiModels
{
    /// <summary>
    /// 17002-进件审核状态查询
    /// </summary>
    public class CarLoanOrderAuditStatusResponse : CarLoanBaseResponse
    {
        public OrderAuditInfo Data { get; set; }

        public class OrderAuditInfo
        {

            /// <summary>
            /// MAX支付订单号   varchar(36) Y 提交进件申请通过后由MAX支付系统返回的唯一订单号
            /// </summary>
            public string OrderNo { get; set; }

            /// <summary>
            /// 订单审核结果
            /// </summary>
            public OrderAuditStatus OrderResult { get; set; }

            /// <summary>
            /// 资料审核结果
            /// </summary>
            public DocumentAuditResult DocumentResult { get; set; }

            /// <summary>
            /// 放款信息，当订单状态为已放款时返回
            /// </summary>
            public TransferInfo LoanInfo { get; set; }
        }

        public enum OpenApiOrderStatus
        {
            待审核 = 0,
            待放款 = 1,
            已放款 = 2,
            审核不通过 = 3,
            拒绝放款 = 4
        }

        public enum OpenApiDocumentStatus
        {
            待提交 = 0,
            待审核 = 1,
            审核不通过 = 2,
            已补件 = 3,
            待后补 = 4,
            已后补 = 5,
            审核通过 = 6
        }

        /// <summary>
        /// 订单审核结果,包含状态与说明
        /// </summary>
        public class OrderAuditStatus
        {
            /// <summary>
            /// 订单审核状态 	0待审核 1待放款 2已放款 3审核不通过 4 拒绝放款
            /// </summary>
            public int OrderStatus { get; set; }

            /// <summary>
            /// 备注 nvarchar(256)   N 备注
            /// </summary>
            public string Remark { get; set; }
        }

        /// <summary>
        /// 资料审核结果，包含状态、说明与上传至sftp的审核说明文件名称
        /// </summary>
        public class DocumentAuditResult
        {
            /// <summary>
            /// 资料审核状态 int Y	0待提交 1待审核 2审核不通过 3已补件 4待后补 5已后补 6审核通过
            /// </summary>
            public int DocumentStatus { get; set; }

            /// <summary>
            /// 备注 nvarchar(256)   N 备注
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 审核说明文件名称   N 当审核不通过时返回上传至sftp的审核说明文件名称
            /// </summary>
            public string FileName { get; set; }
        }

        /// <summary>
        /// 放款信息  N   当订单状态为已放款时返回
        /// </summary>
        public class TransferInfo
        {
            /// <summary>
            /// 借款项目名称 nvarchar(32)    Y 借款项目名称
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 项目编号    varchar(36) Y 项目编号
            /// </summary>
            public string OrderNo { get; set; }

            /// <summary>
            /// 放款金额    decimal Y   放款金额
            /// </summary>
            public decimal LoanAmount { get; set; }

            /// <summary>
            /// 放款日期 datetime    Y 放款日期
            /// </summary>
            public DateTime LoanDate { get; set; }
        }

    }
}
