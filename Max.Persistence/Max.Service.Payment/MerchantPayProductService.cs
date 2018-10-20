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
    public class MerchantPayProductService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<MerchantPayService> _mpReps;


        #endregion

        #region 构造函数

        public MerchantPayProductService(
            IUnitOfWork unitOfWork,
            IRepository<MerchantPayService> mpReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._mpReps = mpReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public MerchantPayService Get(Expression<Func<MerchantPayService, bool>> predicate)
        {
            return this._mpReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<MerchantPayService> GetPageList(Expression<Func<MerchantPayService, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._mpReps.PageList(predicate, c => c.Desc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<MerchantPayService> GetList(Expression<Func<MerchantPayService, bool>> predicate)
        {
            return this._mpReps.ToList(predicate,c=>c.Desc(o=>o.CreateTime));
        }


        public ServiceResult Add(MerchantPayService model)
        {
            var result = new ServiceResult();
            this._mpReps.Add(model);

            return result.IsSucceed("开通支付产品成功");

        }

        public ServiceResult Update(MerchantPayService model)
        {
            var result = new ServiceResult();
            this._mpReps.Update(model);

            return result.IsSucceed("编辑支付产品成功");

        }
        public ServiceResult Update(Expression<Func<MerchantPayService, bool>> predicate, Expression<Func<MerchantPayService, MerchantPayService>> expression)
        {
            var result = new ServiceResult();
            this._mpReps.Update(predicate, expression);

            return result.IsSucceed("编辑支付产品成功");

        }
        public ServiceResult Delete(Expression<Func<MerchantPayService, bool>> predicate)
        {
            var result = new ServiceResult();
            this._mpReps.Update(predicate,c=>new MerchantPayService() {  Isdelete=(int)Enums.IsDelete.是});

            return result.IsSucceed("删除成功");

        }

        #endregion


    }
}
