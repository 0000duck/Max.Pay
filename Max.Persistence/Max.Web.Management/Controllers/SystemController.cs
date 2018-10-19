using Max.Framework;
using Max.Framework.DAL.SqlServer;
using Max.Models.System;
using Max.Service.Auth;
using Max.Web.Management.Infrastructure;
using Max.Web.Management.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Max.Web.Management.Controllers
{
    public class SystemController : BaseController
    {
        private AccountService userService;
        private ActionService actionService;

        public SystemController(
            AccountService userService,
            ActionService actionService
            )
        {
            this.userService = userService;
            this.actionService = actionService;
        }

        #region 系统图标

        public ActionResult Icon()
        {
            return View();
        }

        #endregion
    }
}