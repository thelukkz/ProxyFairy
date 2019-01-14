using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProxyFairy.Core.Model.Configuration
{
    public class AppParameterConfiguration : IEntityTypeConfiguration<AppParameter>
    {
        public void Configure(EntityTypeBuilder<AppParameter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedOn).HasColumnType("datetime2");
            builder.Property(x => x.UpdatedOn).HasColumnType("datetime2");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
