using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.PayApi.Common
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
        
    }
}