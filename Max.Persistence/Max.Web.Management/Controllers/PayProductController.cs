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

    public class PayProductController : BaseController
    {
        private PayProductService _payProductService;
        private IExcelClient excelClient;
        public PayProductController(PayProductService payProductService, IExcelClient excelClient)
        {
            this._payProductService = payProductService;
            this.excelClient = excelClient;
        }

        #region 支付产品管理

        [Permission(PermCode.支付产品列表)]
        public ActionResult List(Query<PayService, PayProductParams> query)
        {
            var where = PredicateBuilder.True<PayService>();
            var param = query.Params;
            if (!param.ServiceName.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.ServiceName.Contains(param.ServiceName));
            }
            if (!param.ServiceCode.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.ServiceCode.Contains(param.ServiceCode));
            }
            if (param.ServiceType.HasValue)
            {
                where = where.And(c => c.ServiceType == param.ServiceType.Value);
            }
            if (param.Status.HasValue)
            {
                where = where.And(c => c.Status == param.Status.Value);
            }
            var pageList = this._payProductService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除支付产品


        public ActionResult AddOrEdit(string serviceId)
        {
            var model = serviceId.IsNullOrWhiteSpace() ? new PayService() : this._payProductService.Get(c => c.ServiceId == serviceId);
            return View(model);
        }

        [Permission(PermCode.新增支付产品)]
        [HttpPost]
        public ActionResult AddForAjax(PayService model)
        {
            model.ServiceId = Guid.NewGuid().ToString();
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;
            return Json(this._payProductService.Add(model));
        }

        [Permission(PermCode.编辑支付产品)]
        [HttpPost]
        public ActionResult EditForAjax(PayService model)
        {
            return Json(this._payProductService.Update(c => c.ServiceId == model.ServiceId, c => new PayService()
            {
                ServiceName = model.ServiceName,
                ServiceCode = model.ServiceCode,
                Remark = model.Remark,
                ServiceType = model.ServiceType,
                Status = model.Status,
                UpdateBy = CurrentSysUser.UserName,
                UpdateTime = DateTime.Now
            }));
        }

        [Permission(PermCode.删除支付产品)]
        [HttpPost]
        public ActionResult DeleteForAjax(string serviceId)
        {
            return Json(this._payProductService.Delete(c => c.ServiceId == serviceId));
        }

        #endregion

        [Permission(PermCode.导出支付产品列表)]
        public void ExportBanks(Query<PayService, PayProductParams> query)
        {
            var where = PredicateBuilder.True<PayService>();

            var list = this._payProductService.GetList(where).OrderBy(m => m.ServiceType).ToList();


            var exportList = new List<ExportBank>();
            foreach (var item in list)
            {

                var model = new ExportBank();
                //model.BankName = item.BankName;
                //model.BankCode = item.BankCode;
                //model.SeqNo = item.SeqNo;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "支付产品列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}