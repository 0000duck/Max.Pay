using Max.Framework.DAL;
using Max.Web.ApiGateway.Business.Request;
using Max.Web.ApiGateway.Business.Response;
using Max.Web.ApiGateway.Common;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Max.Service.Payment;

namespace Max.Web.ApiGateway.Business
{
    /// <summary>
    /// 订单查询
    /// </summary>
    public class Processor20001 : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor20001));
        private PayOrderService _payOrderService;
        private MerchantService _merchantService;
        public Processor20001(PayOrderService payOrderService, MerchantService merchantService)
        {
            this._payOrderService = payOrderService;
            this._merchantService = merchantService;
        }


        public BaseResponse Process(BaseRequest baseRequest)
        {

            var request = baseRequest as Request20001;

            var merchant = this._merchantService.Get(c => c.MerchantNo == request.MerchantNo);
            if (merchant.IsNull())
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "商户不存在");
            }
            var order = this._payOrderService.Get(c => c.MerchantOrderNo == request.MerchantOrderNo && c.MerchantId == merchant.MerchantId);
            if (order.IsNull())
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "查无此订单");
            }
            return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new Response20001
            {
                MerchantNo = merchant.MerchantNo,
                MerchantOrderNO = order.MerchantOrderNo,
                OrderNO = order.OrderNo,
                OrderAmount = order.OrderAmount,
                OrderTime = order.MerchantOrderTime,
                PayStatus = order.PayStatus,
                PayResult = Enum.GetName(typeof(Max.Models.Payment.Common.Enums.PayStatus), order.PayStatus)
            });


        }


    }
}