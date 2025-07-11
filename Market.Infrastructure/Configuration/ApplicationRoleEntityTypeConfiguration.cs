using Market.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Configurations
{
    internal class ApplicationRoleEntityTypeConfiguration : BaseEntityTypeConfiguration<ApplicationRole>
    {
        public override void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                 .Property(ar => ar.Id)
                 .ValueGeneratedNever();
        }
    }
}