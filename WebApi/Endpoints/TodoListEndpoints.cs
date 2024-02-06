using ApplicationCore.Dtos;
using ApplicationCore.Interfaces.Services;

namespace WebApi.Endpoints
{
    public static class TodoListEndpoints
    {
        private static string baseRoute = "api/todoLists";
        
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet($"{baseRoute}/get", (ITodoListServices todoListServices) => GetAllTodoLists(todoListServices));
            app.MapPost($"{baseRoute}/add", (ITodoListServices todoListServices, TodoListDto dto) => AddNewTodoList(todoListServices, dto));
            app.MapDelete($"{baseRoute}/delete", (ITodoListServices todoListServices, string id) => RemoveTodoListById(todoListServices, id));
            app.MapPut($"{baseRoute}/update/color", (ITodoListServices todoListServices, string id, string colorHex) => UpdateTodoListColor(todoListServices, id, colorHex));
        }

        private static async Task<IResult> GetAllTodoLists(ITodoListServices todoListServices)
        {
            return Results.Ok(await todoListServices.GetAllTodoListsAsync());
        }

        private static async Task<IResult> AddNewTodoList(ITodoListServices todoListServices, TodoListDto newTodoList)
        {
            bool isSuccess = await todoListServices.AddNewTodoListAsync(newTodoList);
            
            if (isSuccess)
            {
                return Results.Created();
            }
            return Results.StatusCode(500);
        }

        private static async Task<IResult> RemoveTodoListById(ITodoListServices todoListServices, string id)
        {
            bool isSuccess = await todoListServices.RemoveTodoListByIdAsync(id);

            if (isSuccess)
            {
                return Results.NoContent();
            }
            return Results.BadRequest("Operation was unsuccessful.");
        }

        private static async Task<IResult> UpdateTodoListColor(ITodoListServices todoListServices, string id, string color)
        {
            bool isSuccess = await todoListServices.UpdateTodoListColorAsync(id, color);

            if (isSuccess) 
            {
                return Results.NoContent();
            }
            return Results.BadRequest("Operation was unsuccessful.");
        }
    }
}
