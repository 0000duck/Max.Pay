using Max.Framework;
using Max.Framework.DAL;
using Max.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Payment
{
    public class PayOrderService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PayOrder> _PayOrderReps;


        #endregion

        #region 构造函数

        public PayOrderService(
            IUnitOfWork unitOfWork,
            IRepository<PayOrder> PayOrderReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._PayOrderReps = PayOrderReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PayOrder Get(Expression<Func<PayOrder, bool>> predicate)
        {
            return this._PayOrderReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<PayOrder> GetPageList(Expression<Func<PayOrder, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._PayOrderReps.PageList(predicate, c => c.Desc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<PayOrder> GetList(Expression<Func<PayOrder, bool>> predicate)
        {
            return this._PayOrderReps.ToList(predicate);
        }

        public ServiceResult Add(PayOrder model)
        {
            var result = new ServiceResult();
            this._PayOrderReps.Add(model);

            return result.IsSucceed("新增支付订单成功");

        }

        public ServiceResult Update(PayOrder model)
        {
            var result = new ServiceResult();
            this._PayOrderReps.Update(model);

            return result.IsSucceed("编辑支付订单成功");

        }
        public ServiceResult Update(Expression<Func<PayOrder, bool>> predicate, Expression<Func<PayOrder, PayOrder>> expression)
        {
            var result = new ServiceResult();
            this._PayOrderReps.Update(predicate, expression);

            return result.IsSucceed("编辑支付订单成功");

        }
        public ServiceResult Delete(Expression<Func<PayOrder, bool>> predicate)
        {
            var result = new ServiceResult();
            this._PayOrderReps.Delete(predicate);

            return result.IsSucceed("删除成功");

        }

        #endregion
    }
}
