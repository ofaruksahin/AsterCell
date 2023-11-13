using AsterCell.Application.Common.Models;
using MediatR;

namespace Asterisk.Application.Features.Endpoint.Commands
{
    public class CreateEndpointCommand : IRequest<ApiResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Context { get; set; }
        public bool EnableWebRTC { get; set; }
        public string CertificateCertFile { get; set; }
        public string CertificateCAFile { get; set; }
    }
}
