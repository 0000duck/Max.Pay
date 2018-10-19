using Max.Framework.DAL;
using Max.Models.Payment;
using Max.Models.Payment.Common;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Framework;

namespace Max.Job.Payment.Jobs
{
    [DisallowConcurrentExecution]
    public class MainJob : IJob
    {
        public MainJob()
        {
        }
        public void Execute(IJobExecutionContext context)
        {
            
            Console.WriteLine("心跳服务：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
    
}
