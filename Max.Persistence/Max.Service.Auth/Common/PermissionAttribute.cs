using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth.Common
{
    /// <summary>
    /// 权限特性，表示需要拥有该权限才能访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionAttribute : Attribute
    {
        public int Code { get; set; }

        public PermissionAttribute(PermCode perm)
        {
            this.Code = (int)perm;
        }
    }
}
