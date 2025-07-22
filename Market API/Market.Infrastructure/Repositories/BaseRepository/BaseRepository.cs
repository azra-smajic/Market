using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Market.Core.Entities.BaseEntity;
using Market.Infrastructure.Database;

namespace Market.Infrastructure.Repositories.BaseRepository
{
    public abstract class BaseRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        protected readonly IMapper Mapper;
        protected readonly DatabaseContext DatabaseContext;
        protected DbConnection DbConnection => DatabaseContext.Database.GetDbConnection();

        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(IMapper mapper, DatabaseContext databaseContext)
        {
            Mapper = mapper;
            DatabaseContext = databaseContext;

            _dbSet = DatabaseContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id, bool asNoTracking = false)
        {
            var entity = await _dbSet.FindAsync(id);

            if (asNoTracking)
                DatabaseContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<TDto> AddAsync<TDto>(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            await _dbSet.AddAsync(entity);
            var insertedDto = Mapper.Map<TDto>(entity);

            EventHandler<SavedChangesEventArgs> handler = null;
            DatabaseContext.SavedChanges += handler = (_, _) =>
            {
                Mapper.Map(entity, insertedDto);
                DatabaseContext.SavedChanges -= handler;
            };

            return insertedDto;
        }

        public virtual Task AddRangeAsync<TDto>(IEnumerable<TDto> entitiesDto)
        {
            var entities = Mapper.Map<List<TEntity>>(entitiesDto);
            return DatabaseContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException();

            if (isSoft)
            {
                if (entity is IBaseEntity)
                    (entity as IBaseEntity).IsDeleted = true;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual async Task RemoveRange<TDto>(IEnumerable<TDto> entitiesDto, bool isSoft = true) where TDto : class, IBaseEntity
        {
            var entitesForDelete = new List<TEntity>();
            var entitesForSoftDelete = new List<TEntity>();

            foreach (var dto in entitiesDto)
            {
                var entity = await _dbSet.FindAsync(dto.Id);
                if (entity == null)
                    throw new NullReferenceException();
                if (isSoft)
                {
                    if (entity is IBaseEntity)
                        (entity as IBaseEntity).IsDeleted = true;
                    entitesForSoftDelete.Add(entity);
                }
                else
                {
                    entitesForDelete.Add(entity);
                }
            }
            _dbSet.RemoveRange(entitesForDelete);
            _dbSet.UpdateRange(entitesForSoftDelete);
        }

        public void Update(TEntity entity)
        {
            DatabaseContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public void Update<TDto>(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            if (!_dbSet.Local.Any(e => e == entity))
                _dbSet.Attach(entity);

            DatabaseContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public virtual void UpdateRange<TDto>(IEnumerable<TDto> entitiesDto)
        {
            var entities = Mapper.Map<List<TEntity>>(entitiesDto);

            entities.ForEach(entity =>
            {
                if (!_dbSet.Local.Any(e => e == entity))
                    _dbSet.Attach(entity);

                DatabaseContext.Entry(entity).State = EntityState.Modified;
            });

            _dbSet.UpdateRange(entities);
        }

        protected Task<List<T>> ProjectToListAsync<T>(IQueryable source) => Mapper.ProjectTo<T>(source).ToListAsync();

        protected Task<T> ProjectToFirstAsync<T>(IQueryable source) => Mapper.ProjectTo<T>(source).FirstAsync();

        protected Task<T> ProjectToFirstOrDefaultAsync<T>(IQueryable source) => Mapper.ProjectTo<T>(source).FirstOrDefaultAsync();

        protected Task<T> ProjectToSingleAsync<T>(IQueryable source) => Mapper.ProjectTo<T>(source).SingleAsync();

        protected Task<T> ProjectToSingleOrDefaultAsync<T>(IQueryable source) => Mapper.ProjectTo<T>(source).SingleOrDefaultAsync();
    }
}