using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sample_app.Models;
using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRespository _customerRespository;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger,
            ICustomerRespository customerRespository,IMapper mapper)
        {
            _logger = logger;
            _customerRespository = customerRespository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var customers = _customerRespository.Customers;
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerAddModel customerAddModel)
        {
            // Automapper :   One Object another Object Convert
           var customer= _mapper.Map<Customer>(customerAddModel);
            _customerRespository.AddCustomer(customer);
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
