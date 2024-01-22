using ApplicationCore.Interfaces.Repository;

namespace ApplicationCore.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public ITodoListRepository TodoList { get; }
        void Commit();
    }
}
