using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Payment
{
    public class AgentParams
    {
        public string AgentName { get; set; }
        public string AgentNo { get; set; }
        public int? Status { get; set; }
    }
}