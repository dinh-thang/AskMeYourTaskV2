using ApplicationCore.Entities.Todo;
using ApplicationCore.Entity;

namespace ApplicationCore.Interfaces.Repository
{
    public interface ITodoListRepository
    {
        /// <summary>
        /// Get a todo using its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Todo object or null if not found</returns>
        Todo? GetTodoById(string id);

        /// <summary>
        /// Get a todo list using its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A TodoList object or null if not found</returns>
        TodoList? GetTodoListById(string id);

        /// <summary>
        /// Get an enumerator of a collection containing all todo lists
        /// </summary>
        /// <returns>An Enumerable of type TodoList</returns>
        IEnumerable<TodoList> GetAllTodoList();

        /// <summary>
        /// Get an enumerator of a collection containing all todos of a todo list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Enumerable of type Todo</returns>
        IEnumerable<Todo> GetAllTodo(string id);

        /// <summary>
        /// Add new todo list to the database
        /// </summary>
        /// <param name="todoList"></param>
        /// <returns>A boolean value indicate if the operation is successful.</returns>
        bool AddTodoList(TodoList todoList);

        /// <summary>
        /// Add new todo to the database
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>A boolean value indicate if the operation is successful.</returns>
        bool AddTodo(Todo todo);

        /// <summary>
        /// Remove a todo list from the database
        /// </summary>
        /// <param name="todoList"></param>
        /// <returns>A boolean value indicate if the operation is successful.</returns>
        bool DeleteTodoList(TodoList todoList);

        /// <summary>
        /// Remove a todo from the database
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>A boolean value indicate if the operation is successful.</returns>
        bool DeleteTodo(Todo todo);

        /// <summary>
        /// Start tracking and modify the given entity state 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update<T>(T entity) where T : BaseEntity;
    }
}
