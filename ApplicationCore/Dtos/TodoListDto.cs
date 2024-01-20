
namespace ApplicationCore.Dtos
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public List<TodoDto>? Todos { get; set; }
    }
}
