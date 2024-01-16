// See https://aka.ms/new-console-template for more information
using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Mappers;

Console.WriteLine("Hello, World!");

Todo todo = new Todo("wejfygew", "descr")
{
    Important = true,
    Priority = 1,
};

TodoList list = new TodoList("list")
{
    Todos = new List<Todo>() { todo }
};


IMapper map = new Mapper();

TodoDto dto = map.ToDto<TodoDto>(todo);
Todo todo1 = map.ToEntity<Todo>(dto);

Console.WriteLine($"dto name: {dto.Title}, desc: {dto.Description}, compl: {dto.Completed}, important: {dto.Important}, pr: {dto.Priority}, co: {dto.Color}");
Console.WriteLine($"todo name: {todo1.Title}, desc: {todo1.Description}, compl: {todo1.Completed}, important: {todo1.Important}, pr: {todo1.Priority}, co: {todo1.Color}");