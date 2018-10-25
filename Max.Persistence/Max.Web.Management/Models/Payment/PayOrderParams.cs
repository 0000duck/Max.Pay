using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Payment
{
    public class PayOrderParams
    {
        public string OrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public int? ChannelType { get; set; }
        public int? PayStatus { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}