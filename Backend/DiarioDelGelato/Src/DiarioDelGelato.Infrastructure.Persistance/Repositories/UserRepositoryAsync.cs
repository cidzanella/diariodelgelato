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
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // check if userName is available
        public async Task<User> FindByNameAsync(string userName)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName.ToLower());
            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error checking Application User exists on database - {e.Message}", e);
            }
        }
    }
}
