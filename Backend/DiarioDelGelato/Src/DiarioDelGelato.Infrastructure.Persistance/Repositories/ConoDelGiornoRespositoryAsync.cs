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
    public class ConoDelGiornoRespositoryAsync : GenericRepositoryAsync<ConoDelGiorno>, IConoDelGiornoRepositoryAsync
    {

        public ConoDelGiornoRespositoryAsync(ApplicationDbContext dbContext) : base(dbContext) { }  
    }
}
