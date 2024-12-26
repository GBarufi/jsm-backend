using JSM.Domain.Models;
using JSM.Persistence.Configurations.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSM.Persistence.Configurations.Models
{
    internal class CustomerPortraitConfiguration : BaseConfiguration<CustomerPortrait>
    {
        public override void Configure(EntityTypeBuilder<CustomerPortrait> builder)
        {
            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.Large)
                .IsRequired();

            builder.Property(x => x.Medium)
                .IsRequired();

            builder.Property(x => x.Thumbnail)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
