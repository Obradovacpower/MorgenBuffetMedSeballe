﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MorgenBuffet.Models;
using MorgenBuffet.DTO;

namespace MorgenBuffet.Controllers
{
    public class HomeController : Controller
    {
        Repository repository;
        public HomeController()
        {
            repository = Repository.GetRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kitchen()
        {
            return View();
        }


        public IActionResult Reception()
        {
            return View();
        }

        public IActionResult Restaurant()
        {
            return View();
        }

        public ViewResult Receptionist(OrderDTO model)
        {
            return View("Reception", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
