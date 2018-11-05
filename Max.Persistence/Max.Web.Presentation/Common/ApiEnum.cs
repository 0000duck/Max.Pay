using Max.Web.Presentation.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Common
{
    public class ApiEnum
    {
        public enum ResponseCode
        {
            处理成功 = 100,
            处理失败 = 999,
            解析报文错误 = 200,
            无效调用凭证 = 201,
            无效交易类型 = 202,
            参数不正确 = 203,
            系统内部错误 = 210

        }



        public enum BizCode
        {


            #region cmd

            [Description(PayAction.Payment)]
            支付请求 = 10001,

            [Description(PayAction.Query)]
            订单查询 = 20001,

            [Description(PayAction.Withholding)]
            代扣 = 30001,
            #endregion

        }

    }
}