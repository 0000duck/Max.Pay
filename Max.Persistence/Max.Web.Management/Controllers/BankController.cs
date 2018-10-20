using Max.Framework.DAL;
using Max.Web.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Web.Management.Infrastructure.Razor;
using Max.Web.Management.Models.Export;
using Max.Framework.File;
using Max.Service.Auth.Common;
using Max.Service.Payment;
using Max.Models.Payment;
using Max.Web.Management.Models.Payment;

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

        [Permission(PermCode.银行列表)]
        public ActionResult List(Query<Bank, BankParams> query)
        {
            var where = PredicateBuilder.True<Bank>();
            var param = query.Params;
            if (!param.BankName.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.BankName.Contains(param.BankName));
            }
            if (!param.BankCode.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.BankCode.Contains(param.BankCode));
            }
            if (param.Status.HasValue)
            {
                where = where.And(c => c.Status == param.Status);
            }
            var pageList = this._bankService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除菜单


        public ActionResult AddOrEdit(string bankId)
        {
            var model = bankId.IsNullOrWhiteSpace() ? new Bank() : this._bankService.Get(c => c.BankId == bankId);
            return View(model);
        }

        [Permission(PermCode.新增银行)]
        [HttpPost]
        public ActionResult AddForAjax(Bank model)
        {
            model.BankId = Guid.NewGuid().ToString();
            return Json(this._bankService.Add(model));
        }

        [Permission(PermCode.编辑银行)]
        [HttpPost]
        public ActionResult EditForAjax(Bank model)
        {
            return Json(this._bankService.Update(model));
        }

        [Permission(PermCode.删除银行)]
        [HttpPost]
        public ActionResult DeleteForAjax(string bankId)
        {
            return Json(this._bankService.Delete(c => c.BankId == bankId));
        }

        #endregion

        [Permission(PermCode.导出银行列表)]
        public void ExportBanks(Query<Bank, BankParams> query)
        {
            var where = PredicateBuilder.True<Bank>();

            var list = this._bankService.GetList(where).OrderBy(m => m.BankName).ToList();


            var exportList = new List<ExportBank>();
            foreach (var item in list)
            {

                var model = new ExportBank();
                model.BankName = item.BankName;
                model.BankCode = item.BankCode;
                model.SeqNo = item.SeqNo;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "银行列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}