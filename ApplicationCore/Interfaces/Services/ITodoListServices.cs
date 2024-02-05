using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoListServices
    {
        IEnumerable<TodoListDto> GetAllTodoLists();
        bool AddNewTodoList(TodoListDto newTodoList);
        bool RemoveTodoListById(string id);
        bool UpdateTodoListColor(string id, string hexValue);
    }
}
