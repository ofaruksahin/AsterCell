using AsterCell.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asterisk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
