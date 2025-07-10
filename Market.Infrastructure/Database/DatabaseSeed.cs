using Microsoft.EntityFrameworkCore;
using Market.Entities;

namespace Market.Infrastructure.Database
{
    public partial class DatabaseContext
    {
        public DateTime dateTime { get; set; } = new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc);

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedTennisAssociation(modelBuilder);
        }

        private void SeedTennisAssociation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketEntity>().HasData(new List<MarketEntity>
            {
                new MarketEntity{
                    Id = new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"),
                    Name = "Market 1",
                    Location = "Hercegovina",
                    CreatedAt = dateTime,
                    ModifiedAt = null,
                },
                new MarketEntity{
                    Id = new Guid("dddd8eaf-6d12-4d53-8315-902f50c65ae1"),
                    Name = "Market 2",
                    Location = "Bosna",
                    CreatedAt = dateTime,
                    ModifiedAt = null,
                },
            });
        }
    }
}