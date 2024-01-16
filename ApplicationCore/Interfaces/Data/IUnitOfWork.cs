using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Repository;

namespace ApplicationCore.Interfaces.Data
{
    public interface IUnitOfWork
    {
        public ITodoListRepository TodoList { get; set; }
        void Commit();
    }
}
