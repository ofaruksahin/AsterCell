﻿using AsterCell.Common.Models;

namespace AsterCell.Application.Common.Contracts
{
    public interface IRepository<TEntity,TId> : IUnitOfWork
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

    public interface IRepository<TEntity> : IUnitOfWork
        where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        Task<TEntity> GetActiveRecordAsync(string id);
    }
}
