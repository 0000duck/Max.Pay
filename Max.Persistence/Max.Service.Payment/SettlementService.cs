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
    public class SettlementService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Settlement> _settlementReps;


        #endregion

        #region 构造函数

        public SettlementService(
            IUnitOfWork unitOfWork,
            IRepository<Settlement> settlementReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._settlementReps = settlementReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Settlement Get(Expression<Func<Settlement, bool>> predicate)
        {
            return this._settlementReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<Settlement> GetPageList(Expression<Func<Settlement, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._settlementReps.PageList(predicate, c => c.Desc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Settlement> GetList(Expression<Func<Settlement, bool>> predicate)
        {
            return this._settlementReps.ToList(predicate);
        }

        public ServiceResult Add(Settlement model)
        {
            var result = new ServiceResult();
            this._settlementReps.Add(model);

            return result.IsSucceed("新增结算订单成功");

        }

        public ServiceResult Update(Settlement model)
        {
            var result = new ServiceResult();
            this._settlementReps.Update(model);

            return result.IsSucceed("编辑结算订单成功");

        }
        public ServiceResult Update(Expression<Func<Settlement, bool>> predicate, Expression<Func<Settlement, Settlement>> expression)
        {
            var result = new ServiceResult();
            this._settlementReps.Update(predicate, expression);

            return result.IsSucceed("编辑结算订单成功");

        }
        public ServiceResult Delete(Expression<Func<Settlement, bool>> predicate)
        {
            var result = new ServiceResult();
            this._settlementReps.Delete(predicate);

            return result.IsSucceed("删除成功");

        }

        #endregion
    }
}
