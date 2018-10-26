using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Max.Web.Management.Models.Import
{
    public class ImportAllModel
    {
    }

    #region 资产优惠券白名单导入发放模板

    /// <summary>
    /// 导入手动发放券的白名单用户
    /// <Author>MAX</Author>
    /// </summary>
    public class ImportTicketWhiteUser
    {
        [Display(Name = "手机号码")]
        public string UserMobile { get; set; }
       
        public class ImportTicketWhiteUserComparer : IEqualityComparer<ImportTicketWhiteUser>
        {

            public bool Equals(ImportTicketWhiteUser x, ImportTicketWhiteUser y)
            {
                if (Object.ReferenceEquals(x, y)) return true;

                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                return x.UserMobile == y.UserMobile;
            }


            public int GetHashCode(ImportTicketWhiteUser obj)
            {

                if (Object.ReferenceEquals(obj, null)) return 0;

                int hashObjName = obj.UserMobile == null ? 0 : obj.UserMobile.GetHashCode();

                return hashObjName;


            }

        }
    }
    #endregion


    #region 员工贷申请资料导入模板
    public class ImportCreditUserApply
    {
        [Display(Name = "申请编号")]
        public string ApplyId { get; set; }

        [Display(Name = "手机号码")]
        public string Mobile { get; set; }
        [Display(Name = "用户姓名")]
        public string CustName { get; set; }

        [Display(Name = "申请状态")]
        public string OffLineApplyStatus { get; set; }
        [Display(Name = "备注")]
        public string OffLineApplyResult { get; set; }

    }
    #endregion

    #region 车贷融资

    /// <summary>
    /// 融资收款导入模板
    /// </summary>
    public class ImportCarLoanFinanceReceive
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        [Display(Name = "资产编号")]
        public string ProjectId { get; set; }


        /// <summary>
        /// 项目编号
        /// </summary>
        [Display(Name = "项目编号")]
        public string OrderNo { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        [Display(Name = "期数")]
        public string Periods { get; set; }

        /// <summary>
        /// 资产类型
        /// </summary>
        [Display(Name = "资产类型")]
        public string AssetsType { get; set; }

        /// <summary>
        /// 年化利率
        /// </summary>
        [Display(Name = "年化利率")]
        public string YearInterest { get; set; }

        [Display(Name = "起息日")]
        public string ValueDate { get; set; }

        /// <summary>
        /// 收款金额
        /// </summary>
        [Display(Name = "收款金额")]
        public string ReceiveAmount { get; set; }

    }

    /// <summary>
    /// 融资还款导入模板
    /// </summary>
    public class ImportCarLoanFinanceRepay
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        [Display(Name = "资产编号")]
        public string ProjectId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Display(Name = "项目编号")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 资产类型
        /// </summary>
        [Display(Name = "资产类型")]
        public string AssetsType { get; set; }
        /// <summary>
        /// 第几期
        /// </summary>
        [Display(Name = "第几期")]
        public string Period { get; set; }

        /// <summary>
        /// 本期还款日
        /// </summary>
        [Display(Name = "本期还款日")]
        public string CurrentRepayTime { get; set; }

        /// <summary>
        /// 本期应还金额
        /// </summary>
        [Display(Name = "本期应还金额")]
        public string CurrentRepayAmount { get; set; }

        [Display(Name = "本期应还利息")]
        public string CurrentInterestAmount { get; set; }

        /// <summary>
        /// 还款金额
        /// </summary>
        [Display(Name = "还款金额")]
        public string RepayAmount { get; set; }

    }
    #endregion
}