namespace ApplicationCore.Entities.Todo
{
    public class TodoList : BaseEntity
    {
        private List<Todo> _todos;
        private string _tag;

        public TodoList()
        {
            _todos = new List<Todo>();
            Todos = _todos;
            _tag = string.Empty;
        }

        public TodoList(string title)
        {
            _todos = new List<Todo>();
            Todos = _todos.AsReadOnly();

            Title = title;
            _tag = string.Empty;
        }

        public string Title { get; set; } = string.Empty;
        public string Color { get; private set; } = string.Empty;
        public ICollection<Todo> Todos { get; set; }

        public string Tag
        {
            get => _tag;
            set => value.ToLower();
        }

        public void SetColor(string hexValue)
        {
            // TODO: add hex format guard
            Color = hexValue;
        }
    }
}
