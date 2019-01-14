using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProxyFairy.Core.Model.Configuration
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedOn).HasColumnType("datetime2");
            builder.Property(x => x.UpdatedOn).HasColumnType("datetime2");

            builder.Property(x => x.MobAppId).IsRequired();

            builder.Property(x => x.Month).IsRequired()
                .HasMaxLength(2);
            builder.Property(x => x.Year).IsRequired()
                .HasMaxLength(4);

            builder.Property(x => x.SlotId).IsRequired();
            builder.HasOne(x => x.Slot)
                .WithMany(p => p.Contracts);

            builder.HasIndex(x => x.MobAppId);
            builder.HasIndex(x => x.Year);
            builder.HasIndex(x => x.Month);
        }
    }
}
