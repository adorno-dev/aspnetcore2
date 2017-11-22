using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet.Core.Filters.Filters
{
    public class SampleActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("SampleActionFilter: Do something before the action executes..");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("SampleActionFilter: Do something after the action executes..");
        }
    }
}
