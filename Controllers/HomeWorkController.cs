using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using MSIT141Site_24_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class HomeWorkController : Controller
    {
        public readonly DemoContext dbDemo;

        public HomeWorkController(DemoContext con) { dbDemo = con;}


        public IActionResult JsonPractice() {
            return View();
        }
        public IActionResult Register() {
     
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            var q = dbDemo.Members.FirstOrDefault(m => m.Name == user.Name);
            if (q == null)
            {
                return Content($"false{user.Name}可以使用", "text/plain", System.Text.Encoding.UTF8);
            }
            return Content($"{user.Name} 此名字已存在, 不可使用", "text/plain", System.Text.Encoding.UTF8);

        }

        //讀取所有城市的資料
        public IActionResult Cities()
        {
            var cities = dbDemo.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        //根據城市名稱讀出鄉鎮區的資料
        public IActionResult Districts(string city)
        {
            var districts = dbDemo.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }

        //根據鄉鎮區的資料讀出路名
        public IActionResult Roads(string district)
        {
            var roads = dbDemo.Addresses.Where(a => a.SiteId == district).Select(a => a.Road);
            return Json(roads);
        }
        public IActionResult Address() {
            return View();
      }

    }
}
