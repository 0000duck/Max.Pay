using Max.Web.OpenApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Business.Response
{
    public class Response20001 : BaseResponse
    {
        /// <summary>
        /// 响应编码
        /// </summary>
        public string ResponseCode { get; set; }
        /// <summary>
        /// 响应消息
        /// </summary>
        public string ResponseMsg { get; set; }
    }
}