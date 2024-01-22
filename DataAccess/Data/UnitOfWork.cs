using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Repository;
using DataAccess.Repositories;

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

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
