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
    /// 订单查询
    /// </summary>
    public class Processor20001 : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor10001));
        public Processor20001()
        {
        }


        public BaseResponse Process(BaseRequest baseRequest)
        {

            var request = baseRequest as Request20001;


            return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new Response20001
            {
                OrderNO = request.MerchantOrderNo,
                Amount = 18.52m
            });


        }

        public BaseResponse Query(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Deposit(BaseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}