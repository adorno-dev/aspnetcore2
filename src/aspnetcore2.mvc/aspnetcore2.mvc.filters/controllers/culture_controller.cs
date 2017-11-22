using Aspnet.Core.Filters.Middlewares;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet.Core.Filters.Controllers
{
    public class CultureController : Controller
    {
        [MiddlewareFilter(typeof(LocalizationPipeline))]
        public IActionResult Index() => 
            Content($"CurrentCulture: {CultureInfo.CurrentCulture.Name}, CultureUICulture: {CultureInfo.CurrentUICulture.Name}");
    }
}
