using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common
{
    public class ApiEnum
    {
        public enum ResponseCode
        {
            处理成功 = 0,
            无效调用凭证 = 201,
            无效交易类型 = 202,
            系统内部错误 = 210,
            解析报文错误 = 1001,
            参数不正确 = 2001,
            其它异常 = 3001
        }

        public enum BizCode
        {
            #region 车险外部接口对接
            投保单推送 = 20001
            #endregion
        }
    }
}