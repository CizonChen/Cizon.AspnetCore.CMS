using Cizon.Domain.Entities;
using Cizon.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cizon.Utility;

namespace Cizon.EntityFrameworkCore.Repositories
{
    public class UserInfoRepository : CizonRepositoryBase<UserInfoDto>, IUserInfoRepository
    {
     

        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        public UserInfoDto CheckUser(string userName, string password)
        {
            var user = _dbContext.Set<UserInfoDto>().FirstOrDefault(x => x.LogonCode == userName);
            if (user != null)
            {
               if(password != DesHelper.DecryptDES(user.Password, Consts.ENCRYPTKEY))
                {
                    return null;
                }
            }
            return user;
        }
    }
}
