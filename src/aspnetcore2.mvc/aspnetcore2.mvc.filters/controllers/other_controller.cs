using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aspnet.Core.Filters.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index() => Content("Other controller.. see the headers on request.");
    }
}