using ApplicationCore.Interfaces.Repository;

namespace ApplicationCore.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public ITodoListRepository TodoListsRepository { get; }

        void Save();
    }
}
