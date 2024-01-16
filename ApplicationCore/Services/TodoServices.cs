using ApplicationCore.Dtos;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Mappers;

namespace ApplicationCore.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TodoServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddNewTodo(int listId, TodoDto newTodo)
        {
            var list = _unitOfWork.TodoList.GetTodoListById(listId);

            if (list == null) 
            {
                return false;
            }

            list.AddTodo(_mapper);
        }

        public bool MarkTodoCompleted(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTodoImportantStatus(int id, bool isImportant)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTodoPriorityInList(int id, int listId, int priority)
        {
            throw new NotImplementedException();
        }
    }
}
