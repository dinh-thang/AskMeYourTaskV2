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

        public Todo? FindTodoById(string id) 
        {
            Guid guid = Guid.Parse(id);
            return _todos.FirstOrDefault(todo => todo.Id == guid);
        }

        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
            Todos = _todos;
        }

        public void RemoveCompletedTodo(string id)
        {
            Guid guid = Guid.Parse(id);
            var completedTodo = _todos.Where(todo => todo.Id == guid).FirstOrDefault();

            if (completedTodo == null) 
            {
                return;
            }

            _todos.Remove(completedTodo);
        }
    }
}
