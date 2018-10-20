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

            支付宝 = 1,
            微信 = 2,
            QQ = 3,
            网银在线 = 4,
            银联钱包 = 5,
            快捷支付 = 5,
        }
    }
}
