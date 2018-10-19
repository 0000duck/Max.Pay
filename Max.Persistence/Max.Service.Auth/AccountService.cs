using Max.Framework;
using Max.Framework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Models.System;
using System.Linq.Expressions;
using Max.Models.System.Common;
using Max.Framework.Authorization;

namespace Max.Service.Auth
{
    public class AccountService : IService
    {
        private IUnitOfWork unitOfWork;
        private IRepository<SYS_User> userRepository;
        private IRepository<SYS_UserRoles> userRolesRepository;
        private IRepository<SYS_Role> rolesRepository;
        private IRepository<SYS_Permission> permsRepository;
        private IRepository<SYS_Log> logRepository;

        public AccountService(
            IUnitOfWork unitOfWork,
            IRepository<SYS_User> userRepository,
            IRepository<SYS_UserRoles> userRolesRepository,
            IRepository<SYS_Role> rolesRepository,
            IRepository<SYS_Permission> permsRepository,
            IRepository<SYS_Log> logRepository
            )
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.userRolesRepository = userRolesRepository;
            this.rolesRepository = rolesRepository;
            this.permsRepository = permsRepository;
            this.logRepository = logRepository;
        }

        #region 01 用户登录

        public ServiceResult Login(string username, string password)
        {
            var result = new ServiceResult();

            if (username.IsNullOrEmpty())
                return result.IsFailed("用户名不能为空");

            if (password.IsNullOrEmpty())
                return result.IsFailed("密码不能为空");

            var status = (int)UserStatus.正常;
            var user = this.userRepository.Get(u => u.UserName == username && u.Password == password && u.Status == status);

            if (user == null)
                return result.IsFailed("用户名或密码不正确，或帐号已被锁定");

            result.Set("user", new SystemUser
            {
                UserId = user.SystemUserId,
                UserName = user.UserName,
                RealName = user.RealName,
                Mobile = user.Mobile,
                LoginTime = DateTime.Now,
                UserType = user.UserType,
                Email = user.Email
            });

            return result.IsSucceed("登录成功");
        }

        #endregion

        #region 02 添加用户

        public ServiceResult Add(SYS_User user)
        {
            var result = new ServiceResult();
            if (!user.Email.IsEmail())
            {
                return result.IsFailed("邮件地址不合法。");
            }

            var ret = this.userRepository.Query<int, int, int>(
                @"SELECT COUNT(1) FROM SYS_User WHERE UserName = @userName;
                    SELECT COUNT(1) FROM SYS_User WHERE Email = @email;
                    SELECT COUNT(1) FROM SYS_User WHERE Mobile = @mobile;"
                , new { userName = user.UserName, email = user.Email, mobile = user.Mobile }
                );

            if (ret[0].Cast<int>().First() > 0)
                return result.IsFailed("添加失败，已存在用户名相同的管理员");

            if (ret[1].Cast<int>().First() > 0)
                return result.IsFailed("添加失败，已存在邮箱相同的管理员");

            if (ret[2].Cast<int>().First() > 0)
                return result.IsFailed("添加失败，已存在手机号相同的管理员");

            this.userRepository.Add(user);

            return result.IsSucceed("添加系统用户成功");
        }

        #endregion

        #region 03 删除用户

        public ServiceResult Delete(string userId)
        {
            var result = new ServiceResult();
            using (var tran = this.unitOfWork.BeginTransaction())
            {
                this.userRepository.Delete(u => u.SystemUserId == userId, tran);
                this.userRolesRepository.Delete(ur => ur.SystemRoleId == userId, tran);
                tran.Commit();
            }
            return result.IsSucceed("删除系统用户成功");
        }

        #endregion

        #region 04 更新用户

        public ServiceResult Update(SYS_User user)
        {
            var result = new ServiceResult();
            var ret = this.userRepository.Query<int, int, int>(
            @"SELECT COUNT(1) FROM SYS_User WHERE UserName = @userName AND SystemUserId != @userId;
                SELECT COUNT(1) FROM SYS_User WHERE Email = @email AND SystemUserId != @userId;
                SELECT COUNT(1) FROM SYS_User WHERE Mobile = @mobile AND SystemUserId != @userId;"
            , new { userName = user.UserName, email = user.Email, mobile = user.Mobile, userId = user.SystemUserId }
            );

            if (ret[0].Cast<int>().First() > 0)
                return result.IsFailed("编辑失败，已存在用户名相同的管理员");

            if (ret[1].Cast<int>().First() > 0)
                return result.IsFailed("编辑失败，已存在邮箱相同的管理员");

            if (ret[2].Cast<int>().First() > 0)
                return result.IsFailed("编辑失败，已存在手机号相同的管理员");

            this.userRepository.Update(user);

            return result.IsSucceed("更新系统用户成功");
        }

        #endregion

        #region 06 获取用户列表

        public PageList<SYS_User> GetUsers(int pageIndex, int PageSize, Expression<Func<SYS_User, bool>> predicate)
        {
            return this.userRepository.PageList(
                predicate,
                o => o.Desc(u => u.CreateTime),
                pageIndex,
                PageSize,
                DbLock.NoLock
                );
        }

        #endregion

        #region 07 查询单个用户

        public SYS_User Get(Expression<Func<SYS_User, bool>> predicate)
        {
            return this.userRepository.Get(predicate);
        }

        public List<SYS_Role> GetUserRoles(string userId)
        {
            var roleIds = userRolesRepository.ToList(x => x.SystemUserId == userId).Select(x => x.SystemRoleId).ToArray();
            if (roleIds.Length == 0) return null;
            List<SYS_Role> result = new List<SYS_Role>(roleIds.Length);
            foreach (string roleId in roleIds)
            {
                var role = rolesRepository.Get(x => x.SystemRoleId == roleId);
                if (role != null)
                    result.Add(role);
            }
            return result;
        }

        public ServiceResult UpdateUserRoles(string userId, string[] roleIds)
        {
            var result = new ServiceResult();
            var oldRoles = userRolesRepository.Query<SYS_Role>("select r.* from SYS_UserRoles ur join SYS_Role r on ur.SystemRoleId=r.SystemRoleId where ur.SystemUserId=@UserId", new { UserId = userId });
            var oldRoleNames = "";
            if (oldRoles != null && oldRoles.Count() > 0)
                oldRoleNames = oldRoles.Select(r => r.RoleName).Aggregate((c, n) => c + "、" + n);
            using (var tran = this.unitOfWork.BeginTransaction())
            {
                userRolesRepository.Delete(x => x.SystemUserId == userId, tran);
                if (roleIds != null && roleIds.Length > 0)
                {
                    userRolesRepository.Add(roleIds.Select(roleId => new SYS_UserRoles
                    {
                        CreateTime = DateTime.Now,
                        SystemRoleId = roleId,
                        SystemUserId = userId
                    }), tran);
                }
                tran.Commit();
            }
            var newRoles = userRolesRepository.Query<SYS_Role>("select r.* from SYS_UserRoles ur join SYS_Role r on ur.SystemRoleId=r.SystemRoleId where ur.SystemUserId=@UserId", new { UserId = userId });
            var newRolesNames = "";
            if (newRoles != null && newRoles.Count() > 0)
                newRolesNames = newRoles.Select(r => r.RoleName).Aggregate((c, n) => c + "、" + n);

            if (!string.IsNullOrEmpty(oldRoleNames) || !string.IsNullOrEmpty(newRolesNames))
            {
                var user = userRepository.Get(u => u.SystemUserId == userId);
                logRepository.Add(new SYS_Log
                {
                    CreatedBy = Max.Framework.Authorization.AuthorizeHelper.GetCurrentUser().UserName,
                    CreateTime = DateTime.Now,
                    KeyWord = user.UserName,
                    LogId = Guid.NewGuid().ToString(),
                    LogType = (int)SystemLogType.用户角色变更,
                    Remark = "【" + oldRoleNames + "】 => 【" + newRolesNames + "】"
                });
            }
            return result.IsSucceed("设置用户角色成功");
        }
        #endregion

        #region 08 修改密码

        public ServiceResult ResetPassword(string systemUserId, string password, string newPassword)
        {
            var result = new ServiceResult();
            if (!userRepository.Exists(u => u.SystemUserId == systemUserId))
                return result.IsFailed("用户不存在");

            var effected = userRepository.Update(
                u => u.SystemUserId == systemUserId && u.Password == password,
                u => new SYS_User
                {
                    Password = newPassword
                });

            if (effected <= 0)
                return result.IsFailed("原密码不正确");

            return result.IsSucceed("修改密码成功");
        }

        #endregion

        #region 09 获取用户权限信息

        public ServiceResult GetPermsInfo(string systemUserId)
        {
            var result = new ServiceResult();
            var allPerms = permsRepository.ToList(p => true);
            var roles = rolesRepository.Query<SYS_Role>("select r.* from SYS_UserRoles ur join SYS_Role r on ur.SystemRoleId=r.SystemRoleId where ur.SystemUserId=@UserId", new { UserId = systemUserId });
            result.Data.Add("AllPerms", allPerms);
            result.Data.Add("Roles", roles);
            return result.IsSucceed();
        }

        #endregion

    }
}
