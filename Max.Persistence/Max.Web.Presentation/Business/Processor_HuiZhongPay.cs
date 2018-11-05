using Max.Framework.DAL;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Max.Service.Payment;
using System.ComponentModel;
using Max.Web.Presentation.Common;
using Max.Models.Payment;

namespace Max.Web.Presentation.Business
{
    /// <summary>
    /// 订单查询
    /// </summary>
    [Description("huizhongpay")]
    public class Processor_HuiZhongPay : BasePay
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor_HuiZhongPay));
        private PayOrderService _payOrderService;
        private MerchantService _merchantService;
        public Processor_HuiZhongPay(PayOrderService payOrderService, MerchantService merchantService)
        {
            this._payOrderService = payOrderService;
            this._merchantService = merchantService;
            this.IsPostForm = true;
            this.RequestMethod = "POST";
        }

       


        public override IDictionary<string, string> CreatePayRequest(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Process(BaseRequest baseRequest)
        {
            return BaseResponse.Create(ApiEnum.ResponseCode.处理失败, "查无此订单");
            
        }


    }
}