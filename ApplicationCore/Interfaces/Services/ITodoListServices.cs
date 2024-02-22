using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoListServices
    {
        Task<IEnumerable<TodoListDto>> GetAllTodoListsAsync();
        Task AddNewTodoListAsync(TodoListDto newTodoList);
        Task RemoveTodoListByIdAsync(string id);
        Task UpdateTodoListColorAsync(string id, string hexValue);
    }
}
