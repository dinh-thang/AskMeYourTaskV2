using ApplicationCore.Dtos;
using ApplicationCore.Interfaces.Services;

namespace WebApi.Endpoints
{
    public static class TodoListEndpoints
    {
        
        public static void MapEndpoints(this WebApplication app)
        {
        }

        private static IResult GetAllTodoLists(ITodoListService todoListService)
        {
            return Results.Ok(todoListService.GetAllTodoLists());
        }

        private static IResult AddNewTodoList(ITodoListService todoListService, TodoListDto newTodoList)
        {
            bool isSuccess = todoListService.AddNewTodoList(newTodoList);
            
            if (isSuccess)
            {
                return Results.Created();
            }
            return Results.StatusCode(500);
        }

        private static IResult RemoveTodoListById(ITodoListService todoListService, int id)
        {
            bool isSuccess = todoListService.RemoveTodoListById(id);

            if (isSuccess)
            {
                return Results.NoContent();
            }
            return Results.BadRequest("Operation was unsuccessful.");
        }

        private static IResult UpdateTodoListColor(ITodoListService todoListService, int id, string color)
        {
            bool isSuccess = todoListService.UpdateTodoListColor(id, color);

            if (isSuccess) 
            {
                return Results.NoContent();
            }
            return Results.BadRequest("Operation was unsuccessful.");
        }
    }
}
