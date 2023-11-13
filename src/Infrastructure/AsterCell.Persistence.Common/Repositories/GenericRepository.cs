using AsterCell.Application.Common.Contracts;
using AsterCell.Common.Enums;
using AsterCell.Common.Models;
using AsterCell.Persistence.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.Persistence.Common.Repositories
{
    public class GenericRepository<TEntity, TId> : IRepository<TEntity, TId>, IUnitOfWork
        where TEntity : BaseEntity<TId>
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            entity.Status = RecordStatusEnum.Passive.Value;
            Update(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            entities.ForEach(item => item.Status = RecordStatusEnum.Passive.Value);
            UpdateRange(entities);
        }

        public async Task<List<TEntity>> GetAllActiveRecordsAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(f => f.Status == RecordStatusEnum.Active.Value)
                .ToListAsync();
        }

        public async Task<TEntity> GetActiveRecordAsync(TId id)
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(f =>
                    f.Id.Equals(id) &&
                    f.Status == RecordStatusEnum.Active.Value)
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedModel<TEntity>> PaginateActiveRecordsAsync(PaginationFilter paginationFilter)
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(f => f.Status == RecordStatusEnum.Active.Value)
                .PaginateAsync(paginationFilter);
        }

        public async Task<bool> CompleteTransaction(string user = "SYSTEM")
        {
            if (_dbContext is IUnitOfWork unitOfWork)
                return await unitOfWork.CompleteTransaction(user);
            return false;
        }
    }

    public class GenericRepository<TEntity> : IRepository<TEntity>, IUnitOfWork
        where TEntity : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<List<TEntity>> GetAllActiveRecordsAsync()
        {
            return await _dbContext
                .Set<TEntity>()
            .ToListAsync();
        }

        public async Task<TEntity> GetActiveRecordAsync(string id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FindAsync(id);
        }

        public async Task<bool> CompleteTransaction(string user = "SYSTEM")
        {
            if (_dbContext is IUnitOfWork unitOfWork)
                return await unitOfWork.CompleteTransaction(user);
            return false;
        }
    }
}
