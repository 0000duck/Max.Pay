using Max.Framework.DAL;
using Max.Models.System;
using Max.Web.Management.Infrastructure;
using Max.Web.Management.Infrastructure.Razor;
using Max.Web.Management.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Service.Auth;
using Max.Web.Helpers;
using Max.Models.System.Common;
using Max.Service.Auth.Common;

namespace Max.Web.Management.Controllers
{
    public class RolesController : BaseController
    {
        private RoleService roleService;
        private PermissionService permissionService;
        private ActionService actionService;
        private AuthLogService logService;
        private IRepository<SYS_Permission> permissionRepository;
        public RolesController(
            RoleService roleService,
            PermissionService permissionService,
            ActionService actionService,
            AuthLogService logService,
            IRepository<SYS_Permission> permissionRepository
            )
        {
            this.roleService = roleService;
            this.permissionService = permissionService;
            this.actionService = actionService;
            this.logService = logService;
            this.permissionRepository = permissionRepository;
        }

        #region 角色列表
        public ActionResult List(Query<SYS_Role, RoleParams> model)
        {
            var where = PredicateBuilder.True<SYS_Role>();

            if (!model.Params.RoleName.IsNullOrEmpty())
                where = where.And(a => a.RoleName.Contains(model.Params.RoleName));

            var pageList = this.roleService.PageList(where, model.__pageIndex, model.__pageSize);

            pageList.UpdateQuery(model);

            return PageView(model);
        }

        #endregion

        #region 新增/编辑/删除权限组

        public ActionResult AddOrEditRole(string roleId)
        {
            if (roleId.IsNullOrEmpty())
            {
                return View(new SYS_Role() { CreateTime = DateTime.Now });
            }
            var role = this.roleService.Get(g => g.SystemRoleId == roleId);

            return View(role);
        }


        [Permission(PermCode.编辑角色权限)]
        public ActionResult EditPermission(string roleId)
        {
            var role = this.roleService.Get(g => g.SystemRoleId == roleId);
            var model = new RolePermissionModel()
            {
                RoleName = role.RoleName,
                SystemRoleId = role.SystemRoleId,
                Permissions = role.Permissions.IsNullOrEmpty() ? new string[0] : role.Permissions.Split(',')
            };

            #region 权限数据
            var groupList = this.permissionService.GetPermissionGroup(g => true).OrderByDescending(g => g.CreateTime).ToList();

            // 已分组权限
            var grouped = groupList.Where(g => !g.Permissions.IsNullOrEmpty())
                .Select(g => g.Permissions).SelectMany(s => s.Split(',')).Distinct();

            // 全部权限
            var all = PermissionUtil.PermissionUrls.Select(p => p.Value).Distinct();

            // 未分组权限
            var ungrouped = all.Except(grouped);

            groupList.Add(new SYS_PermissionGroup
            {
                GroupName = "未分组",
                Permissions = string.Join(",", ungrouped)
            });

            ViewBag.GroupList = groupList;
            #endregion

            return View(model);
        }


        [Permission(PermCode.编辑角色权限)]
        [HttpPost]
        public ActionResult EditPermissionForAjax(RolePermissionModel model)
        {
            if (ModelState.IsValid)
            {
                var role = roleService.Get(x => x.SystemRoleId == model.SystemRoleId);

                role.Permissions = string.Join(",", model.Permissions ?? new string[0]).TrimEnd(',');

                return Json(this.roleService.Update(role));
            }
            return Json(new ServiceResult(GetModelStateMessage()));
        }

        [Permission(PermCode.添加角色)]
        [HttpPost]
        public ActionResult AddForAjax(SYS_Role model)
        {
            model.SystemRoleId = Guid.NewGuid().ToString();
            return Json(this.roleService.Add(model));
        }

        [Permission(PermCode.编辑角色)]
        [HttpPost]
        public ActionResult EditForAjax(SYS_Role model)
        {
            return Json(this.roleService.Update(model,
                x => new SYS_Role { RoleName = model.RoleName, Status = model.Status }));

        }

        [Permission(PermCode.删除角色)]
        [HttpPost]
        public ActionResult DeleteForAjax(string roleId)
        {
            return Json(this.roleService.Delete(roleId));
        }

        #endregion

        #region 角色下用户

        [Permission(PermCode.编辑角色用户)]
        public ActionResult UsersInRole(string roleId, string roleName, Query<V_UserRoles, UserInRoleParam> query)
        {
            roleId.ThrowIfNull("roleId");
            roleName.ThrowIfNull("roleName");

            query.Params.RoleId = roleId;

            this.roleService.GetUsersInRole(query.Params.RoleId, query.__pageIndex, query.__pageSize)
                .UpdateQuery(query);

            ViewBag.RoleId = roleId;
            ViewBag.RoleName = roleName;

            return PageView(query);
        }

        [Permission(PermCode.编辑角色用户)]
        [HttpPost]
        public ActionResult DeleteUserForAjax(string userId, string roleId)
        {
            return Json(roleService.RemoveUser(roleId, userId));
        }

        #endregion

        #region 角色下菜单

        [Permission(PermCode.编辑角色菜单)]
        public ActionResult ActionsInRole(string roleId, int systemId)
        {
            ViewBag.SystemId = systemId;
            roleId.ThrowIfNull("roleId");

            var role = this.roleService.Get(PredicateBuilder.True<SYS_Role>().And(r => r.SystemRoleId == roleId));
            var assignedActionList = this.roleService.GetActionsInRole(roleId);
            var where = PredicateBuilder.True<SYS_Action>();
            where = where.And(c => c.SystemId == systemId);
            var actionList = this.actionService.GetMenuList(where);
            MenuHelper.UpdateMenuName(actionList);
            var viewList = actionList.Select(a => new RoleActionsModel
            {
                ActionId = a.ActionId,
                ActionName = a.ActionName,
                IconClass = a.IconClass,
                ParentId = a.ParentId,
                IsAssigned = assignedActionList.Any(aa => aa.ActionId == a.ActionId),
                Url = a.Url
            });

            ViewBag.RoleName = role.RoleName;
            ViewBag.RoleId = roleId;

            var actionPerms = actionService.GetActionPerms();
            ViewData["ActionPerms"] = actionPerms;

            var pList = permissionRepository.ToList(p => p.SystemId == systemId);
            var permCodes = pList.Select(c => new KeyValuePair<int, string>(c.PermCode, c.PermName)).ToList();
            ViewData["PermCodes"] = permCodes;

            if (!string.IsNullOrEmpty(role.Permissions))
            {
                var perms = role.Permissions.Split('|');
                var rolePerms = "";
                foreach (var perm in perms)
                {
                    if (!string.IsNullOrEmpty(perm))
                    {
                        var type = perm.Split('#')[0];
                        if (int.Parse(type) == systemId)
                            rolePerms = perm.Split('#')[1];
                    }
                }

                ViewData["RolePerms"] = rolePerms;
            }
            return View(viewList);
        }

        [Permission(PermCode.编辑角色菜单)]
        [HttpPost]
        public ActionResult UpdateActionsInRoleForAjax(ActionsInRoleParam model)
        {
            if (ModelState.IsValid)
            {
                var roleId = model.RoleId;
                var actionIds = new List<string>();
                if (!model.ActionIds.IsNullOrEmpty())
                    actionIds = model.ActionIds.Split(',').ToList();
                var role = roleService.Get(x => x.SystemRoleId == model.RoleId);


                var oldPermissions = !string.IsNullOrEmpty(role.Permissions) ? role.Permissions.Split('|').ToList() : new List<string>();
                var oldPermList = new List<SYS_Permission>();
                var newPermList = new List<SYS_Permission>();
                for (var i = 0; i < oldPermissions.Count; i++)
                {
                    if (!string.IsNullOrEmpty(oldPermissions[i]))
                    {
                        var type = oldPermissions[i].Split('#')[0];
                        var oldPerms = oldPermissions[i].Split('#')[1];

                        if (int.Parse(type) == model.SystemId)
                        {
                            var oldPermCodes = oldPermissions[i].Split('#')[1].Split(',').Select(c => int.Parse(c)).ToList();
                            oldPermList = permissionRepository.ToList(p => oldPermCodes.Contains(p.PermCode));
                            oldPermissions.RemoveAt(i);
                            i--;
                        }
                    }
                }
                var newPerms = "";
                if (!model.PermCodes.IsNullOrEmpty())
                {
                    var perms = new List<string>();
                    perms.AddRange(model.PermCodes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                    perms = perms.Distinct().ToList();
                    newPerms = model.SystemId + "#" + perms.Aggregate((c, n) => c + "," + n);

                    var newPermCodes = perms.Select(p => int.Parse(p)).ToList();
                    newPermList = permissionRepository.ToList(p => newPermCodes.Contains(p.PermCode));
                }
                role.Permissions = ((oldPermissions.Count > 0 ? oldPermissions.Aggregate((c, n) => c + "|" + n) : "") + "|" + newPerms).Trim('|');

                this.roleService.Update(role);

               var newList = newPermList.Where(p => !oldPermList.Select(c => c.PermId).Contains(p.PermId)).ToList();
               var oldList = oldPermList.Where(p => !newPermList.Select(c => c.PermId).Contains(p.PermId)).ToList();

                var newPermNames = "";
                if (newList.Count > 0)
                    newPermNames = newList.Select(p => p.PermName + "[" + p.PermCode + "]").Aggregate((c, n) => c + "、" + n);
                var oldPermNames = "";
                if (oldList.Count > 0)
                    oldPermNames = oldList.Select(p => p.PermName + "[" + p.PermCode + "]").Aggregate((c, n) => c + "、" + n);

                if (!string.IsNullOrEmpty(newPermNames) || !string.IsNullOrEmpty(oldPermNames))
                {
                    var logStr = ((SystemType)model.SystemId) + "";
                    logStr += !string.IsNullOrEmpty(newPermNames) ? "【新增【" + newPermNames + "】】" : "";
                    logStr += !string.IsNullOrEmpty(oldPermNames) ? "【删除【" + oldPermNames + "】】" : "";
                    logService.Add(SystemLogType.角色权限变更, role.RoleName, logStr);
                }
                return Json(this.roleService.UpdateMenus(roleId, actionIds.ToArray(), model.SystemId));
            }
            return Json(new ServiceResult(GetModelStateMessage()));
        }
        #endregion


        #region 日志列表
        public ActionResult LogList(Query<SYS_Log, LogParams> model)
        {
            var where = PredicateBuilder.True<SYS_Log>();

            if (!model.Params.CreatedBy.IsNullOrEmpty())
                where = where.And(a => a.CreatedBy.Contains(model.Params.CreatedBy));

            if (!model.Params.Keyword.IsNullOrEmpty())
                where = where.And(a => a.KeyWord.Contains(model.Params.Keyword));

            if (model.Params.LogType.HasValue)
                where = where.And(a => a.LogType == model.Params.LogType.Value);

            if (model.Params.CreateTimeStart.HasValue)
                where = where.And(a => a.CreateTime >= model.Params.CreateTimeStart.Value);

            if (model.Params.CreateTimeEnd.HasValue)
                where = where.And(a => a.CreateTime >= model.Params.CreateTimeEnd.Value);

            var pageList = this.roleService.LogPageList(where, model.__pageIndex, model.__pageSize);

            pageList.UpdateQuery(model);

            return PageView(model);
        }

        #endregion
    }
}