using ApplicationCore.Entities.Todo;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Repository;
using DataAccess.Data;

namespace DataAccess.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly AppDbContext _context;

        public TodoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public Todo? GetTodoById(int todoId, int todoListId)
        {
            var todoList = GetTodoListById(todoListId);
            
            if (todoList == null) 
            {
                throw new EntityNotFoundException($"TodoList entity with an id of {todoListId} was not found.");
            }
            return todoList.FindTodoById(todoId);
        }

        public TodoList? GetTodoListById(int id)
        {
            return _context.TodoList.FirstOrDefault(todoList => todoList.Id == id);
        }    

        public IEnumerable<TodoList> GetAllTodoList()
        {
            return _context.TodoList.ToList();
        }

        public bool AddTodoList(TodoList todoList)
        {
            try
            {
                _context.TodoList.Add(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool AddTodoToList(TodoList todoList, Todo todo)
        {
            try
            {
                todoList.AddTodo(todo);
            }
            catch (Exception)
            {
                return false;
            }
            return  true;
        }

        public bool DeleteTodoFromList(TodoList todoList, Todo todo)
        {
            try
            {
                todoList.RemoveCompletedTodo(todo.Id);
            }
            catch (Exception) 
            {
                return false;
            }
            return true;
        }

        public bool DeleteTodoList(TodoList todoList)
        {
            try
            {
                _context.TodoList.Remove(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
        