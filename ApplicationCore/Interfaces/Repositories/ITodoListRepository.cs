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
        Task AddTodoListAsync(TodoList todoList);
        Task AddTodoAsync(Todo todo);
        void DeleteTodoList(TodoList todoList);
        void DeleteTodo(Todo todo);
        void Update<T>(T entity) where T : BaseEntity;
    }
}
