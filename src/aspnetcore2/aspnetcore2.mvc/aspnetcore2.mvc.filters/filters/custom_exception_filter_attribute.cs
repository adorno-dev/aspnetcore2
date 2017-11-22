using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet.Core.Filters.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        protected CustomExceptionFilterAttribute(IHostingEnvironment hostingEnvironment, IModelMetadataProvider modelMetadataProvider)
            => (_hostingEnvironment, _modelMetadataProvider) = (hostingEnvironment, modelMetadataProvider);

        public override void OnException(ExceptionContext context)
        {
            //if (!_hostingEnvironment.IsDevelopment())
            //    return; // do nothing

            if (_hostingEnvironment.IsDevelopment())
                context.Result = new ViewResult
                {
                    ViewName = "CustomError",
                    ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
                        { ["Exception"] = context.Exception }
                };
        }
    }
}
