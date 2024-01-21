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

        public bool AddNewTodo(string listId, TodoDto newTodo)
        {
            TodoList? list = _unitOfWork.TodoList.GetTodoListById(listId);

            if (list == null) 
            {
                return false;
            }
            list.AddTodo(_mapper.ToEntity<Todo>(newTodo));
            return true;
        }

        public bool MarkTodoCompleted(string id)
        {
            Todo? selectedTodo = _unitOfWork.TodoList.GetTodoById(id);
            
            if (selectedTodo == null) 
            {
                return false;
            }
            selectedTodo.MarkCompleted();
            return true;
        }

        public bool UpdateTodoImportantStatus(string id, bool isImportant)
        {
            Todo? selectedTodo = _unitOfWork.TodoList.GetTodoById(id);

            if (selectedTodo == null)
            {
                return false;
            }
            selectedTodo.Important = true;
            return true;
        }

        public bool UpdateTodoPriorityInList(string id, int priority)
        {
            Todo? selectedTodo = _unitOfWork.TodoList.GetTodoById(id);

            if (selectedTodo == null)
            {
                return false;
            }
            selectedTodo.Priority = priority;   
            return true;
        }
    }
}
