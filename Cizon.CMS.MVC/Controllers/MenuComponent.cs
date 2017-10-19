using Cizon.ApplicationService;
using Cizon.CMS.MVC.Models;
using Cizon.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cizon.CMS.MVC.Controllers
{
    [ViewComponent(Name = "Navigation")]
    public class MenuComponent : ViewComponent
    {
        private  IMenuAppService _menuAppService;
        public MenuComponent(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        
        }

        public IViewComponentResult Invoke()
        {
            List<MenuModel> menus = new List<MenuModel>();
            var userId = HttpContext.Session.GetString("CurrentUserId");
            var menuList = _menuAppService.GetMenusByUser(userId);
            for (int i = 0; i < menuList.Count; i++)
            {
                if (menuList[i].Visible == 0)
                {
                    continue;
                }
                var m = this.ConvertToMenuModel(menuList[i]);
                if (menuList[i].Type == 0)
                {
                    var cmList = GetChildMenus(menuList[i].Id,userId);
                    if (cmList != null)
                    {
                        m.ChildMenuList = cmList;
                    }
                }
                menus.Add(m);
            }

            return View(menus);
        }
        private List<MenuModel> GetChildMenus(string pId,string userId)
        {
          
            List<MenuModel> menus = new List<MenuModel>();
            var menuList = _menuAppService.GetChildMenus(pId, userId);
            for (int i = 0; i < menuList.Count; i++)
            {
                if (menuList[i].Visible == 0)
                {
                    continue;
                }
                var m = this.ConvertToMenuModel(menuList[i]);
                if (menuList[i].Type == 0)
                {
                    var cmList = this.GetChildMenus(menuList[i].Id, userId);
                    if (cmList != null)
                    {
                        m.ChildMenuList = cmList;
                    }
                }
                menus.Add(m);
            }
            return menus;
        }

        private MenuModel ConvertToMenuModel(MenuDto dto)
        {
            var url = dto.UrlAddress;
            if (!string.IsNullOrEmpty(url))
            {
                if (url.IndexOf("?") > -1)
                {
                    url += "&";
                }
                else
                {
                    url += "?";
                }
                url += "MID=" + dto.Id;
                url += "&SystemId=" + dto.SystemId;
                if (!string.IsNullOrEmpty(dto.UrlExtraParam))
                {
                    url += "&" + dto.UrlExtraParam;
                }
            }
            var iconUrl = dto.Icon1;

            MenuModel m = new MenuModel(dto.Id, dto.Name, url, iconUrl, dto.OpenType);
            return m;
        }
    }

}
