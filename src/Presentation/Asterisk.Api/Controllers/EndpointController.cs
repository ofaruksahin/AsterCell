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

        /// <summary>
        /// Asteriske dahili tanımlamak için kullanılır
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEndpoint(CreateEndpointCommand command)
        {
            var response = await _mediator.Send(command);
            return Response(response);
        }

        /// <summary>
        /// Asteriskte tanımlı dahiliyi silmek için kullanılır
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteEndpoint(string userName)
        {
            var command = new DeleteEndpointCommand(userName);
            var response = await _mediator.Send(command);
            return Response(response);
        }

        /// <summary>
        /// Asteriskte tanımlı dahili bilgilerini güncellemek için kullanılır
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{userName}")]
        public async Task<IActionResult> UpdateEndpoint(string userName, UpdateEndpointCommand command)
        {
            command.Username = userName;
            var response = await _mediator.Send(command);
            return Response(response);
        }
    }
}
