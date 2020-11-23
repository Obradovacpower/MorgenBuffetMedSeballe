using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MorgenBuffet.DTO;
using MorgenBuffet.Models;

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
        public IActionResult Reception2()
        {
            return View();
        }

        public async Task<ViewResult> Create(OrderDTO dto)
        {
            await repository.AddOrder(dto);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
