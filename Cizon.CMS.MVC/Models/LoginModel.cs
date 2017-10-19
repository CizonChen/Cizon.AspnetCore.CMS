using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cizon.CMS.MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "用户名不能为空。")]
        public string username { get; set; }

        [Required(ErrorMessage = "密码不能为空。")]
        public string password { get; set; }

        public bool remember_me { get; set; }
    }
}
