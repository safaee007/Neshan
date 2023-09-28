using Library.Core.Enums;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Neshan.Site.Managers
{
    public class AuthenticationLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string result = Managers.SessionManager.GetUserSession(actionContext.HttpContext).Result;
            if (!string.IsNullOrEmpty(result))
            {
                actionContext.HttpContext.Items["userID"] = result;
            }
            else
            {
                actionContext.Result = new RedirectResult("/user/login");
            }

            base.OnActionExecuting(actionContext);
        }
    }

    public class LoginedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string result = Managers.SessionManager.GetUserSession(actionContext.HttpContext).Result;
            if (!string.IsNullOrEmpty(result))
            {
                actionContext.Result = new RedirectResult("/");
            }

            base.OnActionExecuting(actionContext);
        }
    }

    public static class HTTPContextManager
    {
        public static Guid getUserID(HttpContext context)
        {
            Guid retVal = Guid.Empty;

            if (context.Items["userID"] != null)
            {
                retVal = Guid.Parse(context.Items["userID"].ToString());
            }

            return retVal;
        }

    }
}
