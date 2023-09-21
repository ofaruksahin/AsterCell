using AsterCell.Application.Common.Models;
using AsterCell.Application.Contrracts.Services;
using AsterCell.Application.Features.Extension.Commands;
using AutoMapper;
using MediatR;

namespace AsterCell.Application.Features.Extension.Handlers
{
    public class CreateExtensionCommandHandler : BaseCommandHandler, IRequestHandler<CreateExtensionCommand, ApiResponse>
    {
        private readonly IExtensionService _extensionService;

        public CreateExtensionCommandHandler(
            IMapper _mapper,
            IExtensionService extensionService)
            : base(_mapper)
        {
            _extensionService = extensionService;
        }

        public async Task<ApiResponse> Handle(CreateExtensionCommand request, CancellationToken cancellationToken)
        {
            return ApiResponse.Success(new { });
        }
    }
}
