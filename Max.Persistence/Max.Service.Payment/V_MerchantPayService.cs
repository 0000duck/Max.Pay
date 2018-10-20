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
    public class V_MerchantPayService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<V_MerchantPayProduct> _vmpReps;


        #endregion

        #region 构造函数

        public V_MerchantPayService(
            IUnitOfWork unitOfWork,
            IRepository<V_MerchantPayProduct> vmpReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._vmpReps = vmpReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public V_MerchantPayProduct Get(Expression<Func<V_MerchantPayProduct, bool>> predicate)
        {
            return this._vmpReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<V_MerchantPayProduct> GetPageList(Expression<Func<V_MerchantPayProduct, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._vmpReps.PageList(predicate, c => c.Asc(o => o.ServiceName), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<V_MerchantPayProduct> GetList(Expression<Func<V_MerchantPayProduct, bool>> predicate)
        {
            return this._vmpReps.ToList(predicate,c=>c.Asc(o=>o.ServiceName));
        }

       

        #endregion
    }
}
