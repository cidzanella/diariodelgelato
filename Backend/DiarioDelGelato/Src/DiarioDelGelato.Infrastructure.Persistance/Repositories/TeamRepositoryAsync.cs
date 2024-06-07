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
    public class TeamRepositoryAsync : GenericRepositoryAsync<TeamMember>, ITeamRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<bool> TeamMemberExistsAsync(string teamMemberFullName)
        {
            try
            {
                return await _dbContext.Team.AnyAsync(m => m.FullName == teamMemberFullName.ToLower());
            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error checking Team Member Fullname on database - {e.Message}", e);
            }
        }
    }
}
