using Market.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Market.Infrastructure.Database
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<MarketEntity> Markets { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityTypeConfiguration<>).Assembly);
            SeedData(modelBuilder);
        }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Database=Market_v1;Username=postgres;Password=postgres");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}