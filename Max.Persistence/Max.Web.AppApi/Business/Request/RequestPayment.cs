using Max.Web.AppApi.App_Start;
using Max.Web.AppApi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Business.Request
{
    /// <summary>
    /// 支付请求类
    /// </summary>
    [Description(PayAction.Payment)]
    public class RequestPayment : BaseRequest
    {

        [Required]
        public string PayType { get; set; }
        [Required]
        public string MerchantOrderNo { get; set; }
        [Required]
        public string MerchantOrderTime { get; set; }
        [Required]
        public string OrderAmount { get; set; }
        [Required]
        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string DeviceType { get; set; }
        public string OrderDescription { get; set; }
        public string ExtendField { get; set; }
        public string Ip { get; set; }
    }
}