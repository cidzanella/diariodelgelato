using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");


            builder.Property(t => t.Id)
                .IsRequired()
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
