using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITodoListService
    {
        /// <summary>
        /// Get all TodoLists from the database
        /// </summary>
        /// <returns>IEnumerable list of TodoListDto</returns>
        IEnumerable<TodoListDto> GetAllTodoLists();

        /// <summary>
        /// Add a new TodoList to the database
        /// </summary>
        /// <param name="newTodoList"></param>
        /// <returns>A boolean value represents the operation status</returns>
        bool AddNewTodoList(TodoListDto newTodoList);

        /// <summary>
        /// Remove a TodoList from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean value represents the operation status</returns>
        bool RemoveTodoListById(int id);

        /// <summary>
        /// Modify a selected TodoList's color. This operation will also set the color of the Todos belong to that list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns>A boolean value represents the operation status</returns>
        bool UpdateTodoListColor(int id, string hexValue);
    }
}
