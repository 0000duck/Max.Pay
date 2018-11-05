using Max.Models.Payment;
using Max.Web.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Infrastructure
{
    public interface IProcessor
    {
        bool IsPostForm { get; set; }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponse Process(BaseRequest request);


        IDictionary<string, string> CreatePayRequest(BaseRequest request);
    }
}