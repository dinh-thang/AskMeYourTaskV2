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
            try
            {
                await todoServices.AddNewTodoAsync(listId, dto);
                return Results.Ok(dto);
            }
            catch (Exception e)
            {
                return Results.BadRequest($"Operation was unsuccessful. {e.Message}");
            }
        }

        private static async Task<IResult> MarkTodoCompleted(ITodoServices todoServices, string id)
        {
            try
            {
                await todoServices.MarkTodoCompletedAsync(id);
                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest($"Operation was unsuccessful. {e.Message}");
            }
        }

        private static async Task<IResult> UpdateTodoImportantStatus(ITodoServices todoServices, string id, bool isImportant)
        {
            try
            {
                await todoServices.UpdateTodoImportantStatusAsync(id, isImportant);
                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest($"Operation was unsuccessful. {e.Message}");
            }
        }
        
        private static async Task<IResult> UpdateTodoPriority(ITodoServices todoServices, string id, int priority)
        {
            try
            {
                await todoServices.UpdateTodoPriorityInListAsync(id, priority);
                return Results.Ok();
            }
            catch (Exception e) 
            {
                return Results.BadRequest($"Operation was unsuccessful. {e.Message}");
            }
        }
    }
}
