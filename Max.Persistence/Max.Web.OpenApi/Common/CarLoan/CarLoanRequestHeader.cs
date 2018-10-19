using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common.CarLoan
{
    /// <summary>
    /// 车贷请求消息头
    /// </summary>
    public class CarLoanRequestHeader
    {
        /// <summary>
        /// 机构号
        /// </summary>
        [Required(ErrorMessage = "机构号不能为空")]
        public string InstitutionNo { get; set; }

        /// <summary>
        /// 接口请求时间
        /// </summary>
        [Required(ErrorMessage = "请求时间不能为空")]
        public string RequestAt { get; set; }

        /// <summary>
        /// 业务编码
        /// </summary>
        [Required(ErrorMessage = "业务编码不能为空")]
        public int BizCode { get; set; }
    }
}