using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.OpenApi.Models.OpenApiModels
{
    public class CarLoanBaseResponse
    {
        public ResponseCode Code { get; set; }

        public string Message { get; set; }

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
