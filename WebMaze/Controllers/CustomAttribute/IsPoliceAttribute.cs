using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Services;

namespace WebMaze.Controllers.CustomAttribute
{
    public class IsPoliceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userSerivece = context.HttpContext.RequestServices
                .GetService(typeof(UserService)) as UserService;

            if (userSerivece.GetCurrentUser().PlaceOfWork?.ToLower() != "police")
            {
                context.Result = new ForbidResult();
            }
           
        }
    }
}
