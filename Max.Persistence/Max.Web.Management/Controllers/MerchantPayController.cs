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

    public class MerchantPayController : BaseController
    {
        private MerchantPayProductService _mpService;
        private PayChannelService _payChannelService;
        private PayProductService _payProductService;

        private IExcelClient excelClient;
        public MerchantPayController(MerchantPayProductService mpService, IExcelClient excelClient, PayChannelService payChannelService, PayProductService payProductService)
        {
            this._mpService = mpService;
            this.excelClient = excelClient;
            this._payChannelService = payChannelService;
            this._payProductService = payProductService;
        }

        #region 支付产品管理

        [Permission(PermCode.支付产品列表)]
        public ActionResult List(Query<MerchantPayService, PayProductParams> query)
        {
            var where = PredicateBuilder.True<MerchantPayService>();
            var param = query.Params;
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
            var pageList = this._mpService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除支付产品


        public ActionResult AddOrEdit(string merchantId, string merchantPayServiceId, int serviceType = 0)
        {
            var model = merchantPayServiceId.IsNullOrWhiteSpace() ? new MerchantPayService() { MerchantId= merchantId, ServiceType = serviceType } : this._mpService.Get(c => c.MerchantPayServiceId == merchantPayServiceId);
            ViewData["PayProduct"] = GetPayProductDropdownList(model.ServiceType, model.ServiceId);
            ViewData["PayChannel"] = GetPayChannelDropdownList(model.ServiceType, model.PayChannelId);
            return View(model);
        }

        [Permission(PermCode.新增支付产品)]
        [HttpPost]
        public ActionResult AddForAjax(MerchantPayService model)
        {
            model.MerchantPayServiceId = Guid.NewGuid().ToString();
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;
            return Json(this._mpService.Add(model));
        }

        [Permission(PermCode.编辑支付产品)]
        [HttpPost]
        public ActionResult EditForAjax(MerchantPayService model)
        {
            return Json(this._mpService.Update(c => c.ServiceId == model.ServiceId, c => new MerchantPayService()
            {
                PayChannelId = model.PayChannelId,
                AgentFeeRate = model.AgentFeeRate,
                Remark = model.Remark,
                Status = model.Status,
                UpdateBy = CurrentSysUser.UserName,
                UpdateTime = DateTime.Now
            }));
        }

        [Permission(PermCode.删除支付产品)]
        [HttpPost]
        public ActionResult DeleteForAjax(string merchantPayServiceId)
        {
            return Json(this._mpService.Delete(c => c.ServiceId == merchantPayServiceId));
        }

        #endregion

        [Permission(PermCode.导出支付产品列表)]
        public void ExportBanks(Query<MerchantPayService, PayProductParams> query)
        {
            var where = PredicateBuilder.True<MerchantPayService>();

            var list = this._mpService.GetList(where).OrderBy(m => m.PayChannelId).ToList();


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


        public List<SelectListItem> GetPayChannelDropdownList(int channelType = 0, string channelId = "")
        {
            var payChannels = this._payChannelService.GetList(m => m.Status == (int)Enums.CommonStatus.正常 && m.ChannelType == channelType);
            List<SelectListItem> listItem = new List<SelectListItem>() { new SelectListItem() { Text = "-- 全部 --", Value = "" } };
            if (payChannels != null && payChannels.Count() > 0)
            {
                foreach (var item in payChannels)
                {
                    string value = item.ChannelId.ToString();


                    if (channelId != "" && channelId == value)
                    {
                        listItem.Add(new SelectListItem() { Value = value, Text = "{0}(费率{1})".Fmt(item.ChannelName, item.FeeRate), Selected = true });
                    }
                    else
                    {
                        listItem.Add(new SelectListItem() { Value = value, Text = "{0}(费率{1})".Fmt(item.ChannelName, item.FeeRate) });

                    }
                }
            }
            return listItem;
        }


        public List<SelectListItem> GetPayProductDropdownList(int channelType = 0, string channelId = "")
        {
            var payProducts = this._payProductService.GetList(m => m.Status == (int)Enums.CommonStatus.正常 && m.ServiceType == channelType);
            List<SelectListItem> listItem = new List<SelectListItem>() { new SelectListItem() { Text = "-- 全部 --", Value = "" } };
            if (payProducts != null && payProducts.Count() > 0)
            {
                foreach (var item in payProducts)
                {
                    string value = item.ServiceId.ToString();


                    if (channelId != "" && channelId == value)
                    {
                        listItem.Add(new SelectListItem() { Value = value, Text = "{0}({1})".Fmt(item.ServiceName, item.ServiceCode), Selected = true });
                    }
                    else
                    {
                        listItem.Add(new SelectListItem() { Value = value, Text = "{0}({1})".Fmt(item.ServiceName, item.ServiceCode) });

                    }
                }
            }
            return listItem;
        }
    }
}