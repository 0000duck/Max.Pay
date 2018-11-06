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



        #region 新增/编辑/删除商户支付产品


        public ActionResult AddOrEdit(string merchantId, string serviceId, string merchantPayServiceId, int serviceType = 0)
        {
            var model = merchantPayServiceId.IsNullOrWhiteSpace() ? new MerchantPayService() { MerchantId = merchantId, ServiceType = serviceType, ServiceId = serviceId } : this._mpService.Get(c => c.MerchantPayServiceId == merchantPayServiceId);
            ViewData["PayProduct"] = GetPayProductDropdownList(model.ServiceType, model.ServiceId);
            ViewData["PayChannel"] = GetPayChannelDropdownList(model.ServiceType, model.PayChannelId);
            return View(model);
        }

        [Permission(PermCode.开通商户支付产品)]
        [HttpPost]
        public ActionResult AddForAjax(MerchantPayService model)
        {
            model.MerchantPayServiceId = Guid.NewGuid().ToString();
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;
            model.MerchantFeeRate = model.MerchantFeeRate / 100;
            model.AgentFeeRate = model.AgentFeeRate / 100;
            return Json(this._mpService.Add(model));
        }

        [Permission(PermCode.编辑商户支付产品)]
        [HttpPost]
        public ActionResult EditForAjax(MerchantPayService model)
        {
            return Json(this._mpService.Update(c => c.ServiceId == model.ServiceId, c => new MerchantPayService()
            {
                PayChannelId = model.PayChannelId,
                AgentFeeRate = model.AgentFeeRate/100,
                MerchantFeeRate=model.MerchantFeeRate/100,
                Remark = model.Remark,
                Status = model.Status,
                UpdateBy = CurrentSysUser.UserName,
                UpdateTime = DateTime.Now
            }));
        }

        [Permission(PermCode.删除商户支付产品)]
        [HttpPost]
        public ActionResult DeleteForAjax(string merchantPayServiceId)
        {
            return Json(this._mpService.Delete(c => c.ServiceId == merchantPayServiceId));
        }

        #endregion



        public List<SelectListItem> GetPayChannelDropdownList(int channelType = 0, string channelId = "")
        {
            var payChannels = this._payChannelService.GetList(m => m.Status == (int)Enums.CommonStatus.正常 &&m.Isdelete==(int)Enums.IsDelete.否 && m.ChannelType == channelType);
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
            var payProducts = this._payProductService.GetList(m => m.Status == (int)Enums.CommonStatus.正常 &&m.Isdelete==(int)Enums.IsDelete.否 && m.ServiceType == channelType);
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