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
    public class AgentService : IService
    {

        #region 字段
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Agent> _agentReps;


        #endregion

        #region 构造函数

        public AgentService(
            IUnitOfWork unitOfWork,
            IRepository<Agent> agentReps
            )
        {
            this._unitOfWork = unitOfWork;
            this._agentReps = agentReps;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 根据查询条件获取实体CRD_Card结果
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Agent Get(Expression<Func<Agent, bool>> predicate)
        {
            return this._agentReps.Get(predicate, DbLock.NoLock);
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public PageList<Agent> GetPageList(Expression<Func<Agent, bool>> predicate,int pageIndex, int pageSize)
        {
            return this._agentReps.PageList(predicate, c => c.Desc(o => o.CreateTime), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Agent> GetList(Expression<Func<Agent, bool>> predicate)
        {
            return this._agentReps.ToList(predicate);
        }

        public ServiceResult Add(Agent model)
        {
            var result = new ServiceResult();
            this._agentReps.Add(model);

            return result.IsSucceed("新增代理成功");

        }

        public ServiceResult Update(Agent model)
        {
            var result = new ServiceResult();
            this._agentReps.Update(model);

            return result.IsSucceed("编辑代理成功");

        }
        public ServiceResult Update(Expression<Func<Agent, bool>> predicate, Expression<Func<Agent, Agent>> expression)
        {
            var result = new ServiceResult();
            this._agentReps.Update(predicate, expression);

            return result.IsSucceed("编辑代理成功");

        }
        public ServiceResult Delete(Expression<Func<Agent, bool>> predicate)
        {
            var result = new ServiceResult();
            this._agentReps.Delete(predicate);

            return result.IsSucceed("删除成功");

        }

        #endregion
    }
}
