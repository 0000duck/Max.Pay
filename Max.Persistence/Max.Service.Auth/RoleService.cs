using Max.Framework;
using Max.Framework.DAL;
using Max.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth
{
    public class RoleService : IService
    {
        private IUnitOfWork unitOfWork;
        private IRepository<SYS_Role> roleRepository;
        private IRepository<SYS_UserRoles> userRolesRepository;
        private IRepository<V_UserRoles> userRolesView;
        private IRepository<SYS_RoleMenus> roleMenusRepository;
        private IRepository<SYS_Action> actionRepository;
        private IRepository<SYS_Log> logRepository;

        public RoleService(
            IUnitOfWork unitOfWork,
            IRepository<SYS_Role> roleRepository,
            IRepository<SYS_UserRoles> userRolesRepository,
            IRepository<V_UserRoles> userRolesView,
            IRepository<SYS_RoleMenus> roleMenusRepository,
            IRepository<SYS_Action> actionRepository,
            IRepository<SYS_Log> logRepository
            )
        {
            this.unitOfWork = unitOfWork;
            this.roleRepository = roleRepository;
            this.userRolesRepository = userRolesRepository;
            this.userRolesView = userRolesView;
            this.roleMenusRepository = roleMenusRepository;
            this.actionRepository = actionRepository;
            this.logRepository = logRepository;
        }

        public SYS_Role Get(Expression<Func<SYS_Role, bool>> predicate)
        {
            return roleRepository.Get(predicate);
        }
        public PageList<SYS_Role> PageList(Expression<Func<SYS_Role, bool>> predicate, int pageIndex, int pageSize)
        {
            return roleRepository.PageList(predicate, o => o.Asc(r => r.CreateTime), pageIndex, pageSize);
        }

        public ServiceResult Add(SYS_Role model)
        {
            var result = new ServiceResult();
            var eff = this.roleRepository.AddIfNotExists(model, r => r.RoleName == model.RoleName && r.SystemRoleId != model.SystemRoleId);
            if (eff > 0)
                return result.IsSucceed("添加角色成功");
            else
                return result.IsFailed("添加角色失败，已存在同名角色");
        }

        public ServiceResult Delete(string roleId)
        {
            var result = new ServiceResult();
            using (var tran = this.unitOfWork.BeginTransaction())
            {
                this.roleRepository.Delete(r => r.SystemRoleId == roleId, tran);
                this.userRolesRepository.Delete(r => r.SystemRoleId == roleId, tran);
                this.roleMenusRepository.Delete(r => r.RoleId == roleId, tran);
                tran.Commit();
            }
            return result.IsSucceed("删除角色成功");
        }

        public ServiceResult Update(SYS_Role model)
        {
            var result = new ServiceResult();
            if (this.roleRepository.Exists(r => r.RoleName == model.RoleName && r.SystemRoleId != model.SystemRoleId))
                return result.IsFailed("修改角色失败，已存在同名角色");
            this.roleRepository.Update(model);
            return result.IsSucceed("修改角色成功");
        }


        public ServiceResult UpdateMenus(string roleId, string[] actionIds, int systemId)
        {
            roleId.ThrowIfNull("roleId");
            var result = new ServiceResult();
            var roleMenus = new List<SYS_RoleMenus>();
            //roleMenusRepository.Delete(x => x.RoleId == roleId);
            roleMenusRepository.Execute("delete r from SYS_RoleMenus r join SYS_Action a on r.ActionId=a.ActionId where a.SystemId=@SystemId and r.RoleId=@RoleId", new { SystemId = systemId, RoleId = roleId });
            if (actionIds != null && actionIds.Length > 0)
            {
                foreach (var id in actionIds)
                {
                    roleMenus.Add(new SYS_RoleMenus() { ActionId = id, RoleId = roleId, CreateTime = DateTime.Now });
                }
                roleMenusRepository.Add(roleMenus);
            }

            return result.IsSucceed("设置角色菜单成功");
        }

        public ServiceResult Update(SYS_Role model, Expression<Func<SYS_Role, SYS_Role>> expression)
        {
            var result = new ServiceResult();
            if (this.roleRepository.Exists(r => r.RoleName == model.RoleName && r.SystemRoleId != model.SystemRoleId))
                return result.IsFailed("修改角色失败，已存在同名角色");
            this.roleRepository.Update(x => x.SystemRoleId == model.SystemRoleId, expression);
            return result.IsSucceed("修改角色成功");
        }

        public PageList<V_UserRoles> GetUsersInRole(string roleId, int pageIndex, int pageSize)
        {
            return userRolesView.PageList(v => v.SystemRoleId == roleId, o => o.Asc(u => u.CreateTime), pageIndex, pageSize);
        }

        public List<SYS_Action> GetActionsInRole(string roleId)
        {
            return actionRepository.Query<SYS_Action>(
             "select * from sys_action where Actionid in(select ActionId from sys_rolemenus where roleid=@roleid)", new { roleid = roleId }).ToList();

        }

        /// <summary>
        /// 从角色中剔除用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ServiceResult RemoveUser(string roleId, string userId)
        {
            var result = new ServiceResult();
            if (userRolesRepository.Delete(x => x.SystemRoleId == roleId && x.SystemUserId == userId) > 0)
            {
                return result.IsSucceed("删除角色用户成功");
            }
            else
            {
                return result.IsSucceed("删除角色用户失败");
            }

        }


        /// <summary>
        /// 根据用户id获取角色  MAX
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SYS_Role> GetRolesByUserId(string userId)
        {
            var result = new ServiceResult();

            string sql = @"SELECT * FROM SYS_Role AS sr WHERE sr.SystemRoleId IN 
                        (
	                        SELECT sur.SystemRoleId
	                        FROM SYS_UserRoles AS sur WHERE sur.SystemUserId=@UserId
                         )";

            var res = this.roleRepository.Query<SYS_Role>(sql, new { @UserId = userId });
            var roles = res.ToList();
            return roles;
        }
        public PageList<SYS_Log> LogPageList(Expression<Func<SYS_Log, bool>> predicate, int pageIndex, int pageSize)
        {
            return logRepository.PageList(predicate, o => o.Desc(r => r.CreateTime), pageIndex, pageSize);
        }
    }
}
