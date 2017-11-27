using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AspnetCore2.Jwt.Api
{
    public static class HttpCodesExtension
    {
        private static string Output(object content) => JsonConvert.SerializeObject(content);
        private static string ContentType = "application/json";

        public static Task HttpCodeMessage(this StatusCodeContext context)
        {
            context.HttpContext.Response.ContentType = ContentType;

            switch (context.HttpContext.Response.StatusCode)
            {
                case StatusCodes.Status401Unauthorized: return Unauthorized(context);
                case StatusCodes.Status403Forbidden: return Forbidden(context);
                case StatusCodes.Status404NotFound: return NotFound(context);
                case StatusCodes.Status500InternalServerError: return InternalServerError(context);
            }

            return Task.CompletedTask;
        }

        private static Task Forbidden(this StatusCodeContext context)
        {
            var response = new 
            { 
                Message = "Forbidden",
                HttpCode = context.HttpContext.Response.StatusCode
            };

            return context.HttpContext.Response.WriteAsync(Output(response));
        }

        private static Task NotFound(this StatusCodeContext context)
        {
            var response = new 
            { 
                Message = "NotFound",
                HttpCode = context.HttpContext.Response.StatusCode
            };

            return context.HttpContext.Response.WriteAsync(Output(response));
        }

        private static Task Unauthorized(this StatusCodeContext context)
        {
            var response = new 
            {
                Message = "Unauthorized",
                HttpCode = context.HttpContext.Response.StatusCode
            };
            
            return context.HttpContext.Response.WriteAsync(Output(response));
        }

        private static Task InternalServerError(this StatusCodeContext context)
        {
            var response = new 
            {
                Message = "InternalServerError",
                HttpCode = context.HttpContext.Response.StatusCode
            };
            
            return context.HttpContext.Response.WriteAsync(Output(response));
        }
    }
}