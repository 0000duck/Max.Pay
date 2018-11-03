using Max.Models.Payment;
using Max.Web.PayApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.PayApi.Common
{
   
    public class BaseRequest
    {
        public PayOrder Order { get; set; }
        public PayChannel PayChannel { get; set; }

    }
}