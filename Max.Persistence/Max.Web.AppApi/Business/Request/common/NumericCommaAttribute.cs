using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Max.Framework;
using System.Text.RegularExpressions;

namespace Max.Web.AppApi.Business.Request.common
{
    /// <summary>
    /// 数字加逗号 如1,2,3
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NumericCommaAttribute : ValidationAttribute
    {
        public NumericCommaAttribute()
        { }

        public override bool IsValid(object value)
        {
            var obj = value as string;

            return obj.IsNullOrEmpty() ? false : Regex.IsMatch(obj, @"^\d+(,\d+)*$");
        }
    }
}