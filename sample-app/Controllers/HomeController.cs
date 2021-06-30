using AutoMapper;
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
        private readonly IMapper _mapper;

        // Ctor Injection
        public HomeController(IStoreRepository repository,
            IRandomService randomService, IRandomWrapper randomWrapper
            , IMapper mapper)
        {
            _repository = repository;
            _randomService = randomService;
            _randomWrapper = randomWrapper;
            _mapper = mapper;
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
                var product = _mapper.Map<Product>(productAddViewModel);
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
            var product = _repository.GetProductById(id); // Product Object : Model
                                                          // Product => ProductEditViewModel
            var productEditViewModel = _mapper.Map<ProductEditViewModel>(product);
            return View(productEditViewModel); // ProductEditViewModel : VM
        }

        [HttpPost]
        public IActionResult Update(ProductEditViewModel productEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productEditViewModel);
                _repository.UpdateProduct(product);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // Server Side Method that will validate whether 
        // Category is ...
        public IActionResult VerifyCategory(string category)
        {
            // if Category  Chess/Cricket/Soccer true
            if (category == "Soccer" || category == "Chess" || category == "Cricket")
            {
                return Json(true);
            }
            return Json("Only Cricket/Soccer/Chess allowed in Category");
        }

    }
}
