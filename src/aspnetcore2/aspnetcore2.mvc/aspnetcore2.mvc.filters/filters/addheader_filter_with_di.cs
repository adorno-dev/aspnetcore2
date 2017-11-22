using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet.Core.Filters.Filters
{
    public class AddHeaderFilterWithDI : IResultFilter
    {
        private ILogger _logger;

        public AddHeaderFilterWithDI(ILogger logger) => _logger = logger;

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // can't add to headers here because response has already begun.
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var header = new { Key = "OnResultExecuting", Value = new [] { "ResultExecutingSuccessfully" } };

            context.HttpContext.Response.Headers.Add(header.Key, header.Value);

            _logger.LogInformation($"Header added: {header.Key}");
        }
    }
}
