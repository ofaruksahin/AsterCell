using AsterCell.Persistence.Common.Repositories;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Domain.Models;

namespace Asterisk.Persistence.Repositories
{
    public class EndpointRepository : GenericRepository<Endpoint>, IEndpointRepository
    {
        public EndpointRepository(AsteriskDbContext asteriskDbContext) : base(asteriskDbContext)
        {
        }
    }
}
