using ApplicationCore.Entities;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Repositories;
using CustomLibraries.Guards;
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
            Guard.AgainstNull(list, $"Can't find todo list with id: {id}");

            await _context.Entry(list!)
                .Collection(l => l.Todos)
                .LoadAsync();

            return list!.Todos;
        }

        public async Task AddTodoListAsync(TodoList todoList)
        {
            await _context.TodoLists.AddAsync(todoList);
        }

        public async Task AddTodoAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            _context.Todos.Remove(todo);
        }

        public void DeleteTodoList(TodoList todoList)
        {
            _context.TodoLists.Remove(todoList);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
        