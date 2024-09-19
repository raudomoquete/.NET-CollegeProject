using Microsoft.EntityFrameworkCore;
using College.Application.Interfaces.Persistence;
using College.Domain.Models;

namespace College.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

        public ValueTask<T> FindAsync(params object[] keyValues)
        {
            return _entities.FindAsync(keyValues);
        }

        public IEnumerable<T> GetAllEntitiesAsync()
        {
            return _entities.AsEnumerable();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
