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

TodoList list = new TodoList("list");

list.AddTodo(todo);
list.AddTodo(new Todo("todo2", "desf"));
list.AddTodo(new Todo("todo3", "fe"));


IMapper map = new Mapper();
//map.DiscardProperties(new List<string>() { "Todos" });

List<TodoDto> listDto = (List<TodoDto>)map.ToDtoList<TodoDto>(list.Todos);

TodoListDto list1 = map.ToDto<TodoListDto>(list);
list1.Todos = listDto;

TodoListDto list2 = list1;


TodoList list5 = map.ToEntity<TodoList>(list2);

foreach (Todo item in list5.Todos)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Title);
    Console.WriteLine(item.Description);
    Console.WriteLine("+++++++\n");
}

//Console.WriteLine($"dto name: {dto.Title}, desc: {dto.Description}, compl: {dto.Completed}, important: {dto.Important}, pr: {dto.Priority}, co: {dto.Color}");
//Console.WriteLine($"todo name: {todo1.Title}, desc: {todo1.Description}, compl: {todo1.Completed}, important: {todo1.Important}, pr: {todo1.Priority}, co: {todo1.Color}");