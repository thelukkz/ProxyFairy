using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProxyFairy.Core.Model.Configuration
{
    public class LogGatewayConfiguration : IEntityTypeConfiguration<LogGateway>
    {
        public void Configure(EntityTypeBuilder<LogGateway> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedOn).HasColumnType("datetime2");
            builder.Property(x => x.UpdatedOn).HasColumnType("datetime2");

            builder.Property(x => x.AppVersion).HasMaxLength(16);
            builder.Property(x => x.BundleId).HasMaxLength(50);
            builder.Property(x => x.DeviceId).HasMaxLength(50);
            builder.Property(x => x.Level).HasMaxLength(16);
            builder.Property(x => x.Message).HasMaxLength(255);
            builder.Property(x => x.System).HasMaxLength(16);
            builder.Property(x => x.SystemVersion).HasMaxLength(32);

            builder.HasOne(x => x.MobApp).WithMany(x => x.LogGateways);

            builder.HasIndex(x => x.ContractId);
            builder.HasIndex(x => x.Level);
            builder.HasIndex(x => x.Response);
        }
    }
}
