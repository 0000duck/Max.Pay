using Max.Framework;
using Max.Framework.Authorization;
using Max.Framework.DAL;
using Max.Framework.File;
using Max.Framework.Redis;
using Max.Models.System;
using Max.Models.System.Common;
using Max.Service.Auth;
using Max.Service.Auth.Common;
using Max.Web.Management.Infrastructure;
using Max.Web.Management.Infrastructure.Razor;
using Max.Web.Management.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Max.Web.Management.Controllers
{
    public class AccountController : BaseController
    {
        private AccountService accountService;
        private ActionService actionService;
        private PermissionService permissionService;
        private RoleService roleService;
        private AuthLogService logService;

        public AccountController(
            AccountService accountService,
            ActionService actionService,
            PermissionService permissionService,
            RoleService roleService,
            AuthLogService logService
            )
        {
            this.accountService = accountService;
            this.actionService = actionService;
            this.permissionService = permissionService;
            this.roleService = roleService;
            this.logService = logService;
        }

        #region 登录相关

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var pwd = AuthorizeHelper.GetEncPassword(model.Password);
            var result = accountService.Login(model.UserName, pwd);
            if (result.Success)
            {
                var user = result.Get<SystemUser>("user");
                AuthorizeHelper.SignIn(user);

                string sidebar = string.Empty;
                int spa = 0;
                if (user.UserType == (int)UserType.超级管理员)
                {
                    sidebar = this.permissionService.GetSidebar();
                    spa = (int)UserType.超级管理员;
                }
                else
                {
                    var perms = this.permissionService.GetPermissions(user.UserId);
                    sidebar = perms.SiderbarHtml;
                    this.permissionService.SetPermissionCache(user.UserId, perms.CodeAndMenu);
                    result.Set("pcode", perms.CodeAndMenu);
                }

                result.Set("spa", spa);
                result.Set("user", null);
                result.Set("returnUrl", returnUrl);
                result.Set("sidebar", sidebar);
            }


            return Json(result);
        }

        public ActionResult Logout()
        {
            var userId = AuthorizeHelper.GetCurrentUser().UserId;
            permissionService.ClearPermissionCaching(userId);
            AuthorizeHelper.SignOut();
            var redirectUrl = "http://sso.qianduan.com?Action=Logout&ReturnUrl=http://" + HttpContext.Request.Url.Host;
            return new RedirectResult(redirectUrl);
        }

        #endregion

        #region 获取菜单缓存

        [HttpPost]
        public ActionResult GetLocalStorage()
        {
            var user = AuthorizeHelper.GetCurrentUser();
            string sidebar = string.Empty;
            int spa = 0;
            string pcode = string.Empty;
            if (user.UserType == (int)UserType.超级管理员)
            {
                sidebar = this.permissionService.GetSidebar();
                spa = (int)UserType.超级管理员;
            }
            else
            {
                var perms = this.permissionService.GetPermissions(user.UserId);
                sidebar = perms.SiderbarHtml;
                this.permissionService.SetPermissionCache(user.UserId, perms.CodeAndMenu);
                pcode = perms.CodeAndMenu;
            }

            return Json(new { spa = spa, pcode = pcode, sidebar = sidebar });
        }

        #endregion

        #region 查看账户信息

        public ActionResult UserInfo(string id)
        {
            var user = new SYS_User();
            if (!string.IsNullOrEmpty(id))
            {
                user = accountService.Get(u => u.SystemUserId == id);
            }
            return View(user);
        }

        #endregion

        #region 重置密码

        public ActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel { SystemUserId = id });
        }

        [HttpPost]
        public ActionResult ResetPasswordForAjax(ResetPasswordViewModel model)
        {
            ServiceResult result = new ServiceResult();
            if (ModelState.IsValid)
            {
                result = accountService.ResetPassword(
                    model.SystemUserId,
                    AuthorizeHelper.GetEncPassword(model.Password),
                    AuthorizeHelper.GetEncPassword(model.NewPassword)
                    );
            }
            else
            {
                result.IsFailed(ModelState.FirstError());
            }

            return Json(result);
        }

        #endregion

        #region 浏览管理员列表

        [Permission(PermCode.浏览管理员列表)]
        public ActionResult List(Query<SYS_User, ListParams> query)
        {
            var where = PredicateBuilder.True<SYS_User>();
            var args = query.Params;

            if (args.UserType.HasValue)
            {
                where = where.And(u => u.UserType == args.UserType);
            }

            if (!args.RealName.IsNullOrEmpty())
            {
                where = where.And(u => u.RealName.Contains(args.RealName));
            }

            if (!args.UserName.IsNullOrEmpty())
            {
                where = where.And(u => u.UserName.Contains(args.UserName));
            }

            if (args.UserStatus.HasValue)
            {
                where = where.And(u => u.Status == (args.UserStatus));
            }

            if (args.CreateTimeStart.HasValue)
            {
                where = where.And(u => u.CreateTime >= args.CreateTimeStart);
            }

            if (args.CreateTimeEnd.HasValue)
            {
                var end = args.CreateTimeEnd.Value.AddDays(1);
                where = where.And(u => u.CreateTime <= end);
            }

            accountService.GetUsers(query.__pageIndex, query.__pageSize, where)
                .UpdateQuery(query);

            return PageView(query);
        }

        #endregion

        #region 添加管理员

        [Permission(PermCode.添加管理员)]
        public ActionResult Add()
        {
            return View(new AccountAddModel
            {
                CreateTime = DateTime.Now
            });
        }

        [Permission(PermCode.添加管理员)]
        public ActionResult AddForAjax(AccountAddModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    return Json(new ServiceResult("密码输入").IsFailed());
                }
                SYS_User user = new SYS_User()
                {
                    SystemUserId = Guid.NewGuid().ToString(),
                    CreateTime = DateTime.Now,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = AuthorizeHelper.GetEncPassword(model.Password),
                    RealName = model.RealName,
                    UserName = model.UserName,
                    UserType = model.UserType,
                    Status = model.Status

                };
                return Json(this.accountService.Add(user));
            }
            else
            {

                return Json(new ServiceResult(GetModelStateMessage()).IsFailed());
            }
        }

        #endregion

        #region 编辑管理员

        [Permission(PermCode.编辑管理员)]
        public ActionResult Edit(string userId)
        {

            var user = this.accountService.Get(a => a.SystemUserId == userId);
            var model = new AccountEditModel
            {
                SystemUserId = user.SystemUserId,
                RealName = user.RealName,
                UserName = user.UserName,
                Email = user.Email,
                CreateTime = user.CreateTime,
                UserType = user.UserType,
                Mobile = user.Mobile,
                Status = user.Status
            };

            return View(model);
        }

        [Permission(PermCode.编辑管理员)]
        public ActionResult EditForAjax(AccountEditModel model)
        {
            if (ModelState.IsValid)
            {
                var user = accountService.Get(x => x.SystemUserId == model.SystemUserId);

                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.RealName = model.RealName;
                user.UserName = model.UserName;
                user.UserType = model.UserType;
                user.Status = model.Status;

                if (!string.IsNullOrEmpty(model.Password) && model.Password == model.ConfirmPassword)
                {
                    user.Password = AuthorizeHelper.GetEncPassword(model.Password);
                }

                return Json(this.accountService.Update(user));
            }
            else
            {
                return Json(new ServiceResult(GetModelStateMessage()).IsFailed());
            }
        }

        #endregion

        #region 编辑管理员所属角色

        [Permission(PermCode.编辑管理员所属角色)]
        public ActionResult Roles(string userId)
        {
            var user = this.accountService.Get(a => a.SystemUserId == userId);
            var userRoles = accountService.GetUserRoles(user.SystemUserId);
            var model = new AccountRolesModel
            {
                SystemUserId = user.SystemUserId,
                UserName = user.UserName,
                Roles = userRoles == null ? null : userRoles.Select(x => x.SystemRoleId).ToArray()

            };

            ViewBag.UserRoles = userRoles;
            var allRoles = roleService.PageList(x => true, 1, 1000).Items;
            //待选角色（未选中状态）

            if (userRoles != null)
            {
                var otherRoles = allRoles.Where(r => !userRoles.Any(ur => ur.SystemRoleId == r.SystemRoleId)).ToList();
                ViewBag.OtherRoles = otherRoles;
            }
            else
                ViewBag.OtherRoles = allRoles;

            return View(model);
        }

        [Permission(PermCode.编辑管理员所属角色)]
        public ActionResult RolesForAjax(AccountRolesModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(accountService.UpdateUserRoles(model.SystemUserId, model.Roles));
            }
            else
            {
                return Json(new ServiceResult(GetModelStateMessage()).IsFailed());
            }
        }

        #endregion

        #region 删除管理员

        [Permission(PermCode.删除管理员)]
        public ActionResult DeleteForAjax(string userId)
        {
            return Json(accountService.Delete(userId));

        }

        [Permission(PermCode.删除管理员)]
        public ActionResult BatchDeleteForAjax(string ids)
        {
            ids.ThrowIfNull("ids");

            foreach (var id in ids.Split(','))
            {
                var result = accountService.Delete(id);
                if (!result.Success)
                    return Json(result);
            }
            return Json(new ServiceResult() { ResultCode = 0, Message = "批量删除账户成功" });
        }

        #endregion

        #region 查看管理员权限
        
        public ActionResult Perms(string userId)
        {
            var user = accountService.Get(u => u.SystemUserId == userId);
            ViewBag.UserName = user.RealName;
            ViewBag.UserType = user.UserType;

            var res = accountService.GetPermsInfo(userId);
            var allPerms = res.Data["AllPerms"] as List<SYS_Permission>;
            var roles = res.Data["Roles"] as List<SYS_Role>;

            ViewData["AllPerms"] = allPerms;
            ViewData["Roles"] = roles;

            return View();
        }

        #endregion



        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoadStorageAjax()
        {
            string returnUrl = "";
            var result = new ServiceResult();

            var user = AuthorizeHelper.GetCurrentUser();
            if (user != null)
            {
                //删除cookie
                HttpCookie cookie = Request.Cookies["Storage"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-2);
                    Response.Cookies.Set(cookie);
                }

                string sidebar = string.Empty;
                int spa = 0;
                if (user.UserType == (int)UserType.超级管理员)
                {
                    sidebar = this.permissionService.GetSidebar();
                    spa = (int)UserType.超级管理员;
                }
                else
                {
                    var perms = this.permissionService.GetPermissions(user.UserId);
                    sidebar = perms.SiderbarHtml;
                    this.permissionService.SetPermissionCache(user.UserId, perms.CodeAndMenu);
                    result.Set("pcode", perms.CodeAndMenu);
                }
                result.Set("spa", spa);
                result.Set("user", null);
                result.Set("returnUrl", returnUrl);
                result.Set("sidebar", sidebar);
            }

            return Json(result);
        }


        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}