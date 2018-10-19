using Max.Web.AppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Common
{
    public class BaseRequest
    {
        public UserData UserData { get; set; }

        public Head Head { get; set; }

        public string RequestId { get; set; }

        public string Cmd { get; set; }

    }
}