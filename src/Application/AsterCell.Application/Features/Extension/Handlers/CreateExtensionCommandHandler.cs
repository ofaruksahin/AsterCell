using AsterCell.Application.Common.Contracts;
using AsterCell.Application.Common.Models;
using AsterCell.Application.Features.Extension.Commands;
using AutoMapper;
using MediatR;

namespace AsterCell.Application.Features.Extension.Handlers
{
    public class CreateExtensionCommandHandler : BaseCommandHandler, IRequestHandler<CreateExtensionCommand, ApiResponse>
    {

        public CreateExtensionCommandHandler(
            IMapper mapper,
            IUserInfo userInfo)
            : base(mapper,userInfo)
        {
        }

        public async Task<ApiResponse> Handle(CreateExtensionCommand request, CancellationToken cancellationToken)
        {
            await _userInfo.IsAuthenticated();
            return ApiResponse.Success(new { });
        }
    }
}
