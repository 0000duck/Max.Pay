﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth.Common
{
    /// <summary>
    /// 权限值枚举
    /// </summary>
    public enum PermCode : int
    {

        /*
         * =========================
         * 注意
         * 请勿更改、删除别人定义的权限值
         * =========================
         */

        #region 用户/权限/菜单 100 开头

        浏览管理员列表 = 1002,
        添加管理员 = 1003,
        编辑管理员 = 1004,
        删除管理员 = 1005,

        新增菜单 = 1006,
        编辑菜单 = 1007,
        删除菜单 = 1008,
        菜单权限 = 1017,

        添加权限组 = 1009,
        编辑权限组 = 10010,
        删除权限组 = 10011,
        添加权限到权限组 = 10012,
        从权限组中删除权限 = 10013,

        添加角色 = 10021,
        编辑角色 = 10022,
        删除角色 = 10023,

        编辑管理员所属角色 = 10024,

        编辑角色菜单 = 10025,
        编辑角色权限 = 10026,
        编辑角色用户 = 10027,
        查看管理员权限 = 10028,

        #endregion

       
        #region 运维系统 199 开头

        Redis缓存查询 = 1991,
        Redis缓存清除 = 1992,

        Mongo缓存查询 = 1993,
        Mongo缓存清除 = 1994,

        Memcache缓存查询 = 1995,
        Memcache缓存清除 = 1996,
        #endregion
        
    }

    public static class PermCodeExtensions
    {
        public static int Code(this PermCode code)
        {
            return (int)code;
        }
    }
}