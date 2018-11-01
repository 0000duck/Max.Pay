using Max.Web.AppApi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Business.Request
{
    /// <summary>
    /// 订单查询请求类
    /// </summary>
    [Description("query")]
    public class Request20001 : BaseRequest
    {
        
        [Required]
        public string MerchantOrderNo { get; set; }
        
    }
}