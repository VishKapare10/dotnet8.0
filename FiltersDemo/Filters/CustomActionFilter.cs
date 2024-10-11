using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersDemo.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action is executing...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action has executed.");
        }
    }
}
