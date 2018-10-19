using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.BUS.Message.Log;
using Max.Service.CarInsurance;
using Max.Framework;
using Max.Models.CarInsurance;
using Max.Framework.DAL;
using Max.Models.CarInsurance.Common;

namespace Max.Job.CarInsurance.Jobs
{
    /// <summary>
    /// 订单超时自动取消作业
    /// <author></author>
    /// </summary>
    [DisallowConcurrentExecution]
    public class CancelOrderJob : IJob
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CancelOrderJob));
        private readonly IUnitOfWork _unitOfWork;
       

        public CancelOrderJob()
        {
           
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {

               
            }
            catch (Exception ex)
            {
                Logger.Error("【自动取消订单异常】：{0}".Fmt(ex.ToString()));
            }
        }
        
    }
}
