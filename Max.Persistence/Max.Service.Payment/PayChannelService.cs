using Max.Framework;
using Max.Framework.DAL;
using Max.Models.Payment;
using Max.Models.Payment.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Payment
{
    public class PayChannelService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PayChannel> _payChannelReps;


        #endregion

        #region 构造函数

        public PayChannelService(
            IUnitOfWork unitOfWork,
            IRepository<PayChannel> payChannelReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._payChannelReps = payChannelReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PayChannel Get(Expression<Func<PayChannel, bool>> predicate)
        {
            return this._payChannelReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<PayChannel> GetPageList(Expression<Func<PayChannel, bool>> predicate, int pageIndex, int pageSize)
        {
            return this._payChannelReps.PageList(predicate, c => c.Asc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<PayChannel> GetList(Expression<Func<PayChannel, bool>> predicate)
        {
            return this._payChannelReps.ToList(predicate);
        }

        public ServiceResult Add(PayChannel model)
        {
            var result = new ServiceResult();
            this._payChannelReps.Add(model);

            return result.IsSucceed("新增支付渠道成功");

        }

        public ServiceResult Update(PayChannel model)
        {
            var result = new ServiceResult();
            this._payChannelReps.Update(model);

            return result.IsSucceed("编辑支付渠道成功");

        }
        public ServiceResult Update(Expression<Func<PayChannel, bool>> predicate, Expression<Func<PayChannel, PayChannel>> expression)
        {
            var result = new ServiceResult();
            this._payChannelReps.Update(predicate, expression);

            return result.IsSucceed("编辑支付渠道成功");

        }
        public ServiceResult Delete(Expression<Func<PayChannel, bool>> predicate)
        {
            var result = new ServiceResult();
            this._payChannelReps.Update(predicate, c => new PayChannel() { Isdelete = (int)Enums.IsDelete.是 });

            return result.IsSucceed("删除成功");

        }

        #endregion
    }
}
