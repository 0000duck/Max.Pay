using Max.Web.AppApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Business.Request
{
    /// <summary>
    /// 车险接口
    /// </summary>
    public class Request60001 : BaseRequest
    {


        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }


        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayCode { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankNumber { get; set; }

        /// <summary>
        /// 0=支付密码,1=数字密码,2=指纹密码
        /// </summary>
        public string PwdType { get; set; }
    }
}