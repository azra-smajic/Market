using Microsoft.EntityFrameworkCore;
using Market.Entities;
using Market.Core.Entities.Identity;
using System.Data;
using System.Xml.Linq;
using Market.Core.Entities;

namespace Market.Infrastructure.Database
{
    public partial class DatabaseContext
    {
        public DateTime dateTime { get; set; } = new DateTime(2025, 4, 13, 1, 22, 18, 866, DateTimeKind.Utc);

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedMarkets(modelBuilder);
            SeedRoles(modelBuilder);
            SeedApplicationUsers(modelBuilder);
            SeedPerons(modelBuilder);
            SeedApplicationUserRoles(modelBuilder);
            SeedProductCategories(modelBuilder);
        }

        private void SeedMarkets(ModelBuilder modelBuilder)
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

        private void SeedProductCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>
            {
                new ProductCategory{
                    Id = new Guid("07c3ed5a-b793-47e2-a692-aad7a32fa0f6"),
                    Name = "Računar",
                    MarketId = new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"),
                    CreatedAt = dateTime,
                    ModifiedAt = null,
                },
                new ProductCategory{
                    Id = new Guid("d72c9db6-8a88-4247-a22d-e24d2509e457"),
                    Name = "Telefon",
                    MarketId = new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4"),
                    CreatedAt = dateTime,
                    ModifiedAt = null,
                },
            });
        }

        private void SeedApplicationUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = new Guid("1a3d9445-b3bb-45af-923e-6c9a60897a4c"),
                    UserName = "su.admin@gmail.ba",
                    NormalizedUserName = "SU.ADMIN@GMAIL.BA",
                    Email = "su.admin@gmail.ba",
                    NormalizedEmail = "SU.ADMIN@GMAIL.BA",
                    EmailConfirmed = true,
                    ConcurrencyStamp = "9547f983-1707-49d3-9390-5ec84ec35dca",
                    PasswordHash = "AQAAAAIAAYagAAAAEDVUQ30YB5tOClcClcXQ7w8G7NyIXwX7ZkjOzVxN4pjHu8/ixuLSExS7Oqd7f+fosg==",//Test1234*
                    CreatedAt = dateTime,
                },
                 new ApplicationUser
                {
                    Id = new Guid("bd355245-000f-48cf-bfdb-46d26d637320"),
                    UserName = "market1.admin@gmail.ba",
                    NormalizedUserName = "MARKET1.ADMIN@GMAIL.BA",
                    Email = "market1.admin@gmail.ba",
                    NormalizedEmail = "MARKET1.ADMIN@GMAIL.BA",
                    EmailConfirmed = true,
                    ConcurrencyStamp = "9547f983-1707-49d3-9390-5ec84ec35dca",
                    PasswordHash = "AQAAAAIAAYagAAAAEDVUQ30YB5tOClcClcXQ7w8G7NyIXwX7ZkjOzVxN4pjHu8/ixuLSExS7Oqd7f+fosg==",//Test1234*
                    CreatedAt = dateTime,
                },
            });
        }

        private void SeedPerons(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                 new Person
                 {
                    Id = new Guid("ccb8f1e2-3d37-4d5c-a0b2-7e1b9969e15c"),
                    ApplicationUserId = new Guid("1a3d9445-b3bb-45af-923e-6c9a60897a4c"),
                    FirstName = "Site",
                    Address = "Mostar 19",
                    LastName = "Administrator",
                    Gender = "M",
                    CreatedAt = dateTime
                 },
                 new Person
                 {
                    Id = new Guid("80093a80-1e48-4a10-b6ae-c72a2d6e7c81"),
                    ApplicationUserId =  new Guid("bd355245-000f-48cf-bfdb-46d26d637320"),
                    FirstName = "Azra",
                    Address = "Mostar 19",
                    LastName = "Smajic",
                    Gender = "F",
                    CreatedAt = dateTime,
                    MarketId = new Guid("c2f491f6-6789-4f28-b5aa-3fbbd9e3bfb4")
                 }
             });
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
              new ApplicationRole
              {
                  Id = new Guid("21c96647-83d8-4ec2-a755-a9f486f81411"),
                  Name = "Site Administrator",
                  NormalizedName = "Site Administrator".ToString().ToUpper(),
                  ConcurrencyStamp = $"547f983-1707-49d3-9390-5ec84ec35dca",
                  CreatedAt = dateTime
              },
              new ApplicationRole
              {
                  Id = new Guid("894f6287-bb05-455e-839e-b9674a9f367c"),
                  Name = "Company Owner",
                  NormalizedName = "Company Owner".ToString().ToUpper(),
                  ConcurrencyStamp = $"547f983-1707-49d3-9390-5ec84ec35dca",
                  CreatedAt = dateTime
              },
               new ApplicationRole
               {
                   Id = new Guid("32dfcd38-4975-4127-b0bd-ec12a64cf27f"),
                   Name = "Client",
                   NormalizedName = "Client".ToString().ToUpper(),
                   ConcurrencyStamp = $"547f983-1707-49d3-9390-5ec84ec35dca",
                   CreatedAt = dateTime
               }
              );
        }

        private void SeedApplicationUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>().HasData(new List<ApplicationUserRole>
            {
                new ApplicationUserRole
                {
                    Id = new Guid("f0dfa8ba-5f6d-41fe-b06d-413bb8b16e06"),
                    UserId = new Guid("1a3d9445-b3bb-45af-923e-6c9a60897a4c"),
                    RoleId = new Guid("21c96647-83d8-4ec2-a755-a9f486f81411"),
                    CreatedAt = dateTime
                },
                 new ApplicationUserRole
                {
                    Id = new Guid("699d3d05-e038-49bf-8c54-0509372a6e6c"),
                    UserId = new Guid("bd355245-000f-48cf-bfdb-46d26d637320"),
                    RoleId = new Guid("894f6287-bb05-455e-839e-b9674a9f367c"),
                    CreatedAt = dateTime
                },
            });
        }
    }
}