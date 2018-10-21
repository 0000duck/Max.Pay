using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Models.Payment.Common
{
    public class Enums
    {
        /// <summary>
        /// 通用状态
        /// </summary>
        public enum CommonStatus
        {

            正常 = 0,
            禁用 = 1
        }
        /// <summary>
        /// 银行状态
        /// </summary>
        public enum BankStatus
        {

            正常 = 0,
            禁用 = 1
        }

        /// <summary>
        /// 软删除标记状态
        /// </summary>
        public enum IsDelete
        {

            是 = 1,
            否 = 0
        }
        /// <summary>
        /// 支付状态
        /// </summary>
        public enum PayStatus
        {

            未支付 = 0,
            处理中 = 1,
            支付成功 = 2,
            支付失败 = 3

        }

        /// <summary>
        /// 通用是否枚举
        /// </summary>
        public enum YesOrNo
        {
            是 = 1,
            否 = 0
        }

        /// <summary>
        /// 银行状态
        /// </summary>
        public enum ServiceType
        {

            支付宝扫码 = 1,
            支付宝WAP = 2,
            微信扫码 = 3,
            微信WAP = 4,
            QQ钱包扫码 = 5,
            QQ钱包WAP = 6,
            网银 = 7,
            快捷支付 = 8,
            银联钱包扫码 = 9,
            京东 = 10,
        }

        /// <summary>
        /// 商户支付产品开通状态
        /// </summary>
        public enum IsOpen
        {
            已开通 = 1,
            未开通 = 0
        }

    }
}
