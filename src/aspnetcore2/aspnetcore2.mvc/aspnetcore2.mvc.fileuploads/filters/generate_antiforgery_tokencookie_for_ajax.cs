using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Aspnet.Core.Controllers.FileUpload.Filters
{
    public class GenerateAntiforgeryTokenCookieForAjax : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // var antiForgery = context.HttpContext.RequestServices.GetService<IAntiforgery>();

            // We can send the request token as a javascript-readeable cookie, and angular will use it by default.
            // var token = antiForgery.GetAndStoreTokens(context.HttpContext);

            // context.HttpContext.Response.Cookies.Append("XSRF-TOKEN", token.RequestToken, new CookieOptions { HttpOnly = false });
        }
    }
}
