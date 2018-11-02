using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Common
{
    public interface IProcessor
    {
        //BaseRequest DeserializeRequest(string json);

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponse Process(BaseRequest request);

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponse Query(BaseRequest request);
        
        /// <summary>
        /// 代付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponse Deposit(BaseRequest request);
    }
}