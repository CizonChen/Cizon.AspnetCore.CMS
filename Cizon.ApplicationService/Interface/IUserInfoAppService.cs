using Cizon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cizon.ApplicationService
{
    public interface IUserInfoAppService : IAppServiceBase<UserInfoDto>
    {
        UserInfoDto CheckUser(string userName, string password);
    }
}
