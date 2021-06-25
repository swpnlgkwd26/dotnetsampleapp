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
            IRandomService randomService, IRandomWrapper randomWrapper)
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

        public IActionResult Details(int id)
        {
            //Get the data related to this id and pass it to view to display
            // Product Select : infromation  We need to get and pass it to view.

            var product = _repository.GetProductById(id);
            return View(product);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repository.AddProduct(product);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Update(int id)
        {
            // Find the Data by Id and then pass it to View
            var product = _repository.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _repository.UpdateProduct(product);
            return RedirectToAction("Index", "Home");
        }

    }
}
