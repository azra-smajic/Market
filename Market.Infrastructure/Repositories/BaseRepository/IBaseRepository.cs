﻿using Market.Core.Entities.BaseEntity;

namespace Market.Infrastructure.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity, in TPrimaryKey> where TEntity : class
    {
        Task<TEntity> GetById(int id);

        Task<TEntity> GetByIdAsync(TPrimaryKey id, bool asNoTracking = false);

        Task<List<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        Task<TDto> AddAsync<TDto>(TDto entityDto);

        Task AddRangeAsync<TDto>(IEnumerable<TDto> entitiesDto);

        Task RemoveByIdAsync(int id, bool isSoft = true);

        Task RemoveRange<TDto>(IEnumerable<TDto> entitiesDto, bool isSoft = true) where TDto : class, IBaseEntity;

        void Update(TEntity entity);

        void Update<TDto>(TDto entity);

        void UpdateRange<TDto>(IEnumerable<TDto> entitiesDto);
    }
}