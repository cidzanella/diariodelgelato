using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Repositories
{
    public interface IGelatoRepositoryAsync : IGenericRepositoryAsync<Gelato>
    {
        Task<bool> GelatoExistsAsync(string name);

        Task<bool> GelatoExistsAsync(int id);
    }
}
