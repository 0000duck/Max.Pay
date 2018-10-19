using Max.Web.AppApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Business.Request
{
    /// <summary>
    /// 登录请求类
    /// </summary>
    public class RequestLogin : BaseRequest
    {
        /// <summary>
        ///登录手机号
        /// </summary>     
        public string Mobile { get; set; }

        /// <summary>
        ///短信验证码
        /// </summary>        
        public string SmsCode { get; set; }

        /// <summary>
        ///登录密码
        /// </summary>        
        public string Password { get; set; }
      
    }
}