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
        private readonly IRandomService _randomService;
        private readonly IRandomWrapper _randomWrapper;

        // Ctor Injection
        public HomeController(IStoreRepository repository,
            IRandomService randomService,IRandomWrapper randomWrapper)
        {
            _repository = repository;
            _randomService = randomService;
            _randomWrapper = randomWrapper;
        }
        // Display Product Information
        public IActionResult Index()
        {
            var products = _repository.Products;

           // string result = "Random Number From Random Service =" +_randomService.GetNumber();
            string result = $"Random Number From Random Service = { _randomService.GetNumber()} ," +
                $" Random Wrapper  Number : {_randomWrapper.GetRandomNumberFromRandomService()}";
            ViewBag.Result = result;

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

        public IActionResult Details()
        {
            return View();

        }

    }
}
