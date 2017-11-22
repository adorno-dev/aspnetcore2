using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore2.Mvc.PartialViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View();
    }
}