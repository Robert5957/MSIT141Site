using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly DemoContext dbDemo;

        public HomeWorkController(DemoContext con) {
                        dbDemo = con;
                }
     
        public IActionResult Register() {
     
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user) {
            var q = dbDemo.Members.FirstOrDefault(m => m.Name == user.Name);
            if (q == null) {
              return Content($"{user.Name}不存在", "text/plain");
            }
                return Content($"{user.Name} 你好,你的年齡是{q.Age}歳", "text/plain");

        }


      
    }
}
