using Market.Core.Entities;
using Market.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Configurations
{
    internal class ApplicationUserEntityTypeConfiguration : BaseEntityTypeConfiguration<ApplicationUser>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                  .Property(au => au.Id);
            builder
                .HasOne(au => au.Person)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey<Person>(x => x.ApplicationUserId).IsRequired();
        }
    }
}