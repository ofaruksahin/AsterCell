using AsterCell.Application.Common.Models;
using MediatR;

namespace Asterisk.Application.Features.Endpoint.Commands
{
    public class DeleteEndpointCommand : IRequest<ApiResponse>
    {
        public string Username { get; set; }

        public DeleteEndpointCommand(string userName)
        {
            Username = userName;
        }
    }
}
