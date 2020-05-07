using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using CoreAngularDemo.BLL.Factories;
using CoreAngularDemo.BLL.Services.Interfaces;

namespace CoreAngularDemo.API.EndpointFilters.OnActionExecuting
{
    public class SetCurrentUserAttribute : ActionFilterAttribute
    {
        private readonly IUserService _userService;

        public SetCurrentUserAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(id))
            {
                _userService.UpdateCurrentUserId(id);
            }
        }
    }
}