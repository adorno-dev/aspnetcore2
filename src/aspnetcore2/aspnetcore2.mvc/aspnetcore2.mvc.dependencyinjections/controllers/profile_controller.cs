using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCore2.Mvc.DependencyInjections.Data.Interfaces;
using AspnetCore2.Mvc.DependencyInjections.Models;

namespace Aspnet.Core.DependencyInjectionViews.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index() =>
            View(new Profile { Name = "Steve", FavColor = "Blue", Gender = "Male", State = new State("Ohio", "OH") } );
    }
}