using College.Domain.Models;

namespace College.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>(bool hasCustomRepository = false) where T : BaseEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
