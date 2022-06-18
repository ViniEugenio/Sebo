using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Sebo.WebApi.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {

                var FoundedErrors = context.ModelState.SelectMany(model => model.Value.Errors)
                    .Select(error => error.ErrorMessage);

                context.Result = new BadRequestObjectResult(new
                {
                    Errors = FoundedErrors
                });

            }

        }
    }
}
