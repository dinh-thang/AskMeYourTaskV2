namespace ApplicationCore.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
        public DateTime DueDate { get; set; }
        public bool Important { get; set; } = false;
        public int Priority { get; set; } = 0;
    }
}
