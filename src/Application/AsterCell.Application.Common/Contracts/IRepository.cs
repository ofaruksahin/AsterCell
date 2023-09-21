using AsterCell.Common.Models;

namespace AsterCell.Application.Common.Contracts
{
    public interface IRepository<TEntity,TId>
        where TEntity : BaseEntity<TId>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);   
        Task<List<TEntity>> GetAllActiveRecordsAsync();
        Task<TEntity> GetActiveRecordAsync(TId id);
        Task<PaginatedModel<TEntity>> PaginateActiveRecordsAsync(PaginationFilter paginationFilter);
    }
}
