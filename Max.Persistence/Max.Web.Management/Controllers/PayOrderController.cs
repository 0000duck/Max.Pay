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

    public class PayOrderController : BaseController
    {
        private PayOrderService _payOrderService;
        private IExcelClient excelClient;
        public PayOrderController(PayOrderService payOrderService, IExcelClient excelClient)
        {
            this._payOrderService = payOrderService;
            this.excelClient = excelClient;
        }

        #region 支付订单管理

        [Permission(PermCode.支付订单列表)]
        public ActionResult List(Query<PayOrder, PayOrderParams> query)
        {
            var where = PredicateBuilder.True<PayOrder>();
            var param = query.Params;
            if (!param.OrderNo.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.OrderNo==param.OrderNo);
            }
            if (!param.MerchantOrderNo.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.MerchantOrderNo.Contains(param.MerchantOrderNo));
            }
            if (param.ChannelType.HasValue)
            {
                where = where.And(c => c.ChannelType == param.ChannelType.Value);
            }
            if (param.PayStatus.HasValue)
            {
                where = where.And(c => c.PayStatus == param.PayStatus.Value);
            }
            if (param.StartTime.HasValue)
            {
                where = where.And(c => c.CreateTime >= param.StartTime.Value);
            }
            if (param.EndTime.HasValue)
            {
                where = where.And(c => c.CreateTime <= param.EndTime.Value);

            }
            var pageList = this._payOrderService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除支付订单


        public ActionResult AddOrEdit(string orderId)
        {
            var model = orderId.IsNullOrWhiteSpace() ? new PayOrder() : this._payOrderService.Get(c => c.OrderId == orderId);
            return View(model);
        }

        [Permission(PermCode.新增支付订单)]
        [HttpPost]
        public ActionResult AddForAjax(PayOrder model)
        {
            model.ServiceId = Guid.NewGuid().ToString();
            model.CreateTime = DateTime.Now;
            return Json(this._payOrderService.Add(model));
        }

        [Permission(PermCode.编辑支付订单)]
        [HttpPost]
        public ActionResult EditForAjax(PayOrder model)
        {
            return Json(this._payOrderService.Update(c => c.ServiceId == model.ServiceId, c => new PayOrder()
            {
                PayStatus = model.PayStatus,
                NotifyStatus = model.NotifyStatus
            }));
        }

        [Permission(PermCode.删除支付订单)]
        [HttpPost]
        public ActionResult DeleteForAjax(string serviceId)
        {
            return Json(this._payOrderService.Delete(c => c.ServiceId == serviceId));
        }

        #endregion

        [Permission(PermCode.导出支付订单列表)]
        public void ExportBanks(Query<PayOrder, PayOrderParams> query)
        {
            var where = PredicateBuilder.True<PayOrder>();

            var list = this._payOrderService.GetList(where).OrderBy(m => m.CreateTime).ToList();


            var exportList = new List<ExportBank>();
            foreach (var item in list)
            {

                var model = new ExportBank();
                //model.BankName = item.BankName;
                //model.BankCode = item.BankCode;
                //model.SeqNo = item.SeqNo;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "支付订单列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}