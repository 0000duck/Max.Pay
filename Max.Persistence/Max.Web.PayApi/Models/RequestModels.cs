using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.PayApi.Models
{
    public class RequestData
    {
        [Required]
        public string RequestId { get; set; }
        [Required]
        public string PayChannelId { get; set; }
        [Required]
        public string OrderId { get; set; }
        [Required]
        public DateTime RequestTime { get; set; }
    }
}