using ApplicationCore.Entities.Todo;
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

        public Todo? GetTodoById(string id)
        {            
            Guid guid = Guid.Parse(id);
            return _context.Todo.FirstOrDefault(todo => todo.Id == guid);
        }

        public TodoList? GetTodoListById(string id)
        {
            Guid guid = Guid.Parse(id);
            return _context.TodoList.FirstOrDefault(todoList => todoList.Id == guid);
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

        public bool DeleteTodo(Todo todo)
        {
            try
            {
                _context.Todo.Remove(todo);
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
        