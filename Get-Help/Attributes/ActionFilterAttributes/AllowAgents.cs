﻿using Get_Help.Infrastructure.Data.Models;
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
            base.OnActionExecuting(context);

            if (!context.HttpContext.User.IsInRole("Agent"))
            {
                // return 404 to unauthorized for safety
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }
    }
}
