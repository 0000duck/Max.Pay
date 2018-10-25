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

    public class AgentController : BaseController
    {
        private AgentService _agentService;
        private IExcelClient excelClient;
        public AgentController(AgentService agentService, IExcelClient excelClient)
        {
            this._agentService = agentService;
            this.excelClient = excelClient;
        }

        #region 代理管理

        [Permission(PermCode.代理列表)]
        public ActionResult List(Query<Agent, AgentParams> query)
        {
            var where = PredicateBuilder.True<Agent>();
            var param = query.Params;
            if (!param.AgentName.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.AgentName.Contains(param.AgentName));
            }
            if (!param.AgentNo.IsNullOrWhiteSpace())
            {
                where = where.And(c => c.AgentNo.Contains(param.AgentNo));
            }

            if (param.Status.HasValue)
            {
                where = where.And(c => c.Status == param.Status.Value);
            }
            var pageList = this._agentService.GetPageList(where, query.__pageIndex, query.__pageSize);

            pageList.UpdateQuery(query);

            return PageView(query);

        }

        #endregion

        #region 新增/编辑/删除代理


        public ActionResult AddOrEdit(string agentId)
        {
            var model = agentId.IsNullOrWhiteSpace() ? new Agent() : this._agentService.Get(c => c.AgentId == agentId);
            return View(model);
        }

        [Permission(PermCode.新增代理)]
        [HttpPost]
        public ActionResult AddForAjax(Agent model)
        {
            model.AgentId = Guid.NewGuid().ToString();
            model.CreateBy = CurrentSysUser.UserName;
            model.CreateTime = DateTime.Now;
            return Json(this._agentService.Add(model));
        }

        [Permission(PermCode.编辑代理)]
        [HttpPost]
        public ActionResult EditForAjax(Agent model)
        {
            return Json(this._agentService.Update(c => c.AgentId == model.AgentId, c => new Agent()
            {
                AgentName = model.AgentName,
                AgentNo = model.AgentNo,
                Remark = model.Remark,
                QQ = model.QQ,
                Email = model.Email,
                Mobile = model.Mobile,
                Status = model.Status,
                UpdateBy = CurrentSysUser.UserName,
                UpdateTime = DateTime.Now
            }));
        }

        [Permission(PermCode.删除代理)]
        [HttpPost]
        public ActionResult DeleteForAjax(string agentId)
        {
            return Json(this._agentService.Delete(c => c.AgentId == agentId));
        }

        #endregion

        [Permission(PermCode.导出代理列表)]
        public void ExportBanks(Query<Agent, AgentParams> query)
        {
            var where = PredicateBuilder.True<Agent>();

            var list = this._agentService.GetList(where).OrderBy(m => m.CreateTime).ToList();


            var exportList = new List<ExportBank>();
            foreach (var item in list)
            {

                var model = new ExportBank();
                //model.BankName = item.BankName;
                //model.BankCode = item.BankCode;
                //model.SeqNo = item.SeqNo;
                exportList.Add(model);

            }
            excelClient.HttpExport(exportList, "代理列表" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}