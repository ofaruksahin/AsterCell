using AsterCell.Api.Filters;
using AsterCell.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AsterCell.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthenticationFilter]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [NonAction]
        public IActionResult Response(ApiResponse response)
        {
            return new OkObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
