using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Models.System.Common
{
    public enum SystemType
    {
        运营后台 = 1
    }

    #region SYS_User

    /// <summary>
    /// 管理员类型
    /// </summary>
    public enum UserType
    {
        普通管理员 = 0,
        超级管理员 = 1
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        正常 = 0,
        锁定 = 1
    }

    #endregion

    #region SYS_Role

    /// <summary>
    /// 角色状态
    /// </summary>
    public enum RoleStatus
    {
        正常 = 0,
        禁用 = 1
    }

    #endregion

    public enum SystemLogType
    {
        用户角色变更 = 1,
        角色权限变更 = 2,
    }

}
