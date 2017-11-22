using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCore2.Mvc.ViewComponents.Models;

namespace AspnetCore2.Mvc.ViewComponents.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context) => _context = context;

        public IActionResult Index() => View(_context.Todo.ToList());

        //public IActionResult Index() => ViewComponent("PriorityList", new { maxPriority = 3, isDone = false });
    }
}