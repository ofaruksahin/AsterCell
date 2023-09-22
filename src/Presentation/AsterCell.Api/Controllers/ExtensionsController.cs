using AsterCell.Application.Common.Contracts;
using AsterCell.Application.Features.Extension.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AsterCell.Api.Controllers
{
    public class ExtensionsController : BaseController
    {
        private IUserInfo _user;

        public ExtensionsController(
            IMediator mediator,
            IUserInfo user)
            : base(mediator)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExtensionCommand command)
        {
            await _user.IsAuthenticated();
            var response = await _mediator.Send(command);
            return Response(response);
        }
    }
}
