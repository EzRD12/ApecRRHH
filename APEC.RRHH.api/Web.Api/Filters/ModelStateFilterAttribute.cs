using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Api.Helpers;

namespace Web.Api.Filters
{
    internal sealed class ModelStateFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">An <see cref="ActionExecutingContext"/></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(Error.BuildBadRequest(context.ModelState.Values.GetErrorMessages("\n")));
            }
        }
    }
}
