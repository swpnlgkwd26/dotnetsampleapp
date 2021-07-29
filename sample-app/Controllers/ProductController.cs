using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public int PageSize = 2;

        public ProductController(IStoreRepository repository)
        {
            _repository = repository;

        }
        public IActionResult Index()
        {
            return View(_repository.Products);
        }

        // Pagination

        public IActionResult IndexWithPagination(int productPage)
        {
            var Query = _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);
            return View(Query);
        }
    }
}
