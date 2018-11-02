using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Models
{
    public class RequestData
    {
        public string MerchantNo { get; set; }
        public string Sign { get; set; }
        public string Cmd { get; set; }


        public string PayType { get; set; }

        public string MerchantOrderNo { get; set; }

        public string MerchantOrderTime { get; set; }

        public string OrderAmount { get; set; }

        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string DeviceType { get; set; }
        public string OrderDescription { get; set; }
        public string ExtendField { get; set; }
        public string Ip { get; set; }
    }
}