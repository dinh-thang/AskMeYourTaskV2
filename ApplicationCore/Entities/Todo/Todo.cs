using ApplicationCore.Entity;

namespace ApplicationCore.Entities.Todo
{
    public class Todo : BaseEntity
    {
        public Todo(string title, string desc)
        {
            Title = title;
            Description = desc;
            DateCreated = DateTime.Today;
        }

        public Todo() 
        {
        }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public bool Important { get; set; } = false;
        public bool Completed { get; private set; } = false;
        public DateTime DateCreated { get; private set; } = DateTime.Now;
        public int Priority { get; set; } = 0;

        public Guid TodoListId { get; set; }
        public TodoList TodoList { get; set; } = null!;

        public void MarkCompleted()
        {
            Completed = true;
        }
    }
}
