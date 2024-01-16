using ApplicationCore.Dtos;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;

namespace ApplicationCore.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TodoListDto> GetAllTodoLists()
        {
            throw new NotImplementedException();
        }

        public bool AddNewTodoList(TodoListDto newTodoList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTodoListColor(int id, Color color)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTodoListById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
