﻿using Max.Framework.DAL;
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
using System.Text;
using Max.Models.Payment.Common;
using Max.Framework.Utility;

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
                var dicRequest = CreatePayRequest(baseRequest.Order, baseRequest.PayChannel);

                HttpWebHelper http = new Framework.Utility.HttpWebHelper();
                var responseStr = http.Post("http://gateway.jbpay.net/api/gateway", dicRequest, Encoding.UTF8, Encoding.UTF8);

                return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new Response10001
                {
                    MerchantOrderNO = baseRequest.Order.OrderId,
                    PayUrl = responseStr
                });

            }
            catch (Exception ex)
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, ex.ToJson(), null, 0);
            }

        }

        private IDictionary<string, string> CreatePayRequest(PayOrder order, PayChannel channel)
        {
            var request = new Dictionary<string, string>();

            request.Add("customerno", channel.MerchantNo);
            request.Add("channeltype", GetPayType(order.ChannelType));
            request.Add("orderamount", order.OrderAmount.ToString("0.00"));
            request.Add("customerbillno", order.OrderNo);
            request.Add("customerbilltime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            request.Add("ip", order.Ip);
            request.Add("devicetype", order.DeviceType);
            request.Add("customeruser", order.MemberInfo.IsNullOrWhiteSpace()?"ok":"ok");
            request.Add("notifyurl", order.NotifyUrl);
            //request.Add("returnurl", order.SuccessUrl);

            //if (type == PayType.OnlineBank)
            //{
            //    request.Add("bankcode", bankMapping[order.BankCode]);
            //}

            request = request.OrderBy(c => c.Key).ToDictionary(p => p.Key, o => o.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var item in request)
            {
                if (!string.IsNullOrWhiteSpace(item.Value) && item.Key != "sign")
                {
                    sb.AppendFormat("&{0}={1}", item.Key.ToLower(), item.Value);
                }
            }
            string signStr = sb.ToString().Substring(1) + "&key=" + channel.MerchantKey;

            string md5Sign = signStr.EncToMD5();
            request.Add("sign", md5Sign);


            return request;

        }

        private string GetPayType(int payType)
        {
            string strPayType = "";
            Enums.ServiceType payTypeEnum = (Max.Models.Payment.Common.Enums.ServiceType)payType;
            switch (payTypeEnum)
            {
                case Enums.ServiceType.支付宝扫码:
                    strPayType = "alipay_qrcode";
                    break;
                case Enums.ServiceType.支付宝WAP:
                    strPayType = "alipay_app";
                    break;
                case Enums.ServiceType.微信扫码:
                    strPayType = "wechat_qrcode";
                    break;
                case Enums.ServiceType.微信WAP:
                    strPayType = "wechat_app";
                    break;
                case Enums.ServiceType.QQ钱包扫码:
                    strPayType = "qq_qrcode";
                    break;
                case Enums.ServiceType.QQ钱包WAP:
                    strPayType = "qq_app";
                    break;
                case Enums.ServiceType.网银:
                    strPayType = "onlinebank";
                    break;
                case Enums.ServiceType.快捷支付:
                    strPayType = "yl_nocard";
                    break;
                case Enums.ServiceType.银联钱包扫码:
                    strPayType = "yl_qrcode";
                    break;
                case Enums.ServiceType.京东:
                    strPayType = "jd";
                    break;
                default:
                    break;
            }
            return strPayType;
        }
    }
}