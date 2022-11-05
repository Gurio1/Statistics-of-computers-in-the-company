using API_46731r.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_46731r.Infrastructure.EntityTypeConfigurations
{
    internal sealed class ComputerCharacteristicsEntityTypeConfiguration : IEntityTypeConfiguration<ComputerCharacteristics>
    {
        public void Configure(EntityTypeBuilder<ComputerCharacteristics> builder)
        {
            builder.ToTable("ComputerCharacteristics", "inventory");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.MotherBoard).HasMaxLength(50);
            builder.Property(c => c.Processor).HasMaxLength(50);
        }
    }
}
