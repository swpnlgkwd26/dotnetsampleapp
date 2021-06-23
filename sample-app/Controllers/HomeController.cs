using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
   
    
    public class HomeController : Controller
    {
        private readonly IStoreRepository _repository;

        // Ctor Injection
        public HomeController(IStoreRepository repository)
        {
            _repository = repository;
        }
        // Display Product Information
        public IActionResult Index()
        {
            var products = _repository.Products;
            //Product
            return View(products); //Page       
        }

        public IActionResult AboutUs()
        {
            return View(); //Page
        }

        public IActionResult Contact()
        {
            return View(); //Page
        }

    }
}
