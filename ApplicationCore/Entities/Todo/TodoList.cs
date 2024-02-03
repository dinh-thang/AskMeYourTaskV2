using ApplicationCore.Entity;

namespace ApplicationCore.Entities.Todo
{
    public class TodoList : BaseEntity
    {
        private List<Todo> _todos;

        public TodoList()
        {
            _todos = new List<Todo>();
            Todos = _todos;
        }

        public TodoList(string title)
        {
            _todos = new List<Todo>();
            Todos = _todos.AsReadOnly();

            Title = title;
        }

        public string Title { get; set; } = string.Empty;
        public string Color { get; private set; } = string.Empty;
        public ICollection<Todo> Todos { get; set; }

        public void SetColor(string hexValue)
        {


            Color = hexValue;
        }
    }
}
