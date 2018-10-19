using Max.Framework.Utility;
using Max.Web.AppApi.Common;
using Max.Web.AppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Max.Framework;
using System.Configuration;

namespace Max.Web.AppApiTest.Common
{
    public class UnitTestHelper
    {
        /// <summary>
        /// 测试API接口
        /// </summary>
        /// <param name="baseRequest">参数</param>
        /// <param name="cmd">命令</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="url">URL</param>
        /// <returns></returns>
        public static BaseResponse Test_API(BaseRequest baseRequest, string cmd, UserData userInfo, string url = "")
        {
            RequestData requestData = new RequestData
            {
                body = baseRequest,
                cmd = cmd
            };

            if (string.IsNullOrEmpty(url))
            {
                url = ConfigurationManager.AppSettings["UnitTestUrl"];
            }

            //序列化、加密、url编码
            string encodeRequest = HttpUtility.UrlEncode(Base64Utils.EncodeBase64String(requestData.ToJson()));
            string encodeUserInfo = HttpUtility.UrlEncode(Base64Utils.EncodeBase64String(userInfo.ToJson()));
            //组装参数
            string reqStr = string.Format("RequestData={0}&RequestId={1}&UserData={2}", encodeRequest, Guid.NewGuid(), encodeUserInfo);

            string ResultStr = HttpWebHelper.Helper.Post(url, reqStr, Encoding.UTF8, Encoding.UTF8);
            BaseResponse responseModel = JsonUtil.FromJson<BaseResponse>(ResultStr);

            return responseModel;
        }
    }
}
