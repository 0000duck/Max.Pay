using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.OpenApi.Common
{
    public interface IProcessor
    {
        BaseResponse Process(BaseRequest request);
    }
}