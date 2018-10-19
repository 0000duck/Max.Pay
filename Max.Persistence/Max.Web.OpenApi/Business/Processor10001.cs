using Max.Web.OpenApi.Business.Response;
using Max.Web.OpenApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;
using Max.Web.OpenApi.Business.Request;

namespace Max.Web.OpenApi.Business
{
    public class Processor10001 : IProcessor
    {
        public BaseResponse Process(BaseRequest baseRequest)
        {
            var request = baseRequest as Request10001;
            return new Response10001
            {
                CreateTime = DateTime.Now
            };
        }
    }
}