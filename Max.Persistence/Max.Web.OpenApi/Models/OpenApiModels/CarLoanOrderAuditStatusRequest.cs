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
    public class CarLoanOrderAuditStatusRequest
    {
        /// <summary>
        /// 钱端订单号，提交进件申请通过后由钱端系统返回
        /// </summary>
        public string OrderNo { get; set; }
    }
}
