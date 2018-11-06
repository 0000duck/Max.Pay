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
using Max.Models.Payment;

namespace Max.Web.ApiGateway.Business
{
    /// <summary>
    /// 支付请求处理
    /// </summary>
    public class Processor10001 : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor10001));

        private MerchantService _merchantService;
        private PayProductService _payProductService;
        private MerchantPayProductService _merchantPayProductService;
        private PayChannelService _payChannelService;
        private PayOrderService _payOrderService;

        public Processor10001(MerchantService merchantService,
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
                var request = baseRequest as Request10001;
                //商户验证
                var merchant = this._merchantService.Get(c => c.MerchantNo == request.MerchantNo);
                if (merchant.IsNull())
                {
                    return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "商户不存在", null, 0);
                }
                if (merchant.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
                {
                    return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "商户不可用", null, 0);
                }

                //支付方式验证
                var payProduct = this._payProductService.Get(c => c.ServiceCode == request.PayType);
                if (payProduct.IsNull() || payProduct.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
                {
                    return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "支付方式{0}不可用".Fmt(request.PayType), null, 0);
                }

                //商户是否开通该支付方式
                var merchantPayProduct = this._merchantPayProductService.Get(c => c.MerchantId == merchant.MerchantId && c.ServiceId == payProduct.ServiceId);
                if (merchantPayProduct.IsNull() || merchantPayProduct.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
                {
                    return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "商户未开通该支付方式", null, 0);

                }

                //支付路由验证
                var payChannel = this._payChannelService.Get(c => c.ChannelId == merchantPayProduct.PayChannelId);
                if (payChannel.IsNull() || payChannel.Status != (int)Max.Models.Payment.Common.Enums.CommonStatus.正常)
                {
                    return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "支付渠道不可用", null, 0);
                }

                //订单入库
                var order = CreateOrder(request, merchant, payProduct, payChannel, merchantPayProduct);

                return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new Response10001
                {
                    MerchantOrderNO = request.MerchantOrderNo,
                    OrderNO = order.OrderNo,
                    Amount = order.OrderAmount,
                    PayUrl = "http://localhost:2162?orderid={0}".Fmt(order.OrderId)
                });

            }
            catch (Exception ex)
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, ex.ToJson(), null, 0);
            }

        }

        private PayOrder CreateOrder(Request10001 request, Merchant merchant, PayService payProduct, PayChannel payChannel, MerchantPayService merchantPayService)
        {
            PayOrder order = new PayOrder();
            order.OrderId = Guid.NewGuid().ToString();
            order.OrderNo = DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(1000, 9999);
            order.AgentNo = merchant.AgentNo;
            order.ChannelId = payChannel.ChannelId;
            order.ChannelName = payChannel.ChannelName;
            order.ChannelType = payChannel.ChannelType;
            order.CreateTime = DateTime.Now;
            order.DeviceType = request.DeviceType;
            order.ExtendField = request.ExtendField;
            order.FeeMode = payChannel.SettleMode.ToString();
            order.SettleMode = payChannel.SettleMode.ToStr();
            order.Ip = request.Ip;
            order.MemberInfo = "test";
            order.MerchantId = merchant.MerchantId;
            order.MerchantOrderNo = request.MerchantOrderNo;
            order.MerchantOrderTime = request.MerchantOrderTime.TryDateTime(DateTime.Now).Value;
            order.NotifyUrl = request.NotifyUrl;
            order.OrderAmount = request.OrderAmount.TryDecimal(0).Value;
            order.OrderDescription = request.OrderDescription;
            order.PayStatus = (int)Max.Models.Payment.Common.Enums.PayStatus.未支付;
            order.PayTime = DateTime.Now;
            order.PreorderAmount = order.OrderAmount;
            order.ServiceFee = order.OrderAmount * merchantPayService.MerchantFeeRate;
            order.ServiceRate = merchantPayService.MerchantFeeRate;
            order.TransAmount = order.OrderAmount - order.ServiceFee;
            order.ServiceId = payProduct.ServiceId;

            this._payOrderService.Add(order);
            return order;
        }

    }
}