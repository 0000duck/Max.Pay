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
    }
}
