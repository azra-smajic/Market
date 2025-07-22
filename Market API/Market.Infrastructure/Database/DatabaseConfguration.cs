using Microsoft.EntityFrameworkCore;
using Market.Core.Entities.BaseEntity;

namespace Market.Infrastructure.Database
{
    public partial class DatabaseContext
    {
        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }

        private void ModifyTimestamps()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = ((IBaseEntity)entry.Entity);

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.Now;
                }
            }
        }

        public override int SaveChanges()
        {
            ModifyTimestamps();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ModifyTimestamps();

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}