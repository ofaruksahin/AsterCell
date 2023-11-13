using Asterisk.Application.Features.Endpoint.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asterisk.Api.Controllers
{
    public class EndpointController : BaseController
    {
        public EndpointController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateEndpoint(CreateEndpointCommand command)
        {
            var response = await _mediator.Send(command);
            return Response(response);
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteEndpoint(string userName)
        {
            var command = new DeleteEndpointCommand(userName);
            var response = await _mediator.Send(command);
            return Response(response);
        }
    }
}
