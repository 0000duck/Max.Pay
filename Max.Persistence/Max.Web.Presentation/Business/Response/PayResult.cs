using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Business.Response
{
    /// <summary>
    /// 支付接口返回类
    /// </summary>
    public class PayResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }


        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantNo { get; set; }
        /// <summary>
        /// 平台订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string MerchantOrderNo { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 验证签名错误信息
        /// </summary>
        public string VerifyMessage { get; set; }

        /// <summary>
        /// 是否验签通过
        /// </summary>
        public bool IsVerify { get; set; }

        public static PayResult IsSuccess()
        {
            return Create(true, null);
        }

        public static PayResult IsSuccess(string message)
        {
            return Create(true, message);
        }
        public static PayResult IsFailed()
        {
            return Create(false, null);
        }
        public static PayResult IsFailed(string message)
        {
            return Create(false, message);
        }

        private static PayResult Create(bool isSuccess, string message)
        {
            return new PayResult
            {
                Success = isSuccess,
                Message = message
            };
        }
    }
}