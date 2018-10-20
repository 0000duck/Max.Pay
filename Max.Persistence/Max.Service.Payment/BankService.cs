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
    public class BankService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bank> _BankReps;


        #endregion

        #region 构造函数

        public BankService(
            IUnitOfWork unitOfWork,
            IRepository<Bank> BankReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._BankReps = BankReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Bank Get(Expression<Func<Bank, bool>> predicate)
        {
            return this._BankReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<Bank> GetPageList(Expression<Func<Bank, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._BankReps.PageList(predicate, c => c.Desc(o => o.BankName), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Bank> GetList(Expression<Func<Bank, bool>> predicate)
        {
            return this._BankReps.ToList(predicate);
        }

        public ServiceResult Add(Bank model)
        {
            var result = new ServiceResult();
            this._BankReps.Add(model);

            return result.IsSucceed("新增银行成功");

        }

        public ServiceResult Update(Bank model)
        {
            var result = new ServiceResult();
            this._BankReps.Update(model);

            return result.IsSucceed("编辑银行成功");

        }
        public ServiceResult Delete(Expression<Func<Bank, bool>> predicate)
        {
            var result = new ServiceResult();
            this._BankReps.Delete(predicate);

            return result.IsSucceed("删除成功");

        }

        #endregion
    }
}
