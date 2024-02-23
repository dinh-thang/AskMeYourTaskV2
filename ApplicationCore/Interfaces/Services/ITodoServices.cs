using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoServices
    {
        Task AddNewTodoAsync(string listId, TodoDto newTodo);
        Task MarkTodoCompletedAsync(string id);
        Task UpdateTodoImportantStatusAsync(string id, bool isImportant);
        Task UpdateTodoPriorityInListAsync(string id, int priority);
        Task UpdateTodoDueDateAsync(string id, DateTime dueDate);
        Task DeleteTodoAsync(string id);
    }
}
