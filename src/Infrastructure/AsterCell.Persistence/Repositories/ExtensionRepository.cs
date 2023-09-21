using AsterCell.Application.Contrracts.Repositories;
using AsterCell.Domain.Models;
using AsterCell.Persistence.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.Persistence.Repositories
{
    public class ExtensionRepository : GenericRepository<Extension, int>, IExtensionRepository
    {
        private AsterCellDbContext _asterCellDbContext;

        public ExtensionRepository(AsterCellDbContext dbContext) : base(dbContext)
        {
            _asterCellDbContext = dbContext;
        }
    }
}
