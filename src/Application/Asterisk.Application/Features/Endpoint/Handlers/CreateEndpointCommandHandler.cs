using AsterCell.Application.Common.Models;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Application.Features.Endpoint.Commands;
using Asterisk.Domain.Enums;
using MediatR;
using System.Net;

namespace Asterisk.Application.Features.Endpoint.Handlers
{
    public class CreateEndpointCommandHandler : IRequestHandler<CreateEndpointCommand, ApiResponse>
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly IEndpointAorRepository _endpointAorRepository;
        private readonly IEndpointAuthRepository _endpointAuthRepository;

        public CreateEndpointCommandHandler(
            IEndpointRepository endpointRepository,
            IEndpointAorRepository endpointAorRepository,
            IEndpointAuthRepository endpointAuthRepository
            )
        {
            _endpointRepository = endpointRepository;
            _endpointAorRepository = endpointAorRepository;
            _endpointAuthRepository = endpointAuthRepository;
        }

        public async Task<ApiResponse> Handle(CreateEndpointCommand request, CancellationToken cancellationToken)
        {
            var endpoint = new Asterisk.Domain.Models.Endpoint
            {
                Id = request.Username,
                Aors = request.Username,
                Auth = request.Password,
                Context = request.Context,
                Disallow = "all",
                Allow = "ulaw,opus",
                IceSupport = request.EnableWebRTC ? YesNoEnum.Yes.Value : null,
                UseAvpf = request.EnableWebRTC ? YesNoEnum.Yes.Value : null,
                MediaEncryption = request.EnableWebRTC ? "dtls" : null,
                DtlsVerify = request.EnableWebRTC ? "fingerprint" : null,
                DtlsCertFile = request.EnableWebRTC ? request.CertificateCertFile : null,
                DtlsCaFile = request.EnableWebRTC ? request.CertificateCAFile : null,
                DtlsSetup = request.EnableWebRTC ? "actpass": null,
                MediaUseReceivedTransport = YesNoEnum.Yes.Value,
                RtcpMux = request.EnableWebRTC ? YesNoEnum.Yes.Value : null
            };

            var endpointAuth = new Asterisk.Domain.Models.EndpointAuth
            {
                Id = request.Username,
                AuthType = EndpointAuthTypeEnum.Userpass.Value,
                Password = request.Password,
                Username = request.Username
            };

            var endpointAor = new Asterisk.Domain.Models.EndpointAor
            {
                Id = request.Username,
                MaxContacts = 1,
                RemoveExisting = YesNoEnum.Yes.Value
            };

            await _endpointRepository.AddAsync(endpoint);
            await _endpointAuthRepository.AddAsync(endpointAuth);
            await _endpointAorRepository.AddAsync(endpointAor);

            var isCreated = await _endpointRepository.CompleteTransaction();

            if (!isCreated)
                return ApiResponse.Fail(new NoContent(), "Extension is not created", (int)HttpStatusCode.NotFound);
            return ApiResponse.Success(new NoContent());
        }
    }
}
