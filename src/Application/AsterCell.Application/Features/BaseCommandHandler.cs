using AutoMapper;

namespace AsterCell.Application.Features
{
    public class BaseCommandHandler
    {
        protected readonly IMapper _mapper;

        public BaseCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
