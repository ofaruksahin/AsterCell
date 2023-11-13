using AsterCell.Persistence.Common.Repositories;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Domain.Models;

namespace Asterisk.Persistence.Repositories
{
    public class EndpointAuthRepository : GenericRepository<EndpointAuth>, IEndpointAuthRepository
    {
        public EndpointAuthRepository(AsteriskDbContext asteriskDbContext) : base(asteriskDbContext)
        {
        }
    }
}
