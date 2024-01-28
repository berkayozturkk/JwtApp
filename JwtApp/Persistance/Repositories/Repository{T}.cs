using JwtApp.Core.Application.Interfaces;
using JwtApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtApp.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext _context;

        public Repository(JwtContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);

            if(data is null) 
                throw new ArgumentNullException(nameof(data));

            return data;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            return data;
        }

        public async Task RemoveAsync(T entity)
        {
             _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
