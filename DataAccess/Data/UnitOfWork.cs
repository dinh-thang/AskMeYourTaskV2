using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Repository;

namespace DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, ITodoListRepository todoListRepository)
        {
            _context = context;
            TodoList = todoListRepository;
        }

        public ITodoListRepository TodoList { get; }

        public void Update(object entity)
        {
            _context.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
