using ApplicationCore.Entity;
using ApplicationCore.Enums;

namespace ApplicationCore.Entities.Todo
{
    public class TodoList : BaseEntity
    {
        private List<Todo> _todos;

        public TodoList()
        {
            _todos = new List<Todo>();
            Todos = _todos.AsReadOnly();
        }

        public TodoList(string title)
        {
            _todos = new List<Todo>();
            Todos = _todos.AsReadOnly();

            Title = title;
        }

        public string Title { get; set; } = string.Empty;
        public Color Color { get; set; } = 0;
        public IReadOnlyCollection<Todo> Todos { get; private set; }

        public Todo? FindTodoById(int id) 
        {
            return _todos.FirstOrDefault(todo => todo.Id == id);
        }

        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
            Todos = _todos;
        }

        public void RemoveCompletedTodo(int id)
        {
            var completedTodo = _todos.Where(todo => todo.Id == id).FirstOrDefault();

            if (completedTodo == null) 
            {
                return;
            }

            _todos.Remove(completedTodo);
        }
    }
}
