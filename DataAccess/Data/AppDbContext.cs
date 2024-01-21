using ApplicationCore.Entities.Todo;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<Todo> Todo { get; set; }
    }
}
