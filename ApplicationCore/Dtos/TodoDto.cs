
namespace ApplicationCore.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public bool Important { get; set; }
        public int Priority { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
