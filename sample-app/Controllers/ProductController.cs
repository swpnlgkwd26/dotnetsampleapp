using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly IStoreRepository _repository;

        public ProductController(IStoreRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.Products);
        }
    }
}
