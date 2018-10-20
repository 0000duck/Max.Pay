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
using Max.Models.Payment.Common;

namespace Max.Web.Management.Controllers
{

    public class PayChannelController : BaseController
    {
        private PayChannelService _payChannelService;
        private IExcelClient excelClient;
        public PayChannelController(PayChannelService payChannelService, IExcelClient excelClient)
        {
            this._payChannelService = payChannelService;
            this.excelClient = excelClient;
        }

        #region 支付渠道管理

        [Permission(PermCode.支付渠道列表)]
        public ActionResult List(Query<PayChannel, PayProductParams> query)
        {
            var where = PredicateBuilder.True<PayChannel>();
            var param = query.Params;
            where = where.And(c => c.Isdelete == (int)Enums.IsDelete.否);
            //if (!param.ServiceName.IsNullOrWhiteSpace())
            //{
            //    where = where.And(c => c.ServiceName.Contains(param.ServiceName));
            //}
            //if (!param.ServiceCode.IsNullOrWhiteSpace())
            //{
            //    where = where.And(c => c.ServiceCode.Contains(param.ServiceCode));
            //}
            //if (param.ServiceType.HasValue)
            //{
            //    where = where.And(c => c.ServiceType == param.ServiceType.Value);
            //}
            if (param.Status.HasValue)
            {
                where = where.And(c => c.Status == param.Status.Value);
            }
            var pageList = this._payChannelService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除支付渠道


        public ActionResult AddOrEdit(string payChannelId)
        {
            var model = payChannelId.IsNullOrWhiteSpace() ? new PayChannel() : this._payChannelService.Get(c => c.ChannelId == payChannelId);
            return View(model);
        }

        [Permission(PermCode.新增支付渠道)]
        [HttpPost]
        public ActionResult AddForAjax(PayChannel model)
        {
            model.ChannelId = Guid.NewGuid().ToString();
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;
            return Json(this._payChannelService.Add(model));
        }

        [Permission(PermCode.编辑支付渠道)]
        [HttpPost]
        public ActionResult EditForAjax(PayChannel model)
        {
            return Json(this._payChannelService.Update(c => c.ChannelId == model.ChannelId, c => new PayChannel()
            {
                ChannelName = model.ChannelName,
                MerchantInfo = model.MerchantInfo,
                Remark = model.Remark,
                MinOrderAmount = model.MinOrderAmount,
                MaxOrderAmount = model.MaxOrderAmount,
                PaySite = model.PaySite,
                FeeRate = model.FeeRate,
                Status = model.Status,
                UpdateBy = CurrentSysUser.UserName,
                UpdateTime = DateTime.Now
            }));
        }

        [Permission(PermCode.删除支付渠道)]
        [HttpPost]
        public ActionResult DeleteForAjax(string payChannelId)
        {
            return Json(this._payChannelService.Delete(c => c.ChannelId == payChannelId));
        }

        #endregion

        [Permission(PermCode.导出支付渠道列表)]
        public void ExportBanks(Query<PayChannel, PayProductParams> query)
        {
            var where = PredicateBuilder.True<PayChannel>();

            var list = this._payChannelService.GetList(where).OrderBy(m => m.ChannelId).ToList();


            var exportList = new List<ExportBank>();
            foreach (var item in list)
            {

                var model = new ExportBank();
                //model.BankName = item.BankName;
                //model.BankCode = item.BankCode;
                //model.SeqNo = item.SeqNo;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "支付渠道列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}