using AsterCell.Application.Features.Extension.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AsterCell.Api.Controllers
{
    public class ExtensionsController : BaseController
    {
        public ExtensionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExtensionCommand command)
        {
            var response = await _mediator.Send(command);
            return Response(response);
        }
    }
}
