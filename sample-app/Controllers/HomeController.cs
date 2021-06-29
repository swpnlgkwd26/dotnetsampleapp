using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using sample_app.ViewModels;
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
            // Logic :  Localization
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
        public IActionResult Create(ProductAddViewModel productAddViewModel)
        {
            // if Model is valid
            if (ModelState.IsValid)
            {
                // View is Returnning ProductAddViewModel
                Product product = new Product
                {
                    Name = productAddViewModel.Name,
                    Category = productAddViewModel.Category,
                    Description = productAddViewModel.Description,
                    MfgDate = productAddViewModel.MfgDate,
                    Price= productAddViewModel.Price,
                    ProductId =  productAddViewModel.ProductId
                };
                // Data Access Logic Product Class

                _repository.AddProduct(product); // AddProduct : Product
                return RedirectToAction("Index", "Home");
            }
            return View();
            
        }
        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Update(int id)
        {
            // Find the Data by Id and then pass it to View
            var product = _repository.GetProductById(id); // Product Object
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                MfgDate = product.MfgDate,
                Price = product.Price,
                ProductId = product.ProductId
            };
            return View(productEditViewModel); // ProductEditViewModel
        }
        [HttpPost]
        public IActionResult Update(ProductEditViewModel productEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = productEditViewModel.Name,
                    Category = productEditViewModel.Category,
                    Description = productEditViewModel.Description,
                    MfgDate = productEditViewModel.MfgDate,
                    Price = productEditViewModel.Price,
                    ProductId = productEditViewModel.ProductId
                };
                _repository.UpdateProduct(product);
                return RedirectToAction("Index", "Home");
            }
            return View();
          
        }

    }
}
