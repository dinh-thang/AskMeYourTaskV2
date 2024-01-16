using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoServices
    {
        /// <summary>
        /// Add a new Todo to the selected TodoList
        /// </summary>
        /// <param name="newTodo"></param>
        /// <returns>A boolean value represents the operation status</returns>
        bool AddNewTodo(int listId, TodoDto newTodo);

        /// <summary>
        /// Marks a Todo to be completed
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean value represents the operation status</returns>
        bool MarkTodoCompleted(int id, int listId);

        /// <summary>
        /// Change a Todo's important status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isImportant"></param>
        /// <returns>A boolean value represents the operation status</returns>
        bool UpdateTodoImportantStatus(int id, int listId, bool isImportant);

        /// <summary>
        /// Change a Todo's priority level in the selected TodoList
        /// </summary>
        /// <param name="id"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        bool UpdateTodoPriorityInList(int id, int listId, int priority);

    }
}
