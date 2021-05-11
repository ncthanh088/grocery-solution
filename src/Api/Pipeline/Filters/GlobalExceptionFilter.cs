using System.Collections.Generic;
using System.Threading.Tasks;
using Grocery.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Grocery.Api.Pipeline.Filters
{
    /// <summary>
    /// Reference: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-5.0#exception-filters
    /// </summary>
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        public GlobalExceptionFilter()
        {

        }
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var customProperties = new Dictionary<string, string>();
            string body = string.Empty;

            // Get request header info
            foreach (var header in context.HttpContext.Request.Headers)
            {
                customProperties[header.Key] = header.Value.ToString();
            }

            // Get request body info
            if (context.HttpContext.Request.Method == Microsoft.AspNetCore.Http.HttpMethods.Post)
            {
                try
                {
                    using (var reader = new System.IO.StreamReader(context.HttpContext.Request.Body, System.Text.Encoding.UTF8))
                    {
                        customProperties["body"] = await reader.ReadToEndAsync();
                    }
                }
                catch { }
            }
            
            // Classification exception
            switch (exception)
            {
                case ForbiddenException forbidden:
                    context.Result = new NotFoundObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;

                case EntityInvalidException entityInvalid:
                    context.Result = new NotFoundObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;

                case EntityNotFoundException entityNotFound:
                    context.Result = new NotFoundObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;

                default:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}