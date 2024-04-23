using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Get_Help.Attributes.ActionFilterAttributes
{
    public class AllowAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.HttpContext.User.IsInRole("Admin"))
            {
                // return 404 to unauthorized for safety
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }
    }
}
