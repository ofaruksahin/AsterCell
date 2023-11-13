using AsterCell.Persistence.Common.Repositories;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Domain.Models;

namespace Asterisk.Persistence.Repositories
{
    public class EndpointAorRepository : GenericRepository<EndpointAor>, IEndpointAorRepository
    {
        public EndpointAorRepository(AsteriskDbContext asteriskDbContext) : base(asteriskDbContext)
        {
        }
    }
}
