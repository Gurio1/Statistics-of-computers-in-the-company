using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_46731r.Infrastructure.EntityTypeConfigurations
{
    internal sealed class ComputerEntityTypeConfiguration : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> builder)
        {
            builder.ToTable("Computers", "inventory");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.InventoryNumber).IsUnique();
            builder.HasIndex(c => c.HostName).IsUnique();

            builder.Property(c => c.InventoryNumber).ValueGeneratedNever().IsRequired();
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.HostName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Mac).HasMaxLength(50).IsRequired();

            builder.HasOne(c => c.Characteristics)
                   .WithOne()
                   .HasForeignKey<Computer>(c => c.ComputerCharacteristicsId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c =>c.CheckedOn)
                  .WithOne()
                  .HasForeignKey(c => c.ComputerId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();

            builder.HasMany(c =>c.ModifiedOn)
                  .WithOne()
                  .HasForeignKey(c => c.ComputerId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();
        }
    }
}
