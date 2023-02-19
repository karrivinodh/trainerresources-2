using EcommerceWebsite.Core.Entities;
using EcommerceWebsite.Core.Utilities;
using System.Linq.Expressions;
using System.Security.Principal;

namespace EcommerceWebsite.Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        abstract T Get(Expression<Func<T, bool>> filter);
        abstract List<T> GetList(Expression<Func<T, bool>> filter = null);
        bool SaveDb(T entity, CreateReason reason = CreateReason.Create);
        bool SaveAll();
    }
}
