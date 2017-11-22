using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet.Core.Filters.Filters
{
    //public class SampleActionFilterAttribute : TypeFilterAttribute
    //{
    //    public SampleActionFilterAttribute(Type type) : base(type) { }

    //    private class SampleActionFilterImpl : IActionFilter
    //    {
    //        private readonly ILogger _logger;

    //        public SampleActionFilterImpl(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger<SampleActionFilterAttribute>();

    //        public void OnActionExecuted(ActionExecutedContext context) => _logger.LogInformation("Business action starting...");   // perform some business logic work...

    //        public void OnActionExecuting(ActionExecutingContext context) => _logger.LogInformation("Business action completed.");  // perform some business logic work...
    //    }
    //}
}
