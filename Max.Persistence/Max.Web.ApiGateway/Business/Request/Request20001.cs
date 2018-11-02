using Max.Web.ApiGateway.App_Start;
using Max.Web.ApiGateway.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Business.Request
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