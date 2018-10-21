using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Max.Framework;

namespace Max.Web.AppApi.Business.Request.common
{
    /// <summary>
    /// 系统自带的手机判断方法未必跟MAX支付的一致，所以用MAX支付的判断方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class QDMobileAttribute : ValidationAttribute
    {
        public QDMobileAttribute()
        { }

        public override bool IsValid(object value)
        {
            var obj = value as string;

            return obj.IsNullOrEmpty() ? false : obj.IsMobile();
        }
    }
}