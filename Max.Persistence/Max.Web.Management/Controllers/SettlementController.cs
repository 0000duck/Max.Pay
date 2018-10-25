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

    public class SettlementController : BaseController
    {
        private SettlementService _settlementService;
        private IExcelClient excelClient;
        public SettlementController(SettlementService settlementService, IExcelClient excelClient)
        {
            this._settlementService = settlementService;
            this.excelClient = excelClient;
        }

        #region 结算订单管理

        [Permission(PermCode.结算订单列表)]
        public ActionResult List(Query<Settlement, SettlementParams> query)
        {
            var where = PredicateBuilder.True<Settlement>();
            var param = query.Params;
            if (!param.OrderNo.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.OrderNo==param.OrderNo);
            }
            if (!param.MerchantOrderNo.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.MerchantOrderNo.Contains(param.MerchantOrderNo));
            }
            if (param.AuditStatus.HasValue)
            {
                where = where.And(c => c.AuditStatus == param.AuditStatus.Value);
            }
            if (param.SettleStatus.HasValue)
            {
                where = where.And(c => c.SettleStatus == param.SettleStatus.Value);
            }
            if (param.StartTime.HasValue)
            {
                where = where.And(c => c.CreateTime >= param.StartTime.Value);
            }
            if (param.EndTime.HasValue)
            {
                where = where.And(c => c.CreateTime <= param.EndTime.Value);

            }
            var pageList = this._settlementService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除结算订单


        public ActionResult AddOrEdit(string orderId)
        {
            var model = orderId.IsNullOrWhiteSpace() ? new Settlement() : this._settlementService.Get(c => c.OrderId == orderId);
            return View(model);
        }

        [Permission(PermCode.新增结算订单)]
        [HttpPost]
        public ActionResult AddForAjax(Settlement model)
        {
            model.OrderId = Guid.NewGuid().ToString();
            model.CreateTime = DateTime.Now;
            return Json(this._settlementService.Add(model));
        }

        [Permission(PermCode.编辑结算订单)]
        [HttpPost]
        public ActionResult EditForAjax(Settlement model)
        {
            return Json(this._settlementService.Update(c => c.OrderId == model.OrderId, c => new Settlement()
            {
                SettleStatus = model.SettleStatus,
                CallbackStatus = model.CallbackStatus
            }));
        }

        [Permission(PermCode.删除结算订单)]
        [HttpPost]
        public ActionResult DeleteForAjax(string serviceId)
        {
            return Json(this._settlementService.Delete(c => c.OrderId == serviceId));
        }

        #endregion

        [Permission(PermCode.导出结算订单列表)]
        public void ExportBanks(Query<Settlement, SettlementParams> query)
        {
            var where = PredicateBuilder.True<Settlement>();

            var list = this._settlementService.GetList(where).OrderBy(m => m.CreateTime).ToList();


            var exportList = new List<ExportBank>();
            foreach (var item in list)
            {

                var model = new ExportBank();
                //model.BankName = item.BankName;
                //model.BankCode = item.BankCode;
                //model.SeqNo = item.SeqNo;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "结算订单列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}