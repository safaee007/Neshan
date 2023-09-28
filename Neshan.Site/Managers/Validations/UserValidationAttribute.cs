using Microsoft.AspNetCore.Mvc.Filters;

namespace Neshan.Site.Managers
{
    public class UserValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if(!actionContext.ModelState.IsValid)
            {

            }
        }
    }
}
