using DiarioDelGelato.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Configurations
{
    public class GelatosConfiguration : IEntityTypeConfiguration<Gelato>
    {
        public void Configure(EntityTypeBuilder<Gelato> builder)
        {
            builder.ToTable("Gelatos");

            // since Gelato entity will not have annotations to avoid tie Domain layer to Infrastructure all the database configuration will be handle here
            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.Description)
                .HasMaxLength(100);
        }
    }
}