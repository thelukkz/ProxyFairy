using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProxyFairy.Core.Model.Configuration
{
    public class MobAppConfiguration : IEntityTypeConfiguration<MobApp>
    {
        public void Configure(EntityTypeBuilder<MobApp> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedOn).HasColumnType("datetime2");
            builder.Property(x => x.UpdatedOn).HasColumnType("datetime2");

            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.AppBundle).HasMaxLength(50);

            builder.Property(x => x.CustomerId).IsRequired();
            builder.HasOne(x => x.Customer)
                .WithMany(p => p.MobApps);

            builder.Property(x => x.Platform).IsRequired();
            builder.Property(x => x.AppBundle).IsRequired();

            builder.HasIndex(x => x.AppBundle);
            builder.HasIndex(x => x.Platform);
        }
    }
}
