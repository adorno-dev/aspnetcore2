using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aspnet.Core.Filters.Filters;

namespace Aspnet.Core.Filters.Controllers
{
    [AddHeader("Author", "Steve Smith @ardalis")]
    public class SampleController : Controller
    {
        public IActionResult Index() => Content("Examine the headers using developer tools.");

        [ShortCircuitingResourceFilter] // This filter runs first because AddHeader is an Action Filter and this is a Resource Filter
        public IActionResult SomeResource() => Content("Successful access to resource - Header should be set.");
    }
}