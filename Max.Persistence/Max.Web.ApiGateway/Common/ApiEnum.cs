using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Max.Web.ApiGateway.Common
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
            系统内部错误 = 210,
            用户无支付密码 = 211,
            支付密码错误 = 212,
            支付失败 = 213,
            EPlus接口错误 = 214,
            账号已冻结 = 229,
            密码错误 = 230,
            用户没有实名认证 = 231,
            用户不是白名单 = 232,
            检查通过 = 0,
            白名单项目非白名单用户 = 1,
            新手项目非新手用户 = 2,
            高收益项目无高收益券 = 3,
            高收益项目有高收益券没选择 = 4,
            可投份额不足 = 5,
            项目不存在 = 6,
            用户没有申请预约 = 7,
            用户不存在 = 300
        }

        

        public enum BizCode
        {
            

            #region 支付渠道

            [Description("kalapay")]
            卡拉支付 = 10001,

            [Description("okpay")]
            ok支付 = 20001,

            #endregion

        }
        
    }
}