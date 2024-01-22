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

            Todo todo = _mapper.ToEntity<Todo>(newTodo);
            todo.TodoListId = Guid.Parse(listId);
            todo.TodoList = list;

            list.AddTodo(todo);
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
