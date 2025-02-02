﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSIT141Site.Models;
using MSIT141Site_24_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _demoContext;
        public HomeController(ILogger<HomeController> logger,DemoContext context)
        {
            _logger = logger;
            _demoContext = context;
        }

    
        public IActionResult FirstAjax() {
            return View();
        
        }
        public IActionResult AjaxPost() { return View(); }
        public IActionResult Register() { return View(); }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult History() {
            return View();
        }
        public IActionResult jQuery()
        {
            return View();
        }
        public IActionResult ShipperCors()
        {
            return View();
        }
        public IActionResult ShipperCorsEmpty()
        {
            return View();
        }
        public IActionResult Partial() {
            ViewBag.data = "Hello PartialView";
            return PartialView(_demoContext.Members);
        }
    }
}
