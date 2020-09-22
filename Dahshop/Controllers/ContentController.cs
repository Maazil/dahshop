using Microsoft.AspNetCore.Mvc;

namespace Dahshop.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Content()
        {
            return View();
        }
    }
}