using Market.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Configurations
{
    internal class PersonEntityTypeConfiguration : BaseEntityTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                   .Ignore(p => p.Id);
            builder
                .HasKey(x => x.ApplicationUserId);
        }
    }
}