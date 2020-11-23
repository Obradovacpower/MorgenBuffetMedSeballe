﻿using System;
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
        //reception
        [HttpGet]
        public async Task<ActionResult> GetOrders()
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

        public async Task<ActionResult> Update(OrderDTO order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.CheckIn(order);
                }
            }
            catch
            {

            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
