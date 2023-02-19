using EcommerceWebsiteDemo.Core.Entities;

namespace EcommerceWebsiteDemo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
