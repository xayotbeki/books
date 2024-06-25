using Microsoft.AspNetCore.Mvc;

namespace books.HomeController
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
