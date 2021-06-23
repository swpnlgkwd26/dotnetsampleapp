using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            // Mocking the Data  : Lets say i have Customer information
            // ViewBag to Store

            //ViewBag.CustomerId = 1;
            //ViewBag.CustomerName = "Rohit";
            //ViewBag.Address = "Delhi";
            Customer customer = new Customer
            {
                CustomerId =1,CustomerName ="Rohit",Address = "Delhi"
            };
            Customer customer2 = new Customer
            {
                CustomerId = 2,
                CustomerName = "Arti",
                Address = "Delhi"
            };
            List<Customer> listCustomer = new List<Customer>();
            listCustomer.Add(customer);
            listCustomer.Add(customer2);
            return View(listCustomer);
        }
    }
}
