﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MorgenBuffet.Controllers
{
    public class KitchenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}