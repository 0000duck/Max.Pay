using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.Presentation.Infrastructure
{
    public interface IProcessorFactory
    {
        IProcessor Create(string bizCode);
    }
}
