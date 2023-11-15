using AsterCell.Application.Common.Models;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Application.Features.Endpoint.Commands;
using Asterisk.Domain.Enums;
using MediatR;
using System.Net;

namespace Asterisk.Application.Features.Endpoint.Handlers
{
    public class UpdateEndpointCommandHandler : IRequestHandler<UpdateEndpointCommand, ApiResponse>
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly IEndpointAuthRepository _endpointAuthRepository;

        public UpdateEndpointCommandHandler(
            IEndpointRepository endpointRepository,
            IEndpointAuthRepository endpointAuthRepository
            )
        {
            _endpointRepository = endpointRepository;
            _endpointAuthRepository = endpointAuthRepository;
        }

        public async Task<ApiResponse> Handle(UpdateEndpointCommand request, CancellationToken cancellationToken)
        {
            var endpoint = await _endpointRepository.GetActiveRecordAsync(request.Username);

            if (endpoint is null)
                return ApiResponse.Fail(new NoContent(), "Endpoint is not found");

            var endpointAuth = await _endpointAuthRepository.GetActiveRecordAsync(request.Username);

            if (endpointAuth is null)
                return ApiResponse.Fail(new NoContent(), "Endpoint is not found");

            endpoint.Context = request.Context;
            endpoint.IceSupport = request.EnableWebRTC ? YesNoEnum.Yes.Value : null;
            endpoint.UseAvpf = request.EnableWebRTC ? YesNoEnum.Yes.Value : null;
            endpoint.MediaEncryption = request.EnableWebRTC ? "dtls" : null;
            endpoint.DtlsVerify = request.EnableWebRTC ? "fingerprint" : null;
            endpoint.DtlsCertFile = request.EnableWebRTC ? request.CertificateCertFile : null;
            endpoint.DtlsCaFile = request.EnableWebRTC ? request.CertificateCAFile : null;
            endpoint.DtlsSetup = request.EnableWebRTC ? "actpass" : null;
            endpoint.RtcpMux = request.EnableWebRTC ? YesNoEnum.Yes.Value : null;

            endpointAuth.Password = request.Password;

            _endpointRepository.Update(endpoint);
            _endpointAuthRepository.Update(endpointAuth);

            var isUpdated = await _endpointRepository.CompleteTransaction();

            if (!isUpdated)
                return ApiResponse.Fail(new NoContent(), "Extension is not updated", (int)HttpStatusCode.NotFound);

            return ApiResponse.Success(new NoContent());
        }
    }
}
