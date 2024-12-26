using JSM.Domain.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JSM.Persistence.Configurations.Models.Base
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
