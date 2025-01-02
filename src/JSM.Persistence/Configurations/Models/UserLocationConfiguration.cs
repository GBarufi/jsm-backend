using JSM.Domain.Models;
using JSM.Persistence.Configurations.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSM.Persistence.Configurations.Models
{
    internal class UserLocationConfiguration : BaseConfiguration<UserLocation>
    {
        public override void Configure(EntityTypeBuilder<UserLocation> builder)
        {
            builder.Property(x => x.UserId)
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
