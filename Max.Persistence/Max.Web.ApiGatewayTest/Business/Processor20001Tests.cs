using System;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Max.Framework;
using Max.Framework.Utility;
using Max.Web.ApiGateway.Business.Request;
using Max.Web.ApiGateway.Common;
using System.Collections.Generic;
using System.Linq;

namespace Max.Web.ApiGateway.Business.Tests
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
            dic.Add("Cmd", "query");
            dic.Add("MerchantOrderNo", "0d0c6dd9-09e9-4d17-a9b8-b37e6e6a2eb7");

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

            //get
            //var paramsStr = HttpWebHelper.CreateParameter(dic);
            //string resultStr = HttpWebHelper.Helper.Get(url + "?" + paramsStr, Encoding.UTF8);

            //post
            string resultStr = HttpWebHelper.Helper.Post(url, dic, Encoding.UTF8, Encoding.UTF8);
            BaseResponse responseModel = JsonUtil.FromJson<BaseResponse>(resultStr);

            Assert.IsTrue(responseModel.ErrorCode == ApiEnum.ResponseCode.处理成功);
        }



    }
}
