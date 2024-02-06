using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoServices
    {
        Task<bool> AddNewTodoAsync(string listId, TodoDto newTodo);
        Task<bool> MarkTodoCompletedAsync(string id);
        Task<bool> UpdateTodoImportantStatusAsync(string id, bool isImportant);
        Task<bool> UpdateTodoPriorityInListAsync(string id, int priority);

    }
}
