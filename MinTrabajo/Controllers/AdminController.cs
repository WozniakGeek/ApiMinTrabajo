﻿using Microsoft.AspNetCore.Mvc;

namespace MinTrabajo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
