using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Repository;
using DataAccess.Repositories;

namespace DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            TodoList = new TodoListRepository(_context);
        }

        public ITodoListRepository TodoList { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
