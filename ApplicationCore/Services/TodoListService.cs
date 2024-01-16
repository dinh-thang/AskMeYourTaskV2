using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Mappers;

namespace ApplicationCore.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<TodoListDto> GetAllTodoLists()
        {
            List<TodoListDto> resultList = new List<TodoListDto>();

            foreach (TodoList list in _unitOfWork.TodoList.GetAllTodoList())
            {
                resultList.Add(_mapper.ToDto<TodoListDto>(list));
            }
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
