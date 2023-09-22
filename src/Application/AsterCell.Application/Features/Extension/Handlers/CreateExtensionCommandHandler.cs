using AsterCell.Application.Common.Contracts;
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
            IMapper mapper,
            IUserInfo userInfo,
            IExtensionService extensionService)
            : base(mapper,userInfo)
        {
            _extensionService = extensionService;
        }

        public async Task<ApiResponse> Handle(CreateExtensionCommand request, CancellationToken cancellationToken)
        {
            await _userInfo.IsAuthenticated();
            return ApiResponse.Success(new { });
        }
    }
}
