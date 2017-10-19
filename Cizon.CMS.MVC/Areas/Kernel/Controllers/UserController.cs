using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cizon.CMS.MVC.Controllers;
using Cizon.ApplicationService;

namespace Cizon.CMS.MVC.Areas.Kernel.Controllers
{
    public class UserController : BaseController
    {
        private IUserInfoAppService _userAppService;
        public UserController(IUserInfoAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}