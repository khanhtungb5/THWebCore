﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCoreApp.Models;
using WebCoreApp.Services;

namespace WebCoreApp.Controllers
{
    public class HomeController : Controller
    {
       /* private readonly ILogger<HomeController> _logger;*/
        private readonly IProductService _productService;
        
        public HomeController(/*ILogger<HomeController> logger,*/IProductService productService )
        {
            //_logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
			var model = new ProductViewModel();
			model.Products = _productService.GetList();
            model.Responses = _productService.GetIdList();
			return View(model);
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