using System;
using Microsoft.AspNetCore.Mvc;

namespace Dahshop.Controllers
{
    public class VueController : Controller
    {
        
        public IActionResult Vue()
        {
            return View();
        }
        
    }
}