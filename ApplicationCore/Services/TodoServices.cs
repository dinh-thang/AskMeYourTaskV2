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
            TodoList? todoList = _unitOfWork.TodoListsRepository.GetTodoListById(listId);

            if (todoList == null)
            {
                return false;
            }

            Todo todo = _mapper.ToEntity<Todo>(newTodo);
            todo.TodoListId = todoList.Id;
            
            bool success = _unitOfWork.TodoListsRepository.AddTodo(todo);
            _unitOfWork.Save();

            if (!success) 
            {
                return false;
            }
            return true;
        }

        public bool MarkTodoCompleted(string id)
        {
            Todo? selectedTodo = _unitOfWork.TodoListsRepository.GetTodoById(id);
            
            if (selectedTodo == null) 
            {
                return false;
            }
            selectedTodo.MarkCompleted();
            
            bool success = _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
            _unitOfWork.Save();

            if (!success)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTodoImportantStatus(string id, bool isImportant)
        {
            Todo? selectedTodo = _unitOfWork.TodoListsRepository.GetTodoById(id);

            if (selectedTodo == null)
            {
                return false;
            }
            selectedTodo.Important = isImportant;

            bool success = _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
            _unitOfWork.Save();

            if (!success)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTodoPriorityInList(string id, int priority)
        {
            Todo? selectedTodo = _unitOfWork.TodoListsRepository.GetTodoById(id);

            if (selectedTodo == null)
            {
                return false;
            }
            selectedTodo.Priority = priority;

            bool success = _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
            _unitOfWork.Save();

            if (!success)
            {
                return false;
            }
            return true;
        }
    }
}
