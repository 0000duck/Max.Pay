using Max.Framework.DAL;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Max.Service.Payment;
using System.ComponentModel;
using Max.Web.Presentation.Infrastructure;
using Max.Web.Presentation.Models;
using Max.Models.Payment;

namespace Max.Web.Presentation.Business
{
    /// <summary>
    /// 订单查询
    /// </summary>
    [Description("huizhongpay")]
    public class Processor_HuiZhongPay : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor_HuiZhongPay));
        private PayOrderService _payOrderService;
        private MerchantService _merchantService;
        public Processor_HuiZhongPay(PayOrderService payOrderService, MerchantService merchantService)
        {
            this._payOrderService = payOrderService;
            this._merchantService = merchantService;
        }

        public bool IsPostForm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDictionary<string, string> CreatePayRequest(PayOrder order, PayChannel channel)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> CreatePayRequest(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Process(BaseRequest baseRequest)
        {

            return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "查无此订单");


        }


    }
}