using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common
{
    public class BaseRequest
    {
        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 调用接口编码
        /// </summary>
        public string BizCode { get; set; }
    }
}