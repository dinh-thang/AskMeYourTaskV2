using ApplicationCore.Enums;

namespace ApplicationCore.Dtos
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Color Color { get; set; }
        public IReadOnlyCollection<TodoDto> Todos { get; set; } = null!;
    }
}
