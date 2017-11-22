using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aspnet.Core.Filters.Filters;

namespace Aspnet.Core.Filters.Controllers
{
    /// <summary>
    /// Controller used by filters.
    /// See the global settings in Startup.cs (We can apply a global filter there!)
    /// </summary>

    [SampleActionFilter]
    [SampleAsyncActionFilter]
    [AddHeaderWithFactory]
    [AddHeader("Author", "Steve Smith @ardalis")]
    public class HomeController : Controller
    {
        public IActionResult Index() => Content("Examine the headers using developer tools.");

        // [ShortCircuitingResourceFilter]
        public IActionResult SomeResource() => Content("Successfully access to resource - Header should be set.");
    }
}