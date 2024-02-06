using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoListServices
    {
        Task<IEnumerable<TodoListDto>> GetAllTodoListsAsync();
        Task<bool> AddNewTodoListAsync(TodoListDto newTodoList);
        Task<bool> RemoveTodoListByIdAsync(string id);
        Task<bool> UpdateTodoListColorAsync(string id, string hexValue);
    }
}
