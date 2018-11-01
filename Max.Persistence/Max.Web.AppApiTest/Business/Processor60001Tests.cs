using System;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Max.Framework;
using Max.Framework.Utility;
using Max.Web.AppApi.Business.Request;
using Max.Web.AppApi.Common;
using System.Collections.Generic;
using System.Linq;

namespace Max.Web.AppApi.Business.Tests
{
    [TestClass()]
    public class Processor60001Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var url = "http://localhost:6867/api";


            //组装参数
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("MerchantNo", "10086");
            dic.Add("Cmd", "payment");
            dic.Add("PayType", "alipay");
            dic.Add("MerchantOrderNo", Guid.NewGuid().ToStr());
            dic.Add("MerchantOrderTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
            dic.Add("OrderAmount", "100.00");
            dic.Add("NotifyUrl", "http://max.pay.notify.com");
            dic.Add("ReturnUrl", "");
            dic.Add("DeviceType", "");
            dic.Add("OrderDescription", "");
            dic.Add("ExtendField", "");
            dic.Add("Ip", "");

            dic = dic.OrderBy(c => c.Key).ToDictionary(c => c.Key, o => o.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var item in dic)
            {
                if (!item.Value.IsNullOrWhiteSpace())
                {
                    sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }
            string signStr = sb.AppendFormat("key={0}", "16cc36db2722437597c178a72f26ac83").ToString();
            dic.Add("Sign", signStr.EncToMD5());
            string resultStr = HttpWebHelper.Helper.Post(url, dic, Encoding.UTF8, Encoding.UTF8);
            BaseResponse responseModel = JsonUtil.FromJson<BaseResponse>(resultStr);

            Assert.IsTrue(responseModel.Successed == ApiEnum.ResponseCode.处理成功.ToString());
        }



    }
}
