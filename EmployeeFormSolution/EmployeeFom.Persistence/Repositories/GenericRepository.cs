using EmployeeForm.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeForm.Domain;
using EmployeeFom.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFom.Persistence.Repositories
{
    // A generic repository that implements the IGenericRepository interface for entities of type T (Employee or derived).
    public class GenericRepository<T> : IGenericRepository<T> where T : Employee
    {
        protected readonly EmployeeDatabaseContext _context;

        // Initializes the generic repository with a database context.
        public GenericRepository(EmployeeDatabaseContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new entity of type T.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a list of entities of type T.
        /// </summary>
        /// <returns>A list of entities.</returns>
        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an entity of type T by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The requested entity or null if not found.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Updates an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
