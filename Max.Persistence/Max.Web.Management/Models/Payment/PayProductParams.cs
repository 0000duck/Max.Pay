using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Payment
{
    public class PayProductParams
    {
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public int? ServiceType { get; set; }
        public int? Status { get; set; }
    }
}