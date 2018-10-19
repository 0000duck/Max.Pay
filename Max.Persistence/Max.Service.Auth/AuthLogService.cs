using Max.Framework;
using Max.Framework.Caching;
using Max.Framework.DAL;
using Max.Models.System;
using Max.Models.System.Common;
using Max.Service.Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth
{
    public class AuthLogService : IService
    {
        private IRepository<SYS_Log> logRepository;

        public AuthLogService(
            IRepository<SYS_Log> logRepository
            )
        {
            this.logRepository = logRepository;
        }

        public void Add(SystemLogType logType, string keyWord, string remark)
        {
            var log = new SYS_Log
            {
                CreatedBy = Max.Framework.Authorization.AuthorizeHelper.GetCurrentUser().UserName,
                CreateTime = DateTime.Now,
                LogId = Guid.NewGuid().ToString(),
                LogType = (int)logType,
                Remark = remark,
                KeyWord = keyWord
            };

            logRepository.Add(log);
        }
    }
}
