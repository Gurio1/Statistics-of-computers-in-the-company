using API_46731r.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Infrastructure.EntityTypeConfigurations
{
    internal sealed class ComputerCommentsEntityTypeConfiguration : IEntityTypeConfiguration<ComputerComments>
    {
        public void Configure(EntityTypeBuilder<ComputerComments> builder)
        {
            builder.ToTable("Comments", "additionals");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Content).IsRequired();

            builder.HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId);

            builder.HasOne(c => c.Computer)
                   .WithMany(c => c.ComputerComments)
                   .HasForeignKey(c => c.ComputerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
