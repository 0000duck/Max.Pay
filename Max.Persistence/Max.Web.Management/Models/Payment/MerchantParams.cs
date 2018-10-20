using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Payment
{
    public class MerchantParams
    {
        public string MerchantName { get; set; }
        public string MerchantNo { get; set; }
        public string AgentId { get; set; }
        public int? Status { get; set; }
    }
}