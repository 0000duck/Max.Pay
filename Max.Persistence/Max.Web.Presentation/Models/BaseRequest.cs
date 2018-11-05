using Max.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Models
{
   
    public class BaseRequest
    {
        public PayOrder Order { get; set; }
        public PayChannel PayChannel { get; set; }

    }
}