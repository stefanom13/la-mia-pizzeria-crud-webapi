﻿using la_mia_pizzeria_mvc_refactoring.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_mvc_refactoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Details(int id)
        {
            return View(id);
        }

        public IActionResult Privacy()
        {
            return View();
        } public IActionResult Contact()
        {
            return View("Contact");
        }

       
        public ActionResult Delete(int id)
        {
            
            return RedirectToAction("Index");
            
        }
    }
}