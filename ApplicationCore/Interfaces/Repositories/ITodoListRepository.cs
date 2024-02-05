using ApplicationCore.Entities;
using ApplicationCore.Entities.Todo;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ITodoListRepository
    {
        Todo? GetTodoById(Guid id);
        TodoList? GetTodoListById(Guid id);
        IEnumerable<TodoList> GetAllTodoList();
        IEnumerable<Todo> GetAllTodo(Guid id);
        bool AddTodoList(TodoList todoList);
        bool AddTodo(Todo todo);
        bool DeleteTodoList(TodoList todoList);
        bool DeleteTodo(Todo todo);
        bool Update<T>(T entity) where T : BaseEntity;
    }
}
