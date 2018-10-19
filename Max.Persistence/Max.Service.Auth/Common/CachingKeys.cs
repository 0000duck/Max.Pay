using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth.Common
{
    public static class CachingKeys
    {
        /// <summary>
        /// 所有系统菜单
        /// </summary>
        public const string System_AllMenus = "zhj:auth:menus1";


        /// <summary>
        /// 用户菜单URL+权限值
        /// </summary>
        public const string System_Permission_Format = "zhj:auth:perm:{0}1";

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public const string System_IsSupper_Format = "zhj:auth:supper:{0}1";
    }
}
