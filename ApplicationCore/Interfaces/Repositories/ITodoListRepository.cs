using ApplicationCore.Entities;
using ApplicationCore.Entities.Todo;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ITodoListRepository
    {
        Task<Todo?> GetTodoByIdAsync(Guid id);
        Task<TodoList?> GetTodoListByIdAsync(Guid id);
        Task<IEnumerable<TodoList>> GetAllTodoListAsync();
        Task<IEnumerable<Todo>> GetAllTodoAsync(Guid id);
        Task<bool> AddTodoListAsync(TodoList todoList);
        Task<bool> AddTodoAsync(Todo todo);
        bool DeleteTodoList(TodoList todoList);
        bool DeleteTodo(Todo todo);
        bool Update<T>(T entity) where T : BaseEntity;
    }
}
