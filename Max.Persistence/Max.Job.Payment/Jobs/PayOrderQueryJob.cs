using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.BUS.Message.Log;
using Max.Service.Payment;
using Max.Framework;
using Max.Models.Payment;
using Max.Framework.DAL;
using Max.Models.Payment.Common;

namespace Max.Job.Payment.Jobs
{
    /// <summary>
    /// 订单查询作业
    /// <author></author>
    /// </summary>
    [DisallowConcurrentExecution]
    public class PayOrderQueryJob : IJob
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PayOrderQueryJob));
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PayOrder> _payOrderReps;
        private readonly IRepository<Transaction> _transactionReps;


        public PayOrderQueryJob(IUnitOfWork unitOfWork, IRepository<PayOrder> payOrderReps, IRepository<Transaction> transactionReps)
        {
            this._unitOfWork = unitOfWork;
            this._payOrderReps = payOrderReps;
            this._transactionReps = transactionReps;

        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //向渠道方查询30分钟内 次数小于5次 并且处理中的订单支付结果
                var queryTime = DateTime.Now.AddMinutes(-30);
                var orderList = this._payOrderReps.ToList(c => c.QueryCount <= 3 && c.PayStatus == (int)Enums.PayStatus.处理中 && c.PayTime > queryTime);
                if (orderList.Any())
                {
                    foreach (var order in orderList)
                    {
                        ServiceResult result = new ServiceResult();
                        Transaction transation = null;

                        //处理查询========


                        order.QueryCount += 1;
                        if (result.Success)
                        {
                            //交易记录
                            transation = new Transaction();
                            transation.TransactionId = Guid.NewGuid().ToString();
                            transation.TransType = (int)Enums.TransType.支付;
                            transation.TransAmount = order.TransAmount;
                            transation.OrderAmount = order.OrderAmount;
                            transation.ServiceFee = order.ServiceFee;
                            transation.CreateTime = DateTime.Now;
                            transation.Remark = "支付订单号:{0}".Fmt(order.OrderId);

                            order.TransactionId = transation.TransactionId;
                            order.PayStatus = (int)Enums.PayStatus.支付成功;
                        }
                        else
                        {
                            order.PayStatus = (int)Enums.PayStatus.支付失败;
                        }

                        using (var tran = this._unitOfWork.BeginTransaction())
                        {
                            this._payOrderReps.Update(order, tran);
                            if (transation != null)
                            {
                                this._transactionReps.Add(transation, tran);
                            }
                            tran.Commit();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error("【查询订单异常】：{0}".Fmt(ex.ToString()));
            }
        }

    }
}
