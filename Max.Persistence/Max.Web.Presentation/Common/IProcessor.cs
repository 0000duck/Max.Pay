using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Common
{
    public interface IProcessor
    {
        bool IsPostForm { get; }

        string PayUrl { get; set; }
        string RequestMethod { get; }
        string NotifySuccessMessage { get; }
        string NotifyFailedMessage { get; }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponse Process(BaseRequest request);

        BaseResponse Notify(BaseRequest request);
        BaseResponse Check(BaseRequest request);

        IDictionary<string, string> CreatePayRequest(BaseRequest request);
    }

    public abstract class BasePay : IProcessor
    {
        public bool IsPostForm { get; set; }
        public string PayUrl { get; set; }
        public string RequestMethod { get; set; }
        public string NotifySuccessMessage { get; protected set; }
        public string NotifyFailedMessage { get; protected set; }

        public abstract IDictionary<string, string> CreatePayRequest(BaseRequest request);

        public virtual BaseResponse Process(BaseRequest request)
        {
            return BaseResponse.Create(null);
        }

        public virtual BaseResponse Notify(BaseRequest request)
        {
            return BaseResponse.Create(null);
        }
        public virtual BaseResponse Check(BaseRequest request)
        {
            return BaseResponse.Create(null);
        }
    }
}