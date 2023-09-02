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

        public async Task<bool> GelatoExists(string Name)
        {
            return await _dbContext.Gelatos.AnyAsync(g => g.Name.ToLower() == Name.ToLower());
        }
    }
}
