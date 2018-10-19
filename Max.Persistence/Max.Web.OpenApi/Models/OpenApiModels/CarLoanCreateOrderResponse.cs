using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.OpenApi.Models.OpenApiModels
{
    public class CarLoanCreateOrderResponse : CarLoanBaseResponse
    {
        public OrderInfo Data { get; set; }

        public class OrderInfo
        {
            public string OrderNo { get; set; }

            public string CreatedOn { get; set; }

            public int AuditStatus { get; set; }
        }
    }


}
