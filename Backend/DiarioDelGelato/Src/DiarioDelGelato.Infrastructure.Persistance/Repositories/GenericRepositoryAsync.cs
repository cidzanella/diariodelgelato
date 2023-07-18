using DiarioDelGelato.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Persistance.Repositories
{
    // implements using EF 
    internal class GenericRepositoryAsync : IGenericRepositoryAsync<T> where T : class
    {

    }
}
