using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace Max.BUS.Message.Log
{
    [Queue(MQConfig.Payment_Queue, ExchangeName = MQConfig.Payment_Exchange)]
    public interface IPaymentMessage
    {
        /// <summary>
        /// 业务模块名称
        /// </summary>
        string BusinessModule { get; set; }

        /// <summary>
        /// 保险公司类型 1华安 2阳光
        /// </summary>
        int CompanyType { get; set; }
    }
}
