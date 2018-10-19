using Max.Models.System;
using Max.Service.Auth;
using Max.Web.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Models.System.Common;
using Max.Service.Auth.Common;

namespace Max.Web.Management.Controllers
{
    public class PermissionController : BaseController
    {
        public PermissionService permissionService;
        private PermissionGroupService groupService; 

        public PermissionController(
            PermissionService permissionService,
            PermissionGroupService groupService
            )
        {
            this.permissionService = permissionService;
            this.groupService = groupService;
        }

        #region 权限列表

        public ActionResult List()
        {
            var groupList = this.permissionService.GetPermissionGroup(g => true).OrderByDescending(g=>g.CreateTime).ToList();

            // 已分组权限
            var grouped = groupList.Where(g=>!g.Permissions.IsNullOrEmpty())
                .Select(g => g.Permissions).SelectMany(s => s.Split(',')).Distinct();

            // 全部权限
            var all = PermissionUtil.PermissionUrls.Select(p => p.Value).Distinct();

            // 未分组权限
            var ungrouped = all.Except(grouped);

            // 定义了却没有使用的权限
            var allDefined = Enum.GetValues(typeof(PermCode)).Cast<int>().Distinct();
            var unUsed = allDefined.Except(all.Select(s=>int.Parse(s)));

            ViewBag.Unused = unUsed;

            groupList.Add(new SYS_PermissionGroup
            {
                GroupName = "未分组",
                Permissions = string.Join(",", ungrouped)
            });

            return AjaxView("List_Partial", groupList);
        }

        #endregion

        #region 新增/编辑/删除权限组

        public ActionResult AddOrEditGroup(string groupId)
        {
            if (groupId.IsNullOrEmpty())
                return View();

            var model = this.groupService.Get(g => g.GroupId == groupId);
            return View(model);
        }

        [Permission(PermCode.添加权限组)]
        [HttpPost]
        public ActionResult AddGroupForAjax(SYS_PermissionGroup model)
        {
            model.GroupId = Guid.NewGuid().ToString();
            model.CreateTime = DateTime.Now;
            return Json(this.groupService.Add(model));
        }

        [Permission(PermCode.编辑权限组)]
        [HttpPost]
        public ActionResult EditGroupForAjax(SYS_PermissionGroup model)
        {
            return Json(this.groupService.Update(model));
        }

        [Permission(PermCode.删除权限组)]
        [HttpPost]
        public ActionResult DeleteGroupAjax(string groupId)
        {
            return Json(this.groupService.Delete(groupId));
        }

        #endregion

        #region 添加权限到权限组

        [Permission(PermCode.添加权限到权限组)]
        [HttpPost]
        public ActionResult AddToGroupAjax(string groupId, int[] permissions)
        {
            var result = new ServiceResult();
            if (groupId.IsNullOrEmpty())
                return Json(result.IsFailed("权限组编号为空"));

            if (permissions.IsNull() || permissions.Length <= 0)
                return Json(result.IsFailed("请选择需要添加的权限"));

            return Json(this.groupService.AddToGroup(groupId, permissions));
        }

        #endregion

        #region 从权限组中删除权限

        [Permission(PermCode.从权限组中删除权限)]
        [HttpPost]
        public ActionResult DeleteFromGroupAjax(string groupId, int[] permissions)
        {
            var result = new ServiceResult();
            if (groupId.IsNullOrEmpty())
                return Json(result.IsFailed("权限组编号为空"));

            if (permissions.IsNull() || permissions.Length <= 0)
                return Json(result.IsFailed("请选择需要从组中删除的权限"));

            return Json(this.groupService.RemoveFromGroup(groupId, permissions));
        }

        #endregion
    }
}