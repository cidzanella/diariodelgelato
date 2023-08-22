using DiarioDelGelato.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        {
        }

        public DbSet<Gelato> Gelatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Gelatos
            modelBuilder.Entity<Gelato>()
                .HasData(
                    new Gelato { Name= "Fragola", Description= "morango - 0% lactose - 0% gordura" }
                );
        }
    }
}
