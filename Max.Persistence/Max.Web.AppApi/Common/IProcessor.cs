using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Common
{
    public interface IProcessor
    {
        //BaseRequest DeserializeRequest(string json);

        BaseResponse Process(BaseRequest request);
    }
}