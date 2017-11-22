using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aspnet.Core.Mvc.Models;

namespace Aspnet.Core.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(bool approved = false)
        => View(new WebSiteContext { Version = new Version(1, 3, 3, 7), CopyrightYear = 2015, Approved = approved, TagsToShow = 20 });


        public IActionResult Form()
        => View();
    }
}