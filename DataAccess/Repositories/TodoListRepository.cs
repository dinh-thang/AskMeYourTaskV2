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

        public async Task<Todo?> GetTodoByIdAsync(Guid id)
        {            
            return await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
        }

        public async Task<TodoList?> GetTodoListByIdAsync(Guid id)
        {
            return await _context.TodoLists.FirstOrDefaultAsync(todoList => todoList.Id == id);
        }    

        public async Task<IEnumerable<TodoList>> GetAllTodoListAsync()
        {
            return await _context.TodoLists.ToListAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllTodoAsync(Guid id)
        {
            TodoList? list = await GetTodoListByIdAsync(id);

            if (list == null) 
            {
                throw new EntityNotFoundException($"Can't find entity with id: {id.ToString()}");
            }

            await _context.Entry(list)
                .Collection(l => l.Todos)
                .LoadAsync();

            return list.Todos;
        }

        public async Task<bool> AddTodoListAsync(TodoList todoList)
        {
            try
            {
                await _context.TodoLists.AddAsync(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddTodoAsync(Todo todo)
        {
            try
            {
                await _context.Todos.AddAsync(todo);
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
        