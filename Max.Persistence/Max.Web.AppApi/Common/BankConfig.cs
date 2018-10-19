using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Common
{
    public class BankConfig
    {
        /// <summary>
        /// 银行编码
        /// </summary>
        public int BankCode { get; set; }

        /// <summary>
        /// 银行图标路径
        /// </summary>
        public string IconPath { get; set; }
    }
}