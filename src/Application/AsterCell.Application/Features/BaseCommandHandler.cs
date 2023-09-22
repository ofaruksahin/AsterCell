using AsterCell.Application.Common.Contracts;
using AutoMapper;

namespace AsterCell.Application.Features
{
    public class BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IUserInfo _userInfo;

        public BaseCommandHandler(
            IMapper mapper,
            IUserInfo userInfo)
        {
            _mapper = mapper;
            _userInfo = userInfo;
        }
    }
}
