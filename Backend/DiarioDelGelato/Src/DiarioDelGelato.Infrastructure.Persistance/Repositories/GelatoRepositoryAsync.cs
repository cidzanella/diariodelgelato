using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Infrastructure.Persistance.Contexts;
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

        public async Task<bool> GelatoExists(string name)
        {
            return await _dbContext.Gelatos.AsNoTracking().AnyAsync(g => g.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> GelatoExists(int id)
        {
            return await _dbContext.Gelatos.AsNoTracking().AnyAsync(g => g.Id == id);
        }
    }
}
