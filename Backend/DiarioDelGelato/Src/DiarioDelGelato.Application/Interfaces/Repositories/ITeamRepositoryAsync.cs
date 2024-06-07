using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Repositories
{
    public interface ITeamRepositoryAsync : IGenericRepositoryAsync<TeamMember>
    {
        Task<bool> TeamMemberExistsAsync(string teamMemberFullName);
    }
}
