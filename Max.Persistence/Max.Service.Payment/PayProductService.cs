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
    public class PayProductService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PayService> _payServiceReps;


        #endregion

        #region 构造函数

        public PayProductService(
            IUnitOfWork unitOfWork,
            IRepository<PayService> payServiceReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._payServiceReps = payServiceReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PayService Get(Expression<Func<PayService, bool>> predicate)
        {
            return this._payServiceReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<PayService> GetPageList(Expression<Func<PayService, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._payServiceReps.PageList(predicate, c => c.Asc(o => o.ServiceType), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<PayService> GetList(Expression<Func<PayService, bool>> predicate)
        {
            return this._payServiceReps.ToList(predicate);
        }

        public ServiceResult Add(PayService model)
        {
            var result = new ServiceResult();
            this._payServiceReps.Add(model);

            return result.IsSucceed("新增支付产品成功");

        }

        public ServiceResult Update(PayService model)
        {
            var result = new ServiceResult();
            this._payServiceReps.Update(model);

            return result.IsSucceed("编辑支付产品成功");

        }
        public ServiceResult Update(Expression<Func<PayService, bool>> predicate, Expression<Func<PayService, PayService>> expression)
        {
            var result = new ServiceResult();
            this._payServiceReps.Update(predicate, expression);

            return result.IsSucceed("编辑支付产品成功");

        }
        public ServiceResult Delete(Expression<Func<PayService, bool>> predicate)
        {
            var result = new ServiceResult();
            this._payServiceReps.Delete(predicate);

            return result.IsSucceed("删除成功");

        }

        #endregion
    }
}
