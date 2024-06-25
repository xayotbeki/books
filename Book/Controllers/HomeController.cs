using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
