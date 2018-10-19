using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Max.Web.Presentation.Common
{
    /// <summary>
    /// 现金贷页面访问权限控制（所有页面只有白名单用户才能访问）
    /// </summary>
    public class CashLoanAccessAuthorizeAttribute : AuthorizeAttribute
    {
        //public LoanStaffWhitelistService StaffService { get; set; }
        //public UserService UserService { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //if (!string.IsNullOrEmpty(httpContext.Request.Params["m"]))
            //{
            //    string mobile = ParametersHelper.DecryptMobileFromApp(httpContext.Request.Params["m"]);

            //    if (StaffService.IsWhitelist(mobile))
            //    {
            //        return true;
            //    }
            //}
            //else if (!string.IsNullOrEmpty(httpContext.Request.Params["uid"]))
            //{
            //    string userId = ParametersHelper.DecryptUserIdByDes(httpContext.Request.Params["uid"]);

            //    if (!string.IsNullOrEmpty(userId))
            //    {
            //        User user = UserService.Get(p => p.UserId == userId);

            //        if (user != null && StaffService.IsWhitelist(user.Mobile))
            //        {
            //            return true;
            //        }
            //    }
            //}

            httpContext.Response.StatusCode = 403;
            return false;
        }
    }
}