using System;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Max.Framework;
using Max.Framework.Utility;
using Max.Web.AppApi.Business.Request;
using Max.Web.AppApi.Common;
using Max.Web.AppApi.Models;

namespace Max.Web.AppApi.Business.Tests
{
    [TestClass()]
    public class Processor60001Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var url = "http://localhost:6832/api";

            UserData curUser = new UserData
            {
                UserId = "12405983-812b-404e-890e-342ff129c8ff",
                Mobile = "13926021702",
                RealName = "MAX",
                NickName = "P53407038",
                IDCard = "44092119901122352X",
                EPlusAccountId = "",
                InstitutionNo = "",
                Usrnbr = "ff88bf6ee41e4cae9c932e02f6d6aa10"
            };

            RequestData reqData = new RequestData
            {
                cmd = "VehicleInsurance.PayOrder",
                head = new Head
                {
                    reqTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    sessionid = Guid.NewGuid().ToString(),
                    longitude = "113.3161220283074",
                    latitude = "23.13839160113956",
                    iMEI = "04BF946E85D744BA90AF7B2F4491743F13155555103",
                    ip = "192.168.16.37",
                    oSVersion = "I9.2.1",
                    sN = "1455853113907",
                    appVersion = "V3.0",
                    clientModel = "iPhone",
                },
                body = new Request60001
                {
                    BankNumber = "1012345678912310",
                    OrderNo = "76f34f3c-f5ff-49c3-96ad-4e4285d9b1d5",
                    //PwdType="1",
                    PayCode = "000000",
                }

            };

            //序列化、加密、url编码
            string encodeRequest = HttpUtility.UrlEncode(Base64Utils.EncodeBase64String(reqData.ToJson()));
            string encodeUserInfo = HttpUtility.UrlEncode(Base64Utils.EncodeBase64String(curUser.ToJson()));
            //组装参数
            string reqStr = string.Format("RequestData={0}&RequestId={1}&UserData={2}", encodeRequest, Guid.NewGuid(), encodeUserInfo);

            string resultStr = HttpWebHelper.Helper.Post(url, reqStr, Encoding.UTF8, Encoding.UTF8);
            BaseResponse responseModel = JsonUtil.FromJson<BaseResponse>(resultStr);

            Assert.IsTrue(responseModel.Successed == ApiEnum.ResponseCode.处理成功.ToString());
        }


     
    }
}
