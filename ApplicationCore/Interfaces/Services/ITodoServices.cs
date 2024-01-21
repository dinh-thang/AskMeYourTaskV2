using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoServices
    {
        bool AddNewTodo(string listId, TodoDto newTodo);

        bool MarkTodoCompleted(string id);

        bool UpdateTodoImportantStatus(string id, bool isImportant);

        bool UpdateTodoPriorityInList(string id, int priority);

    }
}
