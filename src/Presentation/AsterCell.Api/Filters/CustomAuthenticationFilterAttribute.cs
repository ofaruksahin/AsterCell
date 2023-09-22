using AsterCell.Application.Common.Contracts;
using AsterCell.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AsterCell.Api.Filters
{
    public class CustomAuthenticationFilterAttribute : ActionFilterAttribute
    {
        private IUserInfo _userInfo;

        public string Role { get; set; }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);
                if (actionAttributes.Any(f => f.GetType() == typeof(AllowAnonymousAttribute)))
                    return base.OnActionExecutionAsync(context, next);
            }

            _userInfo = context.HttpContext.RequestServices.GetRequiredService<IUserInfo>();

            var isAuthenticated = _userInfo
                .IsAuthenticated()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (!isAuthenticated)
                return UnAuthorized(context, HttpStatusCode.Unauthorized);

            if (!string.IsNullOrEmpty(Role) && !_userInfo.Roles.Contains(Role))
                return UnAuthorized(context, HttpStatusCode.Forbidden);

            return base.OnActionExecutionAsync(context, next);
        }

        private Task UnAuthorized(ActionExecutingContext context, HttpStatusCode httpStatusCode)
        {
            var apiResponse = ApiResponse<NoContent>.Fail(
                new NoContent(),
                new List<string> { "Buraya ulaşmak için yetkiniz bulunamadı" },
                (int)httpStatusCode);

            context.Result = new UnauthorizedObjectResult(apiResponse)
            {
                StatusCode = apiResponse.StatusCode
            };

            return Task.CompletedTask;
        }
    }
}
