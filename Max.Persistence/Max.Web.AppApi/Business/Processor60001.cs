using Max.Framework.DAL;
using Max.Web.AppApi.Business.Request;
using Max.Web.AppApi.Business.Response;
using Max.Web.AppApi.Common;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Max.Web.AppApi.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Processor60001 : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor60001));
        public Processor60001(
            )
        {
        }

        public BaseResponse Process(BaseRequest baseRequest)
        {

            var request = baseRequest as Request60001;
            if (request.UserData == null)
            {
                return BaseResponse.Create(ApiEnum.ResponseCode.参数不正确, "网络不给力，请稍后再试", null, 0);
            }

            return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new Response60001
            {
                OrderNO = request.OrderNo,
            });


        }
    }
}