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
            try
            {
                await todoListServices.AddNewTodoListAsync(newTodoList);
                return Results.Created();
            }
            catch (Exception)
            {
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> RemoveTodoListById(ITodoListServices todoListServices, string id)
        {
            try
            {
                await todoListServices.RemoveTodoListByIdAsync(id);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest($"Operation was unsuccessful. {e.Message}");
            }
        }

        private static async Task<IResult> UpdateTodoListColor(ITodoListServices todoListServices, string id, string color)
        {
            try
            {
                await todoListServices.UpdateTodoListColorAsync(id, color);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest($"Operation was unsuccessful. {e.Message}");
            }
        }
    }
}
