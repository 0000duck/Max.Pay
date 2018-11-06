using Max.Framework.DAL;
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
using Max.Web.Presentation.Common;
using Max.Web.Presentation.Business.Response;

namespace Max.Web.Presentation.Business
{
    /// <summary>
    /// 支付请求处理
    /// </summary>
    [Description("jubaopay")]
    public class Processor_JuBaoPay : BasePay
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
            this.IsPostForm = true;
            this.PayUrl = "http://gateway.jbpay.net/api/gateway";
            this.RequestMethod = "POST";
        }
        public override IDictionary<string, string> CreatePayRequest(BaseRequest request)
        {
            return CreatePayRequest(request.Order, request.PayChannel);
        }

        public override PayResponse Process(IDictionary<string, string> dicParams)
        {
            try
            {
                //HttpWebHelper http = new Framework.Utility.HttpWebHelper();
                //var responseStr = http.Post("http://gateway.jbpay.net/api/gateway", dicParams, Encoding.UTF8, Encoding.UTF8);

                var responseStr = base.HttpRequest(dicParams);

                return PayResponse.IsSuccess(responseStr);
            }
            catch (Exception ex)
            {
                return PayResponse.IsFailed(ex.Message);
            }

        }

        public override PayResult Notify(IDictionary<string, string> dicParams, PayChannel channel)
        {
            var payResult = PayResult.IsFailed();
            if (dicParams["paystatus"].ToUpper() == "SUCCESS")
            {
                payResult.Success = true;
                payResult.MerchantOrderNo = dicParams["customerbillno"];
                payResult.OrderAmount = dicParams["preorderamount"].TryDecimal(0).Value;
                payResult.OrderNo = dicParams["orderno"];
                payResult.IsVerify = Verify(dicParams, channel);
            }
            else
            {
                payResult.Success = false;
            }
            return payResult;
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
            request.Add("customeruser", order.MemberInfo.IsNullOrWhiteSpace() ? "ok" : "ok");
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

        private bool Verify(IDictionary<string, string> parameters, PayChannel channel)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                parameters = parameters.OrderBy(c => c.Key).ToDictionary(p => p.Key, o => o.Value);
                foreach (var item in parameters)
                {
                    if (!string.IsNullOrWhiteSpace(item.Value) && item.Key != "sign")
                    {
                        sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                    }
                }
                string signStr = sb.AppendFormat("key={0}", channel.MerchantKey).ToString();

                return signStr.EncToMD5() == parameters["sign"];
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}