using ApplicationCore.Entities;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Repositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly AppDbContext _context;
       
        public TodoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public Todo? GetTodoById(Guid id)
        {            
            return _context.Todos.FirstOrDefault(todo => todo.Id == id);
        }

        public TodoList? GetTodoListById(Guid id)
        {
            return _context.TodoLists.FirstOrDefault(todoList => todoList.Id == id);
        }    

        public IEnumerable<TodoList> GetAllTodoList()
        {
            return _context.TodoLists.ToList();
        }

        public IEnumerable<Todo> GetAllTodo(Guid id)
        {
            TodoList? list = GetTodoListById(id);

            if (list == null) 
            {
                throw new EntityNotFoundException($"Can't find entity with id: {id.ToString()}");
            }

            _context.Entry(list)
                .Collection(l => l.Todos)
                .Load();

            return list.Todos;
        }

        public bool AddTodoList(TodoList todoList)
        {
            try
            {
                _context.TodoLists.Add(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool AddTodo(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
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
                _context.Todos.Remove(todo);
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
                _context.TodoLists.Remove(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update<T>(T entity) where T : BaseEntity
        {
            try
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception) 
            {
                return false;
            }
            return true;
        }
    }
}
        