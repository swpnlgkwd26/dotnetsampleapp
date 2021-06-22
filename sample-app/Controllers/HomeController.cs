using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    // Controller its base class for Controller
    // it gives the capability to HomeCtrl To Return View Or Page
    //  ViewResult, JsonResult, PartialView

    // Controller class : ControllerBase : that is used in the REST API

    public class HomeController : Controller
    {
        // Action Methods
        // IActionResult : It can Return Multiple Types
        // String Page, File, JSON , Route,RedirectoAction 
        public IActionResult Index()
        {
             return View(); //Page       
        }       

        public IActionResult AboutUs()
        {
            return View(); //Page
        }

        public IActionResult Contact()
        {
            return View(); //Page
        }


    }
}
