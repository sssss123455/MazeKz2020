using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Services;

namespace WebMaze.Controllers.CustomAttribute
{
    public class IsMorgueAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userSerivece = context.HttpContext.RequestServices
                .GetService(typeof(UserService)) as UserService;

            if (userSerivece.GetCurrentUser().Role?.ToLower() != "morgue")
            {
                context.Result = new ForbidResult();
            }
           
        }
    }
}
