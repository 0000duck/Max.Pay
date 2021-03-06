﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Web.ApiGateway.App_Start
{
    public class AppConfig
    {
        /// <summary>
        /// 0 不记录 1 MQ 2 文件 
        /// </summary>
        public static readonly string LogType = "logType".ValueOfAppSetting();
    }

    public static class LogType
    {
        public const string NONE = "0";
        public const string MQ = "1";
        public const string DB = "2";
        public const string LOG4NET = "3";
    }

    public static class PayAction
    {
        /// <summary>
        /// 支付
        /// </summary>
        public const string Payment = "payment";
        /// <summary>
        /// 支付查询
        /// </summary>
        public const string Query = "query";
        /// <summary>
        /// 代扣
        /// </summary>
        public const string Remit = "remit";
        /// <summary>
        /// 代扣查询
        /// </summary>
        public const string RemitQuery = "remit_query";
    }
}