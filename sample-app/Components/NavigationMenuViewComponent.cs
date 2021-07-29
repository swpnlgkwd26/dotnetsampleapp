using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Components
{
    public class NavigationMenuViewComponent :ViewComponent
    {
        private readonly IStoreRepository _repository;

        public NavigationMenuViewComponent(IStoreRepository repository)
        {
            _repository = repository;
        }
        // Automatically Called Whenever NV Will be used
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            // Through Store Repository i can connect to ProductMemory Data
            // Select Distinct Category From Table 
            var distinctCategory = _repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(category => category);

            return View(distinctCategory);
        }
    }
}
