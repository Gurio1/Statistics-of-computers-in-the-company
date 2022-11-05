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
    internal sealed class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users", "identity");

            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Email).IsUnique();

            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired();

            builder.HasOne(c => c.Role)
                   .WithMany(c => c.ApplicationUsers);
        }
    }
}
