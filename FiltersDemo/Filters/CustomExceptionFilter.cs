using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"An exception occurred: {context.Exception.Message}");
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
