using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T? Get(string id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
