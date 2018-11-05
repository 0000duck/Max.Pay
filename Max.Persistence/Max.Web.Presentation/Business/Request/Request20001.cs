
using Max.Web.Presentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Business.Request
{
    /// <summary>
    /// 订单查询请求类
    /// </summary>
    public class Request20001 : BaseRequest
    {
        
        [Required]
        public string MerchantOrderNo { get; set; }
        
    }
}