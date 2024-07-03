using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Repositories
{
    public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
    {
        Task<User> FindByNameAsync(string userName);
    }
}
