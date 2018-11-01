using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    /// <summary>
    /// 提供站点常用数据但数据库中不存在的
    /// <Author>MAX</Author>
    /// </summary>
    public static class EnumHelp
    {
        /// <summary>
        /// 资产类型
        /// </summary>
        public static class AssetsType
        {
            #region 资产类型成员
            /// <summary>
            /// 信托理财类
            /// </summary>
            public static string SCP_XT = "SCP_XT";

            /// <summary>
            /// 债券理财类
            /// </summary>
            public static string SCP_ZQ = "SCP_ZQ";

            /// <summary>
            /// 养老计划理财
            /// </summary>
            public static string SCP_YLJH = "SCP_YLJH";

            /// <summary>
            /// 交易所理财
            /// </summary>
            public static string SCP_JYS = "SCP_JYS";

            /// <summary>
            /// 券商大集合
            /// </summary>
            public static string SCP_QSDJH = "SCP_QSDJH";

            /// <summary>
            /// 股票质押借款
            /// </summary>
            public static string SCP_GPZYJK = "SCP_GPZYJK";

            /// <summary>
            /// 投资收益权
            /// </summary>
            public static string SCP_TZSYQ = "SCP_TZSYQ";

            /// <summary>
            /// 应收账款合约
            /// </summary>
            public static string SCP_YSZK = "SCP_YSZK";

            /// <summary>
            /// 票据收益权
            /// </summary>
            public static string SCP_PJSY = "SCP_PJSY";

            /// <summary>
            /// 交易所-定向债务
            /// </summary>
            public static string SCP_JYS_DXZW = "SCP_JYS_DXZW";

            /// <summary>
            /// 交易所-直接债务
            /// </summary>
            public static string SCP_JYS_ZJZW = "SCP_JYS_ZJZW";

            /// <summary>
            /// 交易所-收益权转让
            /// </summary>
            public static string SCP_JYS_SYQZR = "SCP_JYS_SYQZR";

            /// <summary>
            /// 交易所-债权转让
            /// </summary>
            public static string SCP_JYS_ZQZR = "SCP_JYS_ZQZR";

            /// <summary>
            /// 债权收益权
            /// </summary>
            public static string SCP_ZQSYQ = "SCP_ZQSYQ";

            /// <summary>
            /// 交易所理财
            /// </summary>
            public static string SCP_JYLC = "SCP_JYLC";

            /// <summary>
            /// 收益权转让
            /// </summary>
            public static string SCP_SYQZR = "SCP_SYQZR";
            #endregion

            static List<SelectListItem> _ddlData = null;
            /// <summary>
            /// 下拉框数据
            /// </summary>
            public static List<SelectListItem> AssetsTypeList
            {
                get
                {
                    if (_ddlData == null)
                        _ddlData = new List<SelectListItem>() { 
                               new SelectListItem(){ Value = "",Text= "-- 全部 --" },
                               new SelectListItem(){ Value = SCP_XT,Text= "信托理财" },
                               new SelectListItem(){ Value = SCP_ZQ,Text= "债券理财" },
                               new SelectListItem(){ Value = SCP_YLJH,Text= "养老计划理财" },
                               new SelectListItem(){ Value = SCP_JYS,Text= "交易所理财" },
                               new SelectListItem(){ Value = SCP_QSDJH,Text= "券商大集合" },
                               new SelectListItem(){ Value = SCP_GPZYJK,Text= "股票质押借款" },
                               new SelectListItem(){ Value = SCP_TZSYQ,Text= "投资收益权" },
                               new SelectListItem(){ Value = SCP_YSZK,Text= "应收账款合约" },
                               new SelectListItem(){ Value = SCP_PJSY,Text= "票据收益权" },
                               new SelectListItem(){ Value = SCP_JYS_DXZW,Text= "交易所定向债务" },
                               new SelectListItem(){ Value = SCP_JYS_ZJZW,Text= "交易所直接债务" },
                               new SelectListItem(){ Value = SCP_JYS_SYQZR,Text= "交易所收益权转让" },
                               new SelectListItem(){ Value = SCP_JYS_ZQZR,Text= "交易所债权转让" },
                               new SelectListItem(){ Value = SCP_ZQSYQ,Text= "债权收益权" },
                               new SelectListItem(){ Value = SCP_JYLC, Text="交易所理财"},
                               new SelectListItem(){ Value=SCP_SYQZR,Text="收益权转让"}
                        };
                    return _ddlData;
                }
            }
        }
    }


}