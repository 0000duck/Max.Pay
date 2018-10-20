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
    public class MerchantBankService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Merchant> _MerchantReps;
        private readonly IRepository<MerchantBankAccount> _MerchantBankReps;


        #endregion

        #region 构造函数

        public MerchantBankService(
            IUnitOfWork unitOfWork,
            IRepository<Merchant> MerchantReps,
            IRepository<MerchantBankAccount> MerchantBankReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._MerchantReps = MerchantReps;
            this._MerchantBankReps = MerchantBankReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public MerchantBankAccount Get(Expression<Func<MerchantBankAccount, bool>> predicate)
        {
            return this._MerchantBankReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageList<MerchantBankAccount> GetPageList(Expression<Func<MerchantBankAccount, bool>> predicate, int pageIndex, int pageSize)
        {
            return this._MerchantBankReps.PageList(predicate, c => c.Desc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<MerchantBankAccount> GetList(Expression<Func<MerchantBankAccount, bool>> predicate)
        {
            return this._MerchantBankReps.ToList(predicate);
        }

        public ServiceResult Add(MerchantBankAccount model)
        {
            var result = new ServiceResult();
            this._MerchantBankReps.Add(model);
            return result.IsSucceed("新增商户银行卡成功");

        }

        public ServiceResult Update(MerchantBankAccount model)
        {
            var result = new ServiceResult();
            this._MerchantBankReps.Update(model);
            return result.IsSucceed("编辑商户银行卡成功");

        }

        public ServiceResult Update(Expression<Func<MerchantBankAccount, bool>> predicate, Expression<Func<MerchantBankAccount, MerchantBankAccount>> expression)
        {
            var result = new ServiceResult();
            this._MerchantBankReps.Update(predicate, expression);
            return result.IsSucceed("编辑商户银行卡成功");

        }
        public ServiceResult Delete(Expression<Func<MerchantBankAccount, bool>> predicate)
        {
            var result = new ServiceResult();
            this._MerchantBankReps.Update(predicate, c => new MerchantBankAccount() { Isdelete = (int)Enums.IsDelete.是 });
            return result.IsSucceed("删除成功");
        }

        
        #endregion
    }
}
