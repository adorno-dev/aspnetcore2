using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspnetCore2.Mvc.Filters
{
    public class AddHeaderWithFactory : IFilterFactory
    {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
            => new AddHeaderFilter();

        private class AddHeaderFilter : IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext context) {}

            public void OnResultExecuting(ResultExecutingContext context)
                => context.HttpContext.Response.Headers.Add("FilterFactoryHeader", new string[] 
                {
                    "Filter Factory Header Value #1",
                    "Filter Factory Header Value #2"
                });
        }
    }
}