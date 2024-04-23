using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;

namespace Get_Help.Attributes.ActionFilterAttributes
{
    public class AllowAgents : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;
            var userManager = context.HttpContext.RequestServices.GetService<UserManager<Agent>>();
            var agentUser = userManager.GetUserAsync(user).Result;
            if (agentUser == null)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
