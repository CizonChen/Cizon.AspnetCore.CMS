using Cizon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cizon.ApplicationService
{
   public interface IMenuAppService: IAppServiceBase<MenuDto>
    {
        /// <summary>
        /// 获取系统一级菜单
        /// </summary>
        /// <param name="systemId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        MenuDto GetTheSystemFirstMenu(string systemId);

        /// <summary>
        /// 获取子菜单
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MenuDto> GetChildMenus(string pId, string userId);

        /// <summary>
        /// 根据用户获取菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MenuDto> GetMenusByUser(string userId);
    }
}
