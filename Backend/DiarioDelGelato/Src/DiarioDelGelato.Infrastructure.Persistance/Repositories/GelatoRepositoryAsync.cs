using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Repositories
{
    public class GelatoRepositoryAsync : GenericRepositoryAsync<Gelato>, IGelatoRepositoryAsync
    {
        public GelatoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
