using ApplicationCore.Dtos;
using ApplicationCore.Interfaces.Services;

namespace WebApi.Endpoints
{
    public static class TodoEndpoints
    {
        private static string baseRoute = "api/todos";

        public static void MapEndpoints(this WebApplication app)
        {
            app.MapPost($"{baseRoute}/add", (ITodoServices todoServices, string listId, TodoDto dto) => AddNewTodo(todoServices, listId, dto));

            app.MapPut($"{baseRoute}/update/complete", (ITodoServices todoServices, string id) => MarkTodoCompleted(todoServices, id));
            app.MapPut($"{baseRoute}/update/important", (ITodoServices todoServices, string id, bool isImportant) => UpdateTodoImportantStatus(todoServices, id, isImportant));
            app.MapPut($"{baseRoute}/update/priority", (ITodoServices todoServices, string id, int priority) => UpdateTodoPriority(todoServices, id, priority)); 
        }

        private static async Task<IResult> AddNewTodo(ITodoServices todoServices, string listId, TodoDto dto)
        {
            bool isSuccessful = await todoServices.AddNewTodoAsync(listId, dto);
            
            if (!isSuccessful) 
            {
                return Results.BadRequest();
            }
            return Results.Ok(dto);
        }

        private static async Task<IResult> MarkTodoCompleted(ITodoServices todoServices, string id) 
        {
            bool isSuccessful = await todoServices.MarkTodoCompletedAsync(id);

            if (!isSuccessful)
            {
                return Results.BadRequest();
            }
            return Results.Ok();
        }

        private static async Task<IResult> UpdateTodoImportantStatus(ITodoServices todoServices, string id, bool isImportant)
        {
            bool isSuccessful = await todoServices.UpdateTodoImportantStatusAsync(id, isImportant);

            if (!isSuccessful)
            {
                return Results.BadRequest();
            }
            return Results.Ok();
        }
        
        private static async Task<IResult> UpdateTodoPriority(ITodoServices todoServices, string id, int priority) 
        {
            bool isSuccessful = await todoServices.UpdateTodoPriorityInListAsync(id, priority);

            if (!isSuccessful)
            {
                return Results.BadRequest();
            }
            return Results.Ok();
        }
    }
}
