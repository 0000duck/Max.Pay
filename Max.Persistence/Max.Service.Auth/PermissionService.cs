using Max.Framework.DAL;
using Max.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Framework;
using Max.Framework.Caching;
using Max.Service.Auth.Common;
using Max.Service.Auth.Domain;
using System.Linq.Expressions;

namespace Max.Service.Auth
{
    public class PermissionService : IService
    {
        private IRepository<SYS_User> userRepository;
        private IRepository<SYS_Action> actionRepository;
        private IRepository<SYS_PermissionGroup> groupRepository;
        private ICache cache;

        public PermissionService(
            IRepository<SYS_User> userRepository,
            IRepository<SYS_Action> actionRepository,
            IRepository<SYS_PermissionGroup> groupRepository,
            ICache cache
            )
        {
            this.userRepository = userRepository;
            this.actionRepository = actionRepository;
            this.groupRepository = groupRepository;
            this.cache = cache;
        }

        #region 是否超级管理员

        public bool IsSupperAdmin(string userId)
        {
            var userType = cache.GetOrSet(
                string.Format(CachingKeys.System_IsSupper_Format, userId),
                () => this.userRepository.GetEx(u => u.SystemUserId == userId, u => u.UserType).ToString()
                );

            return int.Parse(userType) == (int)Max.Models.System.Common.UserType.超级管理员;
        }

        #endregion

        #region 查询用户菜单及权限

        public PermissionSidebar GetPermissions(string userId)
        {
            var sql = @"
            WITH RoleActions AS
            (
            SELECT DISTINCT SR.ActionId FROM SYS_UserRoles UR
            INNER JOIN SYS_RoleMenus SR ON  UR.SystemRoleId = SR.RoleId
            INNER JOIN SYS_Role R ON SR.RoleId=R.SystemRoleId
            WHERE UR.SystemUserId = @userId AND R.Status=0
            )
            SELECT RAS.ActionId, SA.ParentId, SA.ActionName, SA.IconClass, SA.Url, SA.LevelSort FROM RoleActions RAS
            INNER JOIN SYS_Action SA ON RAS.ActionId = SA.ActionId and SA.SystemId=@SystemId;

            SELECT
            Permissions
            FROM SYS_UserRoles(NOLOCK) UR INNER JOIN SYS_Role(NOLOCK) RL
            ON UR.SystemRoleId = RL.SystemRoleId
            WHERE UR.SystemUserId = @userId and RL.Status=0
            ";

            var result = this.userRepository.Query<SYS_Action, string>(sql, new { @userId = userId, SystemId = (int)Max.Models.System.Common.SystemType.运营后台 });

            // 菜单URL部分
            var menuList = result[0].Cast<SYS_Action>().ToList();
            menuList = GetValidSidebar(menuList);

            // 权限编码部分
            var codeList = result[1].Cast<string>();
            var code = "";
            foreach (var codes in codeList)
            {
                if (!string.IsNullOrEmpty(codes))
                {
                    foreach (var c in codes.Split('|'))
                    {
                        if (!string.IsNullOrEmpty(c))
                        {
                            var type = c.Split('#')[0];
                            if (int.Parse(type) == (int)Max.Models.System.Common.SystemType.运营后台)
                                code += "," + c.Split('#')[1];
                        }
                    }
                }
            }

            var codeArray = code.Split(',').Distinct();

            var permList = menuList.Select(a => a.Url).Concat(codeArray);
            var codeAndMenu = ("," + string.Join(",", permList) + ",");

            var sidebar = BuildSidebar(menuList);

            return new PermissionSidebar
            {
                CodeAndMenu = codeAndMenu,
                SiderbarHtml = sidebar
            };
        }

        #endregion

        #region 用户权限缓存

        public void SetPermissionCache(string userId, string value)
        {
            cache.Set(string.Format(CachingKeys.System_Permission_Format, userId), value, 24 * 3600);
        }

        public string GetPermissionCache(string userId)
        {
            var key = string.Format(CachingKeys.System_Permission_Format, userId);
            return cache.GetOrSet(key, () => GetPermissions(userId).CodeAndMenu, 24 * 3600);
        }

        public void ClearPermissionCaching(string userId)
        {
            cache.Remove(string.Format(CachingKeys.System_IsSupper_Format, userId));
            cache.Remove(string.Format(CachingKeys.System_Permission_Format, userId));
        }

        #endregion

        #region 获取用户菜单

        /// <summary>
        /// 如果父菜单不存在，则把子菜单过滤
        /// </summary>
        /// <param name="menuList"></param>
        /// <returns></returns>
        private List<SYS_Action> GetValidSidebar(List<SYS_Action> menuList)
        {
            if (menuList == null) return new List<SYS_Action>();
            foreach (var item in menuList.OrderBy(m => m.LevelSort.Length))
            {
                if (!item.ParentId.IsNullOrEmpty() && !menuList.Exists(a => a.ActionId == item.ParentId && a.ActionName != "-1"))
                {
                    item.ActionName = "-1";
                }
            }
            return menuList.Where(m => m.ActionName != "-1").OrderBy(m => m.LevelSort).ToList();
        }

        public string GetSidebar()
        {
            var menuList = this.actionRepository.ToList(m => m.SystemId == (int)Max.Models.System.Common.SystemType.运营后台).OrderBy(m => m.LevelSort).ToList();
            menuList = GetValidSidebar(menuList);
            return BuildSidebar(menuList);
        }

        public string BuildSidebar(List<SYS_Action> menuList)
        {
            var lastLevel = -1;
            var builder = new StringBuilder();
            foreach (var item in menuList)
            {
                var level = (item.LevelSort.Split('-').Length + 1) / 2;

                if (lastLevel != -1)
                {
                    if (level < lastLevel)
                    {
                        for (var i = level; i < lastLevel; i++)
                            builder.AppendLine("</li></ul>");
                        builder.AppendLine("</li>");
                    }

                    if (level == lastLevel)
                        builder.AppendLine("</li>");

                    if (level > lastLevel)
                        builder.AppendLine("<ul class='sub-menu'>");
                }

                lastLevel = level;
                builder.Append("<li>");
                builder.AppendFormat("<a href='{0}'><i class='{1}'></i> <span class='title'>{2}</span>",
                    item.Url, item.IconClass, item.ActionName);
                if (!menuList.FirstOrDefault(m => m.ParentId == item.ActionId).IsNull())
                    builder.Append("<span class='arrow'></span>");
                builder.Append("</a>");
            }

            if (menuList.Count() > 0)
            {
                if (lastLevel == 1)
                    builder.AppendLine("</li>");
                else
                {
                    for (var i = 1; i < lastLevel; i++)
                        builder.AppendLine("</li></ul>");
                    builder.AppendLine("</li>");
                }
            }

            return builder.ToString();
        }

        #endregion

        #region 查询权限组

        public List<SYS_PermissionGroup> GetPermissionGroup(Expression<Func<SYS_PermissionGroup, bool>> predicate)
        {
            return this.groupRepository.ToList(predicate);
        }

        #endregion

        #region 查询所有系统菜单

        private string GetAllMenu()
        {
            var menuUrls = this.actionRepository.ToListEx(s => true, s => s.Url);
            return ",{0},".Fmt(string.Join(",", menuUrls));
        }

        public string GetAllMenusCached()
        {
            var key = CachingKeys.System_AllMenus;
            return cache.GetOrSet(key, GetAllMenu);
        }

        #endregion
    }
}
