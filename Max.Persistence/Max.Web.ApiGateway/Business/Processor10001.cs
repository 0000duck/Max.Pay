using Max.Framework.DAL;
using Max.Web.ApiGateway.Business.Request;
using Max.Web.ApiGateway.Business.Response;
using Max.Web.ApiGateway.Common;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Max.Web.ApiGateway.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Processor10001 : IProcessor
    {
        private static ILog log = LogManager.GetLogger(typeof(Processor10001));
        public Processor10001(
            )
        {
        }


        public BaseResponse Process(BaseRequest baseRequest)
        {

            var request = baseRequest as RequestPayment;
           

            return BaseResponse.Create(ApiEnum.ResponseCode.处理成功, new ResponsePayment
            {
                OrderNO = request.MerchantOrderNo,
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