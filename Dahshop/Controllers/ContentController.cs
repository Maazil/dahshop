using Microsoft.AspNetCore.Mvc;

namespace Dahshop.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}