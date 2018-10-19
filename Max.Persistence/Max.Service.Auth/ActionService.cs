using Max.Framework;
using Max.Framework.Caching;
using Max.Framework.DAL;
using Max.Models.System;
using Max.Models.System.Common;
using Max.Service.Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth
{
    public class ActionService : IService
    {
        private IUnitOfWork unitOfWork;
        private IRepository<SYS_Action> actionRepository;
        private IRepository<SYS_RoleMenus> rolemenuRepository;
        private IRepository<SYS_ActionPerms> actiomPermRepository;
        private IRepository<SYS_Permission> permRepository;
        private ICache cache;

        public ActionService(
            IUnitOfWork unitOfWork,
            IRepository<SYS_Action> actionRepository,
            IRepository<SYS_RoleMenus> rolemenuRepository,
            IRepository<SYS_ActionPerms> actiomPermRepository,
            IRepository<SYS_Permission> permRepository,
            ICache cache
            )
        {
            this.unitOfWork = unitOfWork;
            this.cache = cache;
            this.actionRepository = actionRepository;
            this.rolemenuRepository = rolemenuRepository;
            this.actiomPermRepository = actiomPermRepository;
            this.permRepository = permRepository;
        }

        #region 辅助方法

        private ServiceResult ValidMenuAction(SYS_Action action)
        {
            var result = new ServiceResult();

            action.Url = action.Url.ToFormatUrl();

            if (action.Url.Contains(','))
                return result.IsFailed("URL中不允许出现英文逗号字符");

            if (action.ParentId.IsNullOrEmpty())
            {
                action.LevelSort = string.Format("{0}-{1:yyyyMMddHHmmss}", action.Sort, action.CreateTime);
            }
            else
            {
                if (action.ParentId == action.ActionId)
                    return result.IsFailed("父菜单不能为自身");

                var parentLevelSort = this.actionRepository.GetEx(a => a.ActionId == action.ParentId, a => a.LevelSort);
                if (parentLevelSort.IsNull())
                    return result.IsFailed("找不到父菜单");

                var childList = GetChild(action.ActionId);
                if (childList.Contains(action.ParentId))
                    return result.IsFailed("不能把子菜单设置为自己的父菜单");

                action.LevelSort = string.Format("{0}-{1}-{2:yyyyMMddHHmmss}", parentLevelSort, action.Sort, action.CreateTime);
            }
            return result;
        }

        #endregion

        #region 查询菜单

        public SYS_Action Get(Expression<Func<SYS_Action, bool>> predicate)
        {
            return this.actionRepository.Get(predicate, DbLock.NoLock);
        }

        public SYS_Action[] Get(string userId)
        {
            return this.actionRepository.Query<SYS_Action>(@"
                select distinct * from sys_action where actionid 
                in (select actionid from SYS_RoleMenus where roleid 
                    in (select systemroleid from sys_userroles  where systemuserid=@userid)) order by LevelSort "
                , new { userid = userId }).ToArray();
        }

        private List<string> GetChild(string parentId)
        {
            var sql = @"
WITH CTE AS
 (
 SELECT ActionId FROM SYS_Action WHERE ParentId = @parentId
 UNION ALL
 SELECT SA.ActionId FROM SYS_Action SA
 INNER JOIN CTE ON SA.ParentId = CTE.ActionId
 )
 SELECT * FROM CTE";
            return this.actionRepository.Query<string>(sql, new { parentId = parentId }).ToList();
        }

        #endregion

        #region 编辑菜单

        public ServiceResult EditMenu(SYS_Action action)
        {
            var result = new ServiceResult();
            result = ValidMenuAction(action);
            if (!result.Success)
                return result;

            var oldLevelSort = this.actionRepository.GetEx(a => a.ActionId == action.ActionId, a => a.LevelSort);

            using (var tran = this.unitOfWork.BeginTransaction())
            {
                this.actionRepository.Update(action, tran);

                // 如果 Sort 字段更改了，对应更改子菜单 LevelSort
                if (action.LevelSort != oldLevelSort)
                {
                    var oldLevelSortStart = oldLevelSort + "-";
                    var childList = this.actionRepository.ToListEx(a => a.LevelSort.StartsWith(oldLevelSortStart), a => new
                    {
                        a.ActionId,
                        a.LevelSort
                    });

                    foreach (var child in childList)
                    {
                        var oldChildLevelSort = this.actionRepository.GetEx(a => a.ActionId == child.ActionId, a => a.LevelSort);
                        var newChildLevelSort = oldChildLevelSort.Replace(oldLevelSortStart, action.LevelSort + "-");
                        this.actionRepository.Update(a => a.ActionId == child.ActionId, a => new SYS_Action
                        {
                            LevelSort = newChildLevelSort
                        }, tran);
                    }
                }

                tran.Commit();
            }

            result.Set("action", action);
            RemoAllMenuCached();
            return result.IsSucceed("编辑菜单成功");
        }

        #endregion

        #region 添加菜单

        public ServiceResult AddMenu(SYS_Action action)
        {
            var result = new ServiceResult();
            result = ValidMenuAction(action);
            if (!result.Success)
                return result;

            this.actionRepository.Add(action);
            RemoAllMenuCached();
            result.Set("action", action);
            return result.IsSucceed("添加菜单成功");
        }

        #endregion

        #region 删除菜单

        public ServiceResult DeleteMenu(string menuId)
        {
            var result = new ServiceResult();
            var deleteList = GetChild(menuId);
            deleteList.Add(menuId);
            using (var tran = this.unitOfWork.BeginTransaction())
            {
                this.actionRepository.Delete(m => deleteList.Contains(m.ActionId), tran);
                this.rolemenuRepository.Delete(rm => deleteList.Contains(rm.ActionId), tran);
                tran.Commit();
            }
            RemoAllMenuCached();
            return result.IsSucceed("删除菜单成功");
        }

        #endregion

        #region 获取菜单列表

        public List<SYS_Action> GetMenuList(Expression<Func<SYS_Action, bool>> predicate)
        {
            return this.actionRepository.ToList(predicate, o => o.Asc(a => a.LevelSort), DbLock.NoLock, true);
        }

        #endregion

        #region 清除菜单缓存

        public void RemoAllMenuCached()
        {
            cache.Remove(CachingKeys.System_AllMenus);
        }

        #endregion

        public void ModifyActionPerms(string actionId, string[] permCodes)
        {
            actiomPermRepository.Delete(c => c.ActionId == actionId);
            var codes = permCodes.Aggregate((c, n) => c + "," + n);
            actiomPermRepository.Add(new SYS_ActionPerms { ActionId = actionId, PermCode = codes, CreateTime = DateTime.Now });
        }
        public string GetActionPerms(string actionId)
        {
            var a = actiomPermRepository.Get(c => c.ActionId == actionId);
            if (a != null)
                return a.PermCode;
            else
                return "";
        }

        public List<SYS_ActionPerms> GetActionPerms()
        {
            return actiomPermRepository.ToList(c => true);
        }

        public List<SYS_Permission> GetPerms(int systemId)
        {
            return permRepository.ToList(c => c.SystemId == systemId);
        }
    }
}
