using Grocery.WebApi.Pipeline.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.WebApi.Pipeline.Extensions
{
    public static class ExceptionFilterExtension
    {
        public static void ExceptionFilterHandling(this MvcOptions options)
        {
            options.Filters.Add(typeof(GlobalExceptionFilter));
        }
    }
}