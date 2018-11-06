using Max.Web.Presentation.Business.Response;
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
        PayModelEnum PayModel { get; set; }

        string PayUrl { get; set; }
        string RequestMethod { get; }
        string NotifySuccessMessage { get; }
        string NotifyFailedMessage { get; }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PayResponse Process(IDictionary<string, string> dicParams);

        PayResult Notify(IDictionary<string, string> dicParams);
        PayResult Check(BaseRequest request);

        IDictionary<string, string> CreatePayRequest(BaseRequest request);
    }

    public abstract class BasePay : IProcessor
    {
        public bool IsPostForm { get; set; } = false;
        public PayModelEnum PayModel { get; set; } = PayModelEnum.URL跳转;
        public string PayUrl { get; set; }
        public string RequestMethod { get; set; } = "POST";
        public string NotifySuccessMessage { get; protected set; }
        public string NotifyFailedMessage { get; protected set; }

        public abstract IDictionary<string, string> CreatePayRequest(BaseRequest request);

        public virtual PayResponse Process(IDictionary<string, string> dicParams)
        {
            return PayResponse.IsSuccess();
        }

        public virtual PayResult Notify(IDictionary<string, string> dicParams)
        {
            return PayResult.IsSuccess(null);
        }
        public virtual PayResult Check(BaseRequest request)
        {
            return PayResult.IsSuccess(null);
        }
    }


    public enum PayModelEnum
    {
        无 = 0,
        URL跳转 = 1,
        扫码 = 2,
        二维码生成 = 3,
        HTML输出 = 4,
    }
}