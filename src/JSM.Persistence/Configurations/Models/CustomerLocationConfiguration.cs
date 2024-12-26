using JSM.Domain.Models;
using JSM.Persistence.Configurations.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSM.Persistence.Configurations.Models
{
    internal class CustomerLocationConfiguration : BaseConfiguration<CustomerLocation>
    {
        public override void Configure(EntityTypeBuilder<CustomerLocation> builder)
        {
            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.Region)
                .IsRequired();

            builder.Property(x => x.Street)
                .IsRequired();

            builder.Property(x => x.City)
                .IsRequired();

            builder.Property(x => x.State)
                .IsRequired();

            builder.Property(x => x.PostCode)
                .IsRequired();

            builder.Property(x => x.Latitude)
                .IsRequired();

            builder.Property(x => x.Longitude)
                .IsRequired();

            builder.Property(x => x.TimezoneOffset)
                .IsRequired();

            builder.Property(x => x.TimezoneDescription)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
