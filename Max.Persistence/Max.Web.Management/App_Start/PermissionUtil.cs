using Max.Framework;
using Max.Framework.DAL;
using Max.Framework.DAL.SqlServer;
using Max.Models.System;
using Max.Models.System.Common;
using Max.Service.Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Max.Web.Management
{
    public static class PermissionUtil
    {
        public static readonly Dictionary<string, string> PermissionUrls = new Dictionary<string, string>();
        public static readonly ILookup<string, KeyValuePair<string, string>> PermissionCode;
        public static readonly IRepository<SYS_Permission> PermRepository = Autofac.Integration.Mvc.AutofacDependencyResolver.Current.GetService(typeof(IRepository<SYS_Permission>)) as IRepository<SYS_Permission>;
        static PermissionUtil()
        {
            PermRepository.Add(new SYS_Permission { PermId = Guid.NewGuid().ToString(), Controller = "1", Createtime = DateTime.Now, PermCode = 123, PermName = "2", SystemId = 1 });

            InitPermission();

            PermissionCode = PermissionUrls.ToLookup(pair => pair.Value);
        }

        /// <summary>
        /// 判断权限值是否被重复使用
        /// </summary>
        public static void ValidPermissions()
        {
            var codes = Enum.GetValues(typeof(PermCode)).Cast<int>();
            var dic = new Dictionary<int, int>();
            foreach (var code in codes)
            {
                if (!dic.ContainsKey(code))
                    dic.Add(code, 1);
                else
                    throw new Exception(string.Format("权限值 {0} 被重复使用，请检查 PermCode 的定义", code));
            }
        }

        private static void InitPermission()
        {
            var permList = new List<SYS_Permission>();
            var actions = typeof(PermissionUtil).Assembly.GetTypes()
                .Where(t => typeof(Controller).IsAssignableFrom(t) && !t.IsAbstract)
                .SelectMany(t => t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly));

            foreach (var action in actions)
            {
                var attr = action.GetCustomAttributes(typeof(PermissionAttribute), false).FirstOrDefault() as PermissionAttribute;
                if (attr == null)
                    continue;

                var code = attr.Code;
                if (!permList.Exists(c => c.PermCode == code))
                {
                    var perm = new SYS_Permission
                    {
                        Controller = action.ReflectedType.Name.Replace("Controller", "").ToLower(),
                        Createtime = DateTime.Now,
                        PermCode = code,
                        PermId = Guid.NewGuid().ToString(),
                        PermName = ((PermCode)code).ToString(),
                        SystemId = (int)Max.Models.System.Common.SystemType.运营后台
                    };
                    permList.Add(perm);
                }
                var controllerName = action.DeclaringType.Name.Replace("Controller", "");
                var actionName = action.Name;
                var parameters = string.Join(",", action.GetParameters().OrderBy(p => p.Position).Select(p => p.ParameterType.ToString()));

                PermissionUrls.Add(string.Format("{0}/{1}/{2}", controllerName, actionName, parameters).ToLower(), attr.Code.ToString());
            }
            PermRepository.Delete(p => p.SystemId == (int)Max.Models.System.Common.SystemType.运营后台);
            while (permList.Count > 0)
            {
                PermRepository.Add(permList.Take(100));
                permList.RemoveRange(0, permList.Count >= 100 ? 100 : permList.Count);
            }
        }

        public static string CurrentPermissionUrl(AuthorizationContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;
            var parameters = string.Join(",", filterContext.ActionDescriptor.GetParameters().Select(p => p.ParameterType.ToString()));
            return string.Format("{0}/{1}/{2}", controllerName, actionName, parameters).ToLower();
        }

        public static string CurrentUrl(AuthorizationContext filterContext)
        {
            var url = filterContext.HttpContext.Request.FilePath.ToString().ToLower();
            if (url.LastIndexOf('/') == url.Length - 1)
                url = url.Substring(0, url.Length - 1);
            if (url == "") url = "/";
            return url;
        }
    }
}