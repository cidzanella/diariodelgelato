using DiarioDelGelato.Application.Interfaces.Repositories;
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
    // implements using EF 
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error reading data from {nameof(T)} - {e.Message}", e);
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error reading data from {nameof(T)} - {e.Message}", e);
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);

                int writtenEntriesCount = await _dbContext.SaveChangesAsync();

                return writtenEntriesCount > 0 ? entity : null;

            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error adding record to {nameof(T)} - {e.Message}", e);
            }
        }
        
        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error updating data to {nameof(T)} - {e.Message}", e);
            }        
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new RepositoryException($"Error removing record from {nameof(T)} - {e.Message}", e);
            }        
        }

    }
}
