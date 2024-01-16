using ApplicationCore.Entities.Todo;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITodoListRepository
    {
        /// <summary>
        /// Get a Todo by from the database using the todoId and its todoListId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Todo object or null</returns>
        /// <exception cref="EntityNotFoundException"></exception>
        Todo? GetTodoById(int todoId, int todoListId);

        /// <summary>
        /// Get a TodoList from the database using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A TodoList object or null</returns>
        TodoList? GetTodoListById(int id);

        /// <summary>
        /// Get an enumerator of all TodoLists
        /// </summary>
        /// <returns>A List<TodoList> object</returns>
        IEnumerable<TodoList> GetAllTodoList();

        /// <summary>
        /// Add a TodoList to the database
        /// </summary>
        /// <param name="todoList"></param>
        /// <returns>A boolean value representing the operation status</returns>
        bool AddTodoList(TodoList todoList);

        /// <summary>
        /// Add a Todo to a specific TodoList
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="todo"></param>
        /// <returns>A boolean value representing the operation status</returns>
        bool AddTodoToList(TodoList todoList, Todo todo);

        /// <summary>
        /// Delete a TodoList from the database
        /// </summary>
        /// <param name="listId"></param>
        /// <returns>A boolean value representing the operation status</returns>
        bool DeleteTodoList(TodoList todoList);

        /// <summary>
        /// Delete a Todo from a specific TodoList
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="todoId"></param>
        /// <returns>A boolean value representing the operation status</returns>
        bool DeleteTodoFromList(TodoList todoList, Todo todo);
    }
}
