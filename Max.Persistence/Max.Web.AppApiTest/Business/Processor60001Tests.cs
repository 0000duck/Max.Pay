using System;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Max.Framework;
using Max.Framework.Utility;
using Max.Web.AppApi.Business.Request;
using Max.Web.AppApi.Common;

namespace Max.Web.AppApi.Business.Tests
{
    [TestClass()]
    public class Processor60001Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var url = "http://localhost:6832/api";

            //组装参数
            string reqStr = string.Format("RequestData={0}&RequestId={1}&UserData={2}", "", Guid.NewGuid(), "");

            string resultStr = HttpWebHelper.Helper.Post(url, reqStr, Encoding.UTF8, Encoding.UTF8);
            BaseResponse responseModel = JsonUtil.FromJson<BaseResponse>(resultStr);

            Assert.IsTrue(responseModel.Successed == ApiEnum.ResponseCode.处理成功.ToString());
        }



    }
}
