using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCore2.Mvc.DependencyInjections.Data.Interfaces;

namespace Aspnet.Core.DependencyInjectionViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoItemRepository _repository;

        public HomeController(ITodoItemRepository repository) => _repository = repository;

        public IActionResult Index() => View(model: _repository.List());
    }
}