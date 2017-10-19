using Cizon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cizon.Domain.IRepositories
{
    public interface IUserInfoRepository : IRepository<UserInfoDto>
    {
        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        UserInfoDto CheckUser(string userName, string password);
    }
}
