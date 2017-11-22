using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aspnet.Core.Areas.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        // GET: /Products/Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Products/Home/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}