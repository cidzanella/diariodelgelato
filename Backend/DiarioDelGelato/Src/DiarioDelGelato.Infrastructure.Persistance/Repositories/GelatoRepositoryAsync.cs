using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using DiarioDelGelato.Infrastructure.Persistance.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Repositories
{
    public class GelatoRepositoryAsync : GenericRepositoryAsync<Gelato>, IGelatoRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public GelatoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> GelatoExistsAsync(string name)
        {
            try
            {
                return await _dbContext.Gelatos.AsNoTracking().AnyAsync(g => g.Name.ToLower() == name.ToLower());
            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error checking Gelato exists on database - {e.Message}", e);
            }
        }

        public async Task<bool> GelatoExistsAsync(int id)
        {
            try
            {
                return await _dbContext.Gelatos.AsNoTracking().AnyAsync(g => g.Id == id);

            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error checking Gelato exists on database - {e.Message}", e);
            }   
        }
    }
}
