using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MorgenBuffet.DTO;
using MorgenBuffet.Models;
using MorgenBuffet.DTO;
using MorgenBuffet.Data;

namespace MorgenBuffet.Controllers
{
    public class HomeController : Controller
    {
        Repository repository;
        public HomeController(ApplicationDbContext db)
        {
            repository = new Repository(db);
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

        public IActionResult RefreshKitchen()
        {
            RedirectToAction("Kitchen", "HomeController");
            return View();
        }
        //reception
        public async Task<IActionResult> ReceptionList()
        {
            List<OrderDTO> orders = new List<OrderDTO>();
            try
            {
                orders = await repository.GetOrdersToday();
            }
            catch
            {

            }
            return View(orders);
        }
        //reception
        [HttpPost]
        public async Task<ActionResult> PostAddOrder(OrderDTO order)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await repository.AddOrder(order);
                }
            }
            catch
            {

            }
            return View("Index");
        }

        //restaurant
        [HttpPost]
        public async Task CheckIn(OrderDTO order)
        {
            await repository.CheckIn(order);
        }
        //kitchen
        [HttpGet]
        public async Task<ActionResult> GetOrdersOnDate(DateTime date)
        {
            List<OrderDTO> orders = new List<OrderDTO>();
            orders = await repository.GetOrders(date.Date);
            return View(orders);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
