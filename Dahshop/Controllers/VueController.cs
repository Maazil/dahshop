using System;
using Microsoft.AspNetCore.Mvc;

namespace Dahshop.Controllers
{
    public class VueController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}