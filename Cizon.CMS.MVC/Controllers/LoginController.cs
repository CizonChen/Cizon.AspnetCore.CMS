using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cizon.CMS.MVC.Models;
using Microsoft.AspNetCore.Http;
using Cizon.ApplicationService;
using Cizon.Utility;

namespace Cizon.CMS.MVC.Controllers
{
    public class LoginController : Controller
    {
        private IUserInfoAppService _userAppService;
        public LoginController(IUserInfoAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               var user= _userAppService.CheckUser(model.username,model.password);
                if (user != null)
                {
                    HttpContext.Session.SetString("CurrentUserId", user.Id);
                    //记录Session
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "用户名或密码错误。";
                return View();
            }
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    ViewBag.ErrorInfo = item.Errors[0].ErrorMessage;
                    break;
                }
            }
            return View(model);
        }
    }
}