using Max.Framework.DAL;
using Max.Models.System;
using Max.Service.Auth;
using Max.Web.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Web.Management.Models.Account;
using Max.Web.Management.Models.Menu;
using Max.Web.Management.Infrastructure.Razor;
using Max.Web.Helpers;
using System.Text.RegularExpressions;
using System.Reflection;
using Max.Web.Management.Models.Export;
using Max.Framework.File;
using Max.Models.System.Common;
using Max.Service.Auth.Common;

namespace Max.Web.Management.Controllers
{

    public class MenuController : BaseController
    {
        private IRepository<SYS_Permission> permissionRepository;
        private ActionService actionService;
        private IExcelClient excelClient;
        public MenuController(ActionService actionService, IExcelClient excelClient, IRepository<SYS_Permission> permissionRepository)
        {
            this.actionService = actionService;
            this.excelClient = excelClient;
            this.permissionRepository = permissionRepository;
        }

        #region 菜单管理

        public ActionResult List(Query<SYS_Action, MenuParams> model)
        {
            var where = PredicateBuilder.True<SYS_Action>();
            if (!model.Params.Name.IsNullOrEmpty())
                where = where.And(a => a.ActionName.Contains(model.Params.Name));

            if (!model.Params.Url.IsNullOrEmpty())
                where = where.And(a => a.Url.Contains(model.Params.Url));

            if (model.Params.SystemId <= 0)
                where = where.And(a => a.SystemId == (int)SystemType.运营后台);
            else
                where = where.And(a => a.SystemId == model.Params.SystemId);

            model.ItemList = this.actionService.GetMenuList(where).OrderBy(m => m.LevelSort);

            MenuHelper.UpdateMenuName(model.ItemList);

            return PageView(model);
        }

        #endregion

        #region 新增/编辑/删除菜单

        #region 辅助方法

        private IEnumerable<SelectListItem> GetMenuSelectList(string parendId, string actionId, int systemId)
        {
            var menuList = this.actionService.GetMenuList(m => m.SystemId == systemId)
                .OrderBy(m => m.LevelSort);

            MenuHelper.UpdateMenuName(menuList);

            var selectList = menuList.Select(m => new SelectListItem
               {
                   Text = m.ActionName,
                   Value = m.ActionId,
                   Selected = m.ActionId == parendId,
                   Disabled = !actionId.IsNullOrEmpty() && (IsSubMenu(m, actionId, menuList) || m.ActionId == actionId)
               }).ToList();

            selectList.Insert(0, new SelectListItem
            {
                Text = "",
                Value = ""
            });

            return selectList;
        }

        private bool IsSubMenu(SYS_Action child, string parentId, IEnumerable<SYS_Action> menus)
        {
            if (child.ParentId.IsNullOrEmpty())
                return false;
            var menu = menus.First(m => m.ActionId == child.ParentId);
            if (menu.ActionId == parentId)
                return true;
            return IsSubMenu(menu, parentId, menus);
        }

        #endregion

        public ActionResult AddOrEdit(string menuId, int systemId)
        {
            if (menuId.IsNullOrEmpty())
            {
                ViewBag.MenuList = GetMenuSelectList(null, menuId, systemId);
                return View(new SYS_Action { Sort = 0 });
            }

            var model = this.actionService.Get(a => a.ActionId == menuId);
            ViewBag.MenuList = GetMenuSelectList(model.ParentId, menuId, systemId);
            return View(model);
        }

        [Permission(PermCode.菜单权限)]
        public ActionResult PermModify(string menuId)
        {
            var menu = actionService.Get(m => m.ActionId == menuId);
            var pList = permissionRepository.ToList(p => p.SystemId == menu.SystemId);
            var url = menu.Url;
            if (url.Count(c => c == '/') > 2)
            {
                url = url.TrimStart('/');
                url = url.Substring(url.IndexOf("/"), url.Length - url.IndexOf("/"));
            }
            var controller = url.Count(c => c == '/') == 2 ? url.Substring(url.IndexOf("/") + 1, url.TrimStart('/').IndexOf("/")) : url.Substring(url.IndexOf("/") + 1, url.Length - 1);

            var permCodes = pList.Where(c => c.Controller == controller).Select(c => new KeyValuePair<int, string>(c.PermCode, c.PermName)).ToList();
            var oldPermCodes = actionService.GetActionPerms(menuId);
            ViewData["PermCodes"] = permCodes;
            ViewData["MenuId"] = menuId;
            ViewData["OldPermCodes"] = oldPermCodes;
            ViewData["OtherPermCodes"] = pList.Where(c => c.Controller != controller).OrderBy(c => c.Controller).ToList();
            return View();
        }

        [HttpPost]
        [Permission(PermCode.菜单权限)]
        public ActionResult PermModify(string menuId, string[] permCodes)
        {
            actionService.ModifyActionPerms(menuId, permCodes);
            return Json(new ServiceResult() { ResultCode = 0, Message = "操作成功" });
        }
        [Permission(PermCode.新增菜单)]
        [HttpPost]
        public ActionResult AddForAjax(SYS_Action model)
        {
            model.ActionId = Guid.NewGuid().ToString();
            model.CreateTime = DateTime.Now;
            return Json(this.actionService.AddMenu(model));
        }

        [Permission(PermCode.编辑菜单)]
        [HttpPost]
        public ActionResult EditForAjax(SYS_Action model)
        {
            return Json(this.actionService.EditMenu(model));
        }

        [Permission(PermCode.删除菜单)]
        [HttpPost]
        public ActionResult DeleteForAjax(string menuId)
        {
            return Json(this.actionService.DeleteMenu(menuId));
        }

        #endregion


        public void ExportMenuPerms(Query<SYS_Action, MenuParams> query)
        {
            var where = PredicateBuilder.True<SYS_Action>();

            where = where.And(m => m.SystemId == query.Params.SystemId);

            var list = this.actionService.GetMenuList(where).OrderBy(m => m.LevelSort).ToList();

            MenuHelper.UpdateMenuName(list);

            var permList = actionService.GetActionPerms();

            var exportList = new List<ExportMenuPerms>();
            var perms = actionService.GetPerms(query.Params.SystemId);
            foreach (var a in list)
            {
                var perm = permList.FirstOrDefault(p => p.ActionId == a.ActionId);

                if (perm != null)
                {
                    var permCodes = perm.PermCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var isFirst = true;
                    foreach (var code in permCodes)
                    {
                        var model = new ExportMenuPerms();
                        if (isFirst)
                        {
                            model.MenuName = a.ActionName;
                            isFirst = false;
                        }
                        var p = perms.FirstOrDefault(c => c.PermCode == int.Parse(code));
                        model.PermissionName = p == null ? "" : p.PermName;
                        exportList.Add(model);
                    }
                }
                else
                {
                    var model = new ExportMenuPerms();
                    model.MenuName = a.ActionName;
                    exportList.Add(model);
                }
            }
            excelClient.HttpExport(exportList, "菜单列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}