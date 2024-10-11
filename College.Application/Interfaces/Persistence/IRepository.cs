using College.Domain.Models;
using System.Linq.Expressions;

namespace College.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : BaseEntity
    {
        ValueTask<T> FindAsync(params object[] keyValues);

        Task<List<T>> GetAllAsync();

        IEnumerable<T> GetAllEntitiesAsync();

        Task<T> GetById(int id);

        Task AddAsync(T entity);

        void Update(T entity);

        Task Delete(int id);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        // Nuevo método para buscar una entidad con un predicado
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
