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
using Max.Service.Payment;
using Max.Models.Payment;

namespace Max.Web.Management.Controllers
{

    public class BankController : BaseController
    {
        private BankService _bankService;
        private IExcelClient excelClient;
        public BankController(BankService bankService, IExcelClient excelClient)
        {
            this._bankService = bankService;
            this.excelClient = excelClient;
        }

        #region 菜单管理

        public ActionResult List(Query<Bank, MenuParams> model)
        {
            var where = PredicateBuilder.True<Bank>();
            var pageList = this._bankService.GetPageList(where, model.__pageIndex, model.__pageSize);

            pageList.UpdateQuery(model);

            return PageView(model);

          
        }

        #endregion

        #region 新增/编辑/删除菜单
        

        public ActionResult AddOrEdit(string menuId, int systemId)
        {
            return View();
        }
        
        [Permission(PermCode.新增菜单)]
        [HttpPost]
        public ActionResult AddForAjax(Bank model)
        {
            model.BankId = Guid.NewGuid().ToString();
            model.BankName = model.BankName;
            return Json(this._bankService.Add(model));
        }

        [Permission(PermCode.编辑菜单)]
        [HttpPost]
        public ActionResult EditForAjax(Bank model)
        {
            return Json(this._bankService.Update(model));
        }

        [Permission(PermCode.删除菜单)]
        [HttpPost]
        public ActionResult DeleteForAjax(string menuId)
        {
            return Json(this._bankService.Delete(c=>c.BankId==menuId));
        }

        #endregion


        public void ExportMenuPerms(Query<Bank, MenuParams> query)
        {
            var where = PredicateBuilder.True<Bank>();



            var list = this._bankService.GetList(where).OrderBy(m => m.BankName).ToList();



            var exportList = new List<ExportMenuPerms>();
            foreach (var item in list)
            {

                var model = new ExportMenuPerms();
                model.PermissionName = item.BankName;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "银行列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}