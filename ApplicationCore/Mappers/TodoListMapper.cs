using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;

namespace ApplicationCore.Mappers
{
    public class TodoListMapper : IMapper
    {
        public TodoDto ToDto(Todo todo)
        {
            return new TodoDto() 
            { 
                 Id = todo.Id,
                 Title = todo.Title,
                 Description = todo.Description,
                 Completed = todo.Completed,
                 Important = todo.Important,
                 Priority = todo.Priority,
                 Color = todo.Color,
            };
        }

        public TodoListDto ToDto(TodoList todoList) 
        {
            List<TodoDto> todoDtoCollection = new List<TodoDto>();

            foreach (Todo todo in todoList.Todos)
            {
                todoDtoCollection.Add(ToDto(todo));
            }

            return new TodoListDto()
            {
                Id = todoList.Id,
                Title = todoList.Title,
                Color = todoList.Color,
                Todos = todoDtoCollection.AsReadOnly()
            }; 
        }

        public Todo ToEntity(TodoDto todoDto) 
        {
            return new Todo(todoDto.Title, todoDto.Description)
            {
                Priority = todoDto.Priority,
            };
        }

        public TodoList ToEntity(TodoListDto todoListDto)
        {
            return new TodoList(todoListDto.Title)
            {
                Title = todoListDto.Title,
            };
        }
    }
}
