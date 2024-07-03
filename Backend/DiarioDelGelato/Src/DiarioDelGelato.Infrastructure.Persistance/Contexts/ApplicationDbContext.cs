using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Gelato> Gelatos { get; set; }

        public DbSet<ConoDelGiorno> ConoDelGiornoJournal { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<TeamMember> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // check Configurations folder for entity configuration class, such as GelatoConfiguration

            // apply configuration for specific model entity
            //modelBuilder.ApplyConfiguration(new GelatoConfiguration());

            // apply configuration for all model entities on the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
