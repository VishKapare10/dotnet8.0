using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersDemo.Filters
{
    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Result is executing...");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Result has executed.");
        }
    }
}
