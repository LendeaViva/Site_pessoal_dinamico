﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site_v3_dinamico.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Site_v3_dinamico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController( ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sobre_mim()
        {
            return View();
        }

        public IActionResult Competencias()
        {
            return View();
        }

        public IActionResult Formacao()
        {
            return View();
        }

        public IActionResult Exp_Profissional()
        {
            return View();
        }

        public IActionResult Contactos()
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
