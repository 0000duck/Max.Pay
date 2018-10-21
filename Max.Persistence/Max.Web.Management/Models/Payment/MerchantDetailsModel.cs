using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Models.Payment;

namespace Max.Web.Management.Models.Payment
{
    public class MerchantDetailsModel
    {
        public Merchant Merchant { get; set; }
        public List<MerchantBankAccount> MerchantBankList { get; set; }
        public List<PayService> PayProductList { get; set; }
        public List<V_MerchantPayProduct> MerchantPayProductList { get; set; }
    }
}