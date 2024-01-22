using ApplicationCore.Entity;

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
        public string Color { get; set; } = string.Empty;   
        public IReadOnlyCollection<Todo> Todos { get; private set; }

        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
            Todos = _todos;
        }
    }
}
