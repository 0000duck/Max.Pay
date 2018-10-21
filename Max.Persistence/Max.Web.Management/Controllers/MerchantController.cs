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

    public class MerchantController : BaseController
    {
        private MerchantService _merchantService;
        private MerchantBankService _merchantBankService;
        private V_MerchantPayService _vMerchantPayService;
        private PayProductService _payProductService;
        private IExcelClient excelClient;
        public MerchantController(MerchantService merchantService, MerchantBankService merchantBankService, V_MerchantPayService vMerchantPayService, IExcelClient excelClient, PayProductService payProductService)
        {
            this._merchantService = merchantService;
            this.excelClient = excelClient;
            this._merchantBankService = merchantBankService;
            this._vMerchantPayService = vMerchantPayService;
            this._payProductService = payProductService;
        }

        [Permission(PermCode.商户列表)]
        public ActionResult List(Query<Merchant, MerchantParams> query)
        {
            var where = PredicateBuilder.True<Merchant>();
            var param = query.Params;
            where = where.And(c => c.Isdelete == (int)Enums.IsDelete.否);
            if (!param.MerchantName.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.MerchantName.Contains(param.MerchantName));
            }
            if (!param.MerchantNo.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.MerchantNo.Contains(param.MerchantNo));
            }
            if (param.Status.HasValue)
            {
                where = where.And(c => c.Status == param.Status);
            }
            var pageList = this._merchantService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        [Permission(PermCode.商户详情)]
        public ActionResult Details(string merchantId)
        {
            MerchantDetailsModel model = new MerchantDetailsModel();
            model.Merchant = this._merchantService.Get(c=>c.MerchantId==merchantId);
            model.MerchantBankList = this._merchantBankService.GetList(c=>c.MerchantId==merchantId);
            model.MerchantPayProductList = this._vMerchantPayService.GetList(c=>c.MerchantId==merchantId);
            model.PayProductList = this._payProductService.GetList(c=>c.Isdelete==(int)Enums.IsDelete.否);
            return View(model);
        }


        #region 新增/编辑/删除商户


        public ActionResult AddOrEdit(string merchantId)
        {
            var model = merchantId.IsNullOrWhiteSpace() ? new Merchant() : this._merchantService.Get(c => c.MerchantId == merchantId);
            return View(model);
        }

        [Permission(PermCode.新增商户)]
        [HttpPost]
        public ActionResult AddForAjax(Merchant model)
        {
            model.MerchantId = Guid.NewGuid().ToString();
            model.MerchantNo = "10086";
            model.Md5Key = Guid.NewGuid().ToString("N");
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;

            return Json(this._merchantService.Add(model));
        }

        [Permission(PermCode.编辑商户)]
        [HttpPost]
        public ActionResult EditForAjax(Merchant model)
        {
            return Json(this._merchantService.Update(c => c.MerchantId == model.MerchantId, c => new Merchant()
            {
                MerchantName = model.MerchantName,
                Mobile = model.Mobile,
                QQ = model.QQ,
                Email = model.Email,
                ApiWhiteIp = model.ApiWhiteIp,
                BackWhiteIp = model.BackWhiteIp,
                Status = model.Status,
                Remark = model.Remark
            }));
        }

        [Permission(PermCode.删除商户)]
        [HttpPost]
        public ActionResult DeleteForAjax(string merchantId)
        {
            return Json(this._merchantService.Delete(c => c.MerchantId == merchantId));
        }

        #endregion

        #region 商户银行卡操作

        [Permission(PermCode.设置商户银行卡)]
        public ActionResult BankCardList(string merchantId)
        {
            ViewBag.merchantId = merchantId;
            var where = PredicateBuilder.True<MerchantBankAccount>();
            where = where.And(c => c.MerchantId == merchantId && c.Isdelete == (int)Enums.IsDelete.否);


            var list = this._merchantService.GetBankCardList(where);

            return View(list);
        }

        public ActionResult AddOrEditBankCard(string merchantId, string accountId)
        {
            var model = accountId.IsNullOrWhiteSpace() ? new MerchantBankAccount() { MerchantId = merchantId } : this._merchantService.GetBankCard(c => c.AccountId == accountId);
            return View(model);
        }

        [Permission(PermCode.新增商户银行卡)]
        [HttpPost]
        public ActionResult AddBankForAjax(MerchantBankAccount model)
        {
            model.AccountId = Guid.NewGuid().ToString();
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;
            var result = this._merchantBankService.Add(model);
            result.Set("MerchantId", model.MerchantId);
            return Json(result);
        }

        [Permission(PermCode.编辑商户银行卡)]
        [HttpPost]
        public ActionResult EditBankForAjax(MerchantBankAccount model)
        {
            var result = this._merchantBankService.Update(c => c.AccountId == model.AccountId, c => new MerchantBankAccount()
            {
                AccountName = model.AccountName,
                AccountNumber = model.AccountNumber,
                BankBranchName = model.BankBranchName,
                BankCode = model.BankCode,
                BankName = model.BankName,
                City = model.City,
                IdCardNo = model.IdCardNo,
                Mobile = model.Mobile,
                Province = model.Province,
                Remark = model.Remark,
                Status = model.Status,
                UpdateBy = CurrentSysUser.UserName,
                UpdateTime = DateTime.Now
            });
            result.Set("MerchantId", model.MerchantId);
            return Json(result);
        }

        [Permission(PermCode.删除商户银行卡)]
        [HttpPost]
        public ActionResult DeleteBankForAjax(string accountId)
        {
            return Json(this._merchantBankService.Delete(c => c.AccountId == accountId));
        }

        #endregion


        [Permission(PermCode.导出商户列表)]
        public void ExportBanks(Query<Merchant, MerchantParams> query)
        {
            var where = PredicateBuilder.True<Merchant>();

            var list = this._merchantService.GetList(where).OrderBy(m => m.MerchantName).ToList();


            var exportList = new List<ExportMerchant>();
            foreach (var item in list)
            {

                var model = new ExportMerchant();
                model.MerchantName = item.MerchantName;
                model.MerchantNo = item.MerchantNo;
                model.AgentNo = item.AgentNo;
                model.Mobile = item.Mobile;
                model.Email = item.Email;
                model.QQ = item.QQ;
                model.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "商户列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}