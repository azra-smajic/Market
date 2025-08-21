using Market.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Market.Infrastructure.Database;
using Market.Infrastructure.Repositories.MarketRepository;
using Market.Infrastructure.Repositories.ApplicationUserRepository;
using Market.Infrastructure.Repositories.ProdutCategoryRepository;

namespace Market.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public readonly IMarketRepository MarketRepository;
        public readonly IApplicationUserRepository ApplicationUserRepository;
        public readonly IProductCategoryRepository ProductCategoryRepository;

        public UnitOfWork(DatabaseContext databaseContext,
            IMarketRepository marketRepository,
            IApplicationUserRepository applicationUserRepository,
            IProductCategoryRepository productCategoryRepository
            )
        {
            _databaseContext = databaseContext;
            MarketRepository = marketRepository;
            ApplicationUserRepository = applicationUserRepository;
            ProductCategoryRepository = productCategoryRepository;
        }

        public async Task<int> Execute(Action action)
        {
            using (BeginTransaction())
            {
                try
                {
                    action();

                    var affectedRows = await SaveChangesAsync();
                    await CommitTransactionAsync();
                    return affectedRows;
                }
                catch
                {
                    await RollbackTransactionAsync();
                    throw;
                }
            }
        }

        public async Task<int> ExecuteAsync(Func<Task> action)
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    await action();

                    var affectedRows = await SaveChangesAsync();
                    await transaction.CommitAsync();
                    return affectedRows;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _databaseContext.Database.BeginTransaction();
        }

        public Task CommitTransactionAsync()
        {
            return _databaseContext.Database.CommitTransactionAsync();
        }

        public Task RollbackTransactionAsync()
        {
            return _databaseContext.Database.RollbackTransactionAsync();
        }

        public int SaveChanges()
        {
            return _databaseContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return _databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}