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

        public string Data { get; set; }

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
            return Create(true, null, null);
        }
        public static PayResult IsSuccess(string data)
        {
            return Create(true, null, data);
        }
        public static PayResult IsSuccess(string message, string data)
        {
            return Create(true, message, data);
        }
        public static PayResult IsFailed()
        {
            return Create(false, null, null);
        }
        public static PayResult IsFailed(string message, string data = null)
        {
            return Create(false, message, data);
        }

        public static PayResult Create(bool isSuccess, string message, string data)
        {
            return new PayResult
            {
                Success = isSuccess,
                Message = message,
                Data = data
            };
        }
    }
}