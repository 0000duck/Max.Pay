using Max.Framework;
using Max.Framework.DAL;
using Max.Models.CarInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.CarInsurance
{
    public class VhlInfoService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<VhlInfo> _vhlInfoReps;


        #endregion

        #region 构造函数

        public VhlInfoService(
            IUnitOfWork unitOfWork,
            IRepository<VhlInfo> vhlInfoReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._vhlInfoReps = vhlInfoReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public VhlInfo Get(Expression<Func<VhlInfo, bool>> predicate)
        {
            return this._vhlInfoReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<VhlInfo> GetPageList(int pageIndex, int pageSize, Expression<Func<VhlInfo, bool>> predicate)
        {
            return this._vhlInfoReps.PageList(predicate, c => c.Desc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<VhlInfo> GetList(Expression<Func<VhlInfo, bool>> predicate)
        {
            return this._vhlInfoReps.ToList(predicate);
        }

        public ServiceResult Add(VhlInfo model)
        {
            var result = new ServiceResult();
            this._vhlInfoReps.Add(model);

            return result.IsSucceed("新增卡券成功");

        }

        public ServiceResult Update(VhlInfo model)
        {
            var result = new ServiceResult();
            this._vhlInfoReps.Update(model);

            return result.IsSucceed("编辑卡券成功");

        }

        #endregion
    }
}
