using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Smart400.Models;
using Smart400.Repositories;
using Smart400.Services;

namespace Smart400.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAs400Service as400Service;

        public HomeController(ILogger<HomeController> logger, IAs400Service as400Service)
        {
            _logger = logger;
            this.as400Service = as400Service;
        }

        public IActionResult Index()
        {
            var appSetting = as400Service.GetStatus();

            return View(appSetting);
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
