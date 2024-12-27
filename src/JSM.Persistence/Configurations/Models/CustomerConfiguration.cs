using JSM.Domain.Models;
using JSM.Persistence.Configurations.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSM.Persistence.Configurations.Models
{
    internal class Customerfiguration : BaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Birthday)
                .IsRequired();

            builder.Property(x => x.Registered)
                .IsRequired();

            builder.Property(x => x.TelephoneNumbers)
                .IsRequired();

            builder.Property(x => x.MobileNumbers)
                .IsRequired();

            builder.Property(x => x.Nationality)
                .IsRequired();

            builder.HasOne(x => x.Location)
                .WithOne()
                .HasForeignKey<CustomerLocation>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Portrait)
                .WithOne()
                .HasForeignKey<CustomerPortrait>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
