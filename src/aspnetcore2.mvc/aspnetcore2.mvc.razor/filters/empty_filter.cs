using Microsoft.AspNetCore.Mvc.Filters;

namespace AspnetCore2.Mvc.Filters
{
    public class EmptyFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) {}

        public void OnActionExecuting(ActionExecutingContext context) {}
    }
}