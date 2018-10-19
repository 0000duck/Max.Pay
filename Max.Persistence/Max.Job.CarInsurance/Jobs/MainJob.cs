using Max.Framework.DAL;
using Max.Models.CarInsurance;
using Max.Models.CarInsurance.Common;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Framework;

namespace Max.Job.CarInsurance.Jobs
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
