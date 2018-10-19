using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common.CarLoan
{
    public class CarLoanOpenApiEnums
    {
        /// <summary>
        /// 业务编码
        /// </summary>
        public enum BizCode
        {
            进件申请 = 17001,
            进件审核状态查询 = 17002,
            进件还款信息查询 = 17003
        }

        /// <summary>
        /// 响应码
        /// </summary>
        public enum ResponseCode
        {
            处理成功 = 100,
            解析报文错误 = 200,
            无效调用凭证 = 201,
            无效交易类型 = 202,
            参数不正确 = 203,
            系统内部错误 = 210,
            处理失败 = 999
        }
    }


}