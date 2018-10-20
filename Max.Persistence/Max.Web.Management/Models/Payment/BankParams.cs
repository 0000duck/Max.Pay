using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Payment
{
    public class BankParams
    {
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public int? Status { get; set; }
    }
}