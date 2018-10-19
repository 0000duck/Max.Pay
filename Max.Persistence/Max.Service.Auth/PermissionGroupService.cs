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
    public class PermissionGroupService : IService
    {
        private IRepository<SYS_PermissionGroup> groupRepository;

        public PermissionGroupService(IRepository<SYS_PermissionGroup> groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        #region 查询单个权限组

        public SYS_PermissionGroup Get(Expression<Func<SYS_PermissionGroup, bool>> predicate)
        {
            return this.groupRepository.Get(predicate);
        }

        #endregion

        #region 添加权限组

        public ServiceResult Add(SYS_PermissionGroup model)
        {
            var result = new ServiceResult();
            var ret = this.groupRepository.AddIfNotExists(model, g => g.GroupName == model.GroupName);
            if (ret > 0)
                return result.IsSucceed("添加权限组成功");
            else
                return result.IsFailed("添加失败，已存在同名权限组");
        }

        #endregion

        #region 删除权限组

        public ServiceResult Delete(string groupId)
        {
            var result = new ServiceResult();
            this.groupRepository.Delete(g => g.GroupId == groupId);
            return result.IsSucceed("删除权限组成功");
        }

        #endregion

        #region 编辑权限组

        public ServiceResult Update(SYS_PermissionGroup model)
        {
            var result = new ServiceResult();
            if (this.groupRepository.Exists(g => g.GroupName == model.GroupName && g.GroupId != model.GroupId))
                return result.IsFailed("编辑失败，已存在同名权限组");

            this.groupRepository.Update(model);
            return result.IsSucceed("更新权限组成功");
        }

        #endregion

        #region 添加权限到权限组

        public ServiceResult AddToGroup(string groupId, int[] permissions)
        {
            var result = new ServiceResult();
            var exists = this.groupRepository.GetEx(g => g.GroupId == groupId, g => g.Permissions);
            var extArray = exists.IsNullOrEmpty() ? new int[0] : exists.Split(',').Where(s => !s.IsNullOrEmpty()).Select(s=>int.Parse(s)).Distinct();
            var newArray = permissions.Union(extArray).Distinct();
            var newValue = string.Join(",", newArray);
            this.groupRepository.Update(g => g.GroupId == groupId, g => new SYS_PermissionGroup
            {
                Permissions = newValue
            });
            return result.IsSucceed("将权限添加到权限组成功");
        }

        #endregion

        #region 从权限组中删除权限

        public ServiceResult RemoveFromGroup(string groupId, int[] permissions)
        {
            var result = new ServiceResult();
            var exists = this.groupRepository.GetEx(g => g.GroupId == groupId, g => g.Permissions);
            var extArray = exists.IsNullOrEmpty() ? new int[0] : exists.Split(',').Where(s => !s.IsNullOrEmpty()).Select(s=>int.Parse(s)).Distinct();
            var newArray = extArray.Except(permissions);
            var newValue = string.Join(",", newArray);
            this.groupRepository.Update(g => g.GroupId == groupId, g => new SYS_PermissionGroup
            {
                Permissions = newValue
            });
            return result.IsSucceed("已从权限组中删除选中权限");
        }

        #endregion

    }
}
