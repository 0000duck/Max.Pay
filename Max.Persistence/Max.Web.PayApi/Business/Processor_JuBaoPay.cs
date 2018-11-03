using Max.Framework.DAL;
using Max.Web.PayApi.Business.Request;
using Max.Web.PayApi.Business.Response;
using Max.Web.PayApi.Common;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Max.Service.Payment;
using Max.Models.Payment;
using System.ComponentModel;

namespace Max.Web.PayApi.Business
{
    /// <summary>
    /// 支付请求处理
    /// </summary>
    [Description("jubaopay")]
    public class Processor_JuBaoPay : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor_JuBaoPay));

        private MerchantService _merchantService;
        private PayProductService _payProductService;
        private MerchantPayProductService _merchantPayProductService;
        private PayChannelService _payChannelService;
        private PayOrderService _payOrderService;

        public Processor_JuBaoPay(MerchantService merchantService,
             PayProductService payProductService,
             MerchantPayProductService merchantPayProductService,
             PayChannelService payChannelService,
             PayOrderService payOrderService
            )
        {
            this._merchantService = merchantService;
            this._payProductService = payProductService;
            this._merchantPayProductService = merchantPayProductService;
            this._payChannelService = payChannelService;
            this._payOrderService = payOrderService;
        }


        public BaseResponse Process(BaseRequest baseRequest)
        {

            try
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new Response10001
                {
                    MerchantOrderNO = baseRequest.Order.OrderId
                });

            }
            catch (Exception ex)
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, ex.ToJson(), null, 0);
            }

        }
    }
}