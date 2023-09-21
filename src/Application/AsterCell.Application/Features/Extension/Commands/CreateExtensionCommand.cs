using AsterCell.Application.Common.Models;
using MediatR;

namespace AsterCell.Application.Features.Extension.Commands
{
    public class CreateExtensionCommand : IRequest<ApiResponse>
    {
        public string Exten { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
