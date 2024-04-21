using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Get_Help.Attributes.ActionFilterAttributes
{
    public class AllowAgents : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            bool isAgent = context.HttpContext.User is Agent;

            if (!isAgent)
            {
                // return 404 to unauthorized for safety
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }
    }
}
