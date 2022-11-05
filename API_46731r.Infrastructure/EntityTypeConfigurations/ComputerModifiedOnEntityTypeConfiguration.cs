using API_46731r.Domain.Entities.ComputerState;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Infrastructure.EntityTypeConfigurations
{
    internal sealed class ComputerModifiedOnEntityTypeConfiguration : IEntityTypeConfiguration<ComputerModifiedOn>
    {
        public void Configure(EntityTypeBuilder<ComputerModifiedOn> builder)
        {
            builder.ToTable("ComputersModifiedOn", "checksByStaff");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.CheckedBy)
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
