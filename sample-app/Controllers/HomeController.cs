using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using sample_app.Models;
using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;
        public int PageSize = 2;

        public HomeController(IStoreRepository repository,
            IRandomService randomService, IRandomWrapper randomWrapper
            , IMapper mapper,ILogger<HomeController> logger,
            IFileProvider fileProvider)
        {
            _repository = repository;
            _randomService = randomService;
            _randomWrapper = randomWrapper;
            _mapper = mapper;
            _logger = logger;
            _fileProvider = fileProvider;
        }
       

        public IActionResult Index(string category,int productPage =1)
        {
            // Product Infromation : Model11
           var  products = _repository.Products
              .Where(p => category == null || p.Category == category)
              .Skip((productPage - 1) * PageSize) 
              .Take(PageSize);

            // Pagination Infromation : Model 2
            var PagingInfo = new PagingInfo
            {
                CurrentPage= productPage,
                ItemsPerPage= PageSize,
                TotalItems= category ==null? _repository.Products.Count(): //Select Count(Product)
                _repository.Products.Where(e=>e.Category == category).Count() // Select C(P) Where Cat= category
            };
            var productListViewModel = new ProductListViewModel
            {
                Products = products,
                 PagingInfo= PagingInfo

            };
            _logger.LogInformation("Product Received");
            // string result = "Random Number From Random Service =" +_randomService.GetNumber();
            string result = $"Random Number From Random Service = { _randomService.GetNumber()} ," +
                $" Random Wrapper  Number : {_randomWrapper.GetRandomNumberFromRandomService()}";
            ViewBag.Result = result;
            _logger.LogInformation("Product Pass to View");
            //Product + PAgination
            return View(productListViewModel); //Page       
        }
        public IActionResult AboutUs()
        {
            throw new Exception();
           // return View(); //Page
        }
        public IActionResult Contact()
        {
            var directories = _fileProvider.GetDirectoryContents("KYC"); // 3 Folders
            return View(directories); //Page
        }

        // Accept that file as a Parameter
        // IFormFile Represents a Single file coming from the application
        [HttpPost]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            // Generate Paths for this files
            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length >  0)
                {
                    // Create a Path  :  CurrentDir +  KYC + fileName
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "KYC", formFile.FileName);
                    filePaths.Add(path);

                    // Generate or Copy file in above path.
                    using (var stream =  new FileStream(path,FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new { count = files.Count, size, filePaths});
        }

        public IActionResult Details(int id)
        {
            //Get the data related to this id and pass it to view to display
            // Product Select : infromation  We need to get and pass it to view.

            var product = _repository.GetProductById(id);
            _logger.LogInformation("Product Received from Get Product By Id Method");
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
                _logger.LogInformation("Model State is Valid");
                var product = _mapper.Map<Product>(productAddViewModel);
                _repository.AddProduct(product); // AddProduct : Product
                return RedirectToAction("Index", "Home");
            }
            _logger.LogError("Model State is Invalid");
            return View();

        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            _logger.LogInformation("Product Deleted for Id "+ id);
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
                _logger.LogInformation("Model State is Valid " );
                var product = _mapper.Map<Product>(productEditViewModel);
                _repository.UpdateProduct(product);
                return RedirectToAction("Index", "Home");
            }
            _logger.LogError("Model State is invalid during update operation for  "+productEditViewModel.ProductId + ""+productEditViewModel.Name);
            return View();
        }

       
        public IActionResult VerifyCategory(string category)
        {
            // if Category  Chess/Cricket/Soccer true
            if (category == "Soccer" || category == "Chess" || category == "Cricket")
            {
                return Json(true);
            }
            return Json("Only Cricket/Soccer/Chess allowed in Category");
        }

        public IActionResult CheckWebAPI()
        {
            return View();
        }

    }
}
