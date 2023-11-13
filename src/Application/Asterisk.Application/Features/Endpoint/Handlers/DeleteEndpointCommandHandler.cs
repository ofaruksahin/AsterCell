using AsterCell.Application.Common.Models;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Application.Features.Endpoint.Commands;
using MediatR;

namespace Asterisk.Application.Features.Endpoint.Handlers
{
    public class DeleteEndpointCommandHandler : IRequestHandler<DeleteEndpointCommand, ApiResponse>
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly IEndpointAorRepository _endpointAorRepository;
        private readonly IEndpointAuthRepository _endpointAuthRepository;

        public DeleteEndpointCommandHandler(
            IEndpointRepository endpointRepository,
            IEndpointAorRepository endpointAorRepository,
            IEndpointAuthRepository endpointAuthRepository
            )
        {
            _endpointRepository = endpointRepository;
            _endpointAorRepository = endpointAorRepository;
            _endpointAuthRepository = endpointAuthRepository;
        }

        public async Task<ApiResponse> Handle(DeleteEndpointCommand request, CancellationToken cancellationToken)
        {
            var endpoint = await _endpointRepository.GetActiveRecordAsync(request.Username);
            if (endpoint is null)
                return ApiResponse.Fail(new NoContent(), "Extension is not found");

            var endpointAor = await _endpointAorRepository.GetActiveRecordAsync(request.Username);
            if (endpointAor is null)
                return ApiResponse.Fail(new NoContent(), "Extension is not found");

            var endpointAuth= await _endpointAuthRepository.GetActiveRecordAsync(request.Username);
            if (endpointAuth is null)
                return ApiResponse.Fail(new NoContent(), "Endpoint is not found");

            _endpointRepository.Delete(endpoint);
            _endpointAorRepository.Delete(endpointAor);
            _endpointAuthRepository.Delete(endpointAuth);

            var isDeleted = await _endpointRepository.CompleteTransaction();
            if (!isDeleted)
                return ApiResponse.Fail(new NoContent(), "Extension is not deleted");

            return ApiResponse.Success(new NoContent());
        }
    }
}
