using Max.Web.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Common
{
   
    public class BaseRequest
    {
        /// <summary>
        /// 商户号
        /// </summary>
        [Required]
        public string MerchantNo { get; set; }

        /// <summary>
        /// 签名
        /// </summary>        
        [Required]
        public string Sign { get; set; }

        /// <summary>
        /// 方法 支付、查询、代付
        /// </summary>
        [Required]
        public string Cmd { get; set; }

    }
}