using API_46731r.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Infrastructure.EntityTypeConfigurations
{
    internal sealed class ApplicationRoleEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles", "identity");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        }
    }
}
