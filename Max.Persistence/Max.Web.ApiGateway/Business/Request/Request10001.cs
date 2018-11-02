using Max.Web.ApiGateway.App_Start;
using Max.Web.ApiGateway.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Business.Request
{
    /// <summary>
    /// 支付请求类
    /// </summary>
    public class Request10001 : BaseRequest
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