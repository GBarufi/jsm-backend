using JSM.Domain.Models;
using JSM.Persistence.Configurations.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSM.Persistence.Configurations.Models
{
    internal class UserPortraitConfiguration : BaseConfiguration<UserPortrait>
    {
        public override void Configure(EntityTypeBuilder<UserPortrait> builder)
        {
            builder.Property(x => x.UserId)
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
