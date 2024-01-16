using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
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
            list.AddTodo(_mapper.ToEntity<Todo>(newTodo));
            return true;
        }

        public bool MarkTodoCompleted(int id, int listId)
        {
            Todo? selectedTodo = _unitOfWork.TodoList.GetTodoById(id, listId);
            
            if (selectedTodo == null) 
            {
                return false;
            }
            selectedTodo.MarkCompleted();
            return true;
        }

        public bool UpdateTodoImportantStatus(int id, int listId, bool isImportant)
        {
            Todo? selectedTodo = _unitOfWork.TodoList.GetTodoById(id, listId);

            if (selectedTodo == null)
            {
                return false;
            }
            selectedTodo.Important = true;
            return true;
        }

        public bool UpdateTodoPriorityInList(int id, int listId, int priority)
        {
            Todo? selectedTodo = _unitOfWork.TodoList.GetTodoById(id, listId);

            if (selectedTodo == null)
            {
                return false;
            }
            selectedTodo.Priority = priority;   
            return true;
        }
    }
}
