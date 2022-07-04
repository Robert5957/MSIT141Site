using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class ApiController : Controller
    {
  
        public IActionResult Index(User user)
        {
            if (string.IsNullOrEmpty(user.Name)) {
                user.Name = "Ajax";
                        }
            return Content($"{user.Name}Hello 你好,你的年齡是{user.Age}歳","text/plain");
        }
    }
}
