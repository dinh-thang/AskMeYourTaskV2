using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoListServices
    {
        Task<IEnumerable<TodoListDto>> GetAllListsAsync();
        Task AddAsync(TodoListDto newTodoList);
        Task RemoveByIdAsync(string id);
        Task UpdateColorAsync(string id, string hexValue);
        Task UpdateTagAsync(string id, string tagTitle);
    }
}
