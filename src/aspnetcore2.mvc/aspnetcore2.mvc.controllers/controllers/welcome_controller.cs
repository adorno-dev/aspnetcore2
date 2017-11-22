using Microsoft.AspNetCore.Mvc;

namespace AspnetCore2.Mvc.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Simple Welcome Controller");
        }
    }
}