using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSIT141Site.Models;
using MSIT141Site_24_Ajax.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext dbDemo;
        public ApiController(DemoContext con, IWebHostEnvironment hostEnvironment ) {
            dbDemo = con;
            _host = hostEnvironment;
        }
  
        public IActionResult Index(User user)
        {
            if (string.IsNullOrEmpty(user.Name)) {
                user.Name = "Ajax";
                        }
            return Content($"{user.Name}Hello 你好,你的年齡是{user.Age}歳","text/plain");
        }
        public IActionResult Register(Member member, IFormFile file)
        {
            string imgPath = Path.Combine(_host.WebRootPath, "Images", file.FileName);
            using (var fileStream = new FileStream(imgPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            byte[] imgByte = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                imgByte = ms.ToArray();
            }
            member.FileName = file.FileName;
            member.FileData = imgByte;
            dbDemo.Members.Add(member);
            dbDemo.SaveChanges();
            string info = $"{file.FileName}-{file.Length}-{file.ContentType}";
            return Content(info, "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult Address() {
            return View();
        }
        public IActionResult City() {
            var cities = dbDemo.Addresses.Select(c => new { c.City }).Distinct();
            return Json(cities);
        }
        public IActionResult District(string city)
        {
            var district = dbDemo.Addresses.Where(d=>d.City==city).Distinct();
            return Json(district);
        }
        public IActionResult Road(string dist)
        {
            var district = dbDemo.Addresses.Where(d => d.SiteId == dist).Select(c => new { c.Road }).Distinct();
            return Json(district);
        }
        public IActionResult Promise() {
            return View();
        }
        public IActionResult getImageBytes(int? id) {
            var q = dbDemo.Members.Find(id);
            byte[] img = q.FileData;
            return File(img,"Image/jpeg");

        
        }

    }
}
