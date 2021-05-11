using Grocery.Api.Pipeline.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Api.Pipeline.Extensions
{
    public static class ExceptionFilterExtension
    {
        public static void ExceptionFilterHandling(this MvcOptions options)
        {
            options.Filters.Add(typeof(GlobalExceptionFilter));
        }
    }
}