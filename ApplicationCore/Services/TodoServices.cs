using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using CustomLibraries.Mappers;
using CustomLibraries.Guards;

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
            Guid guid = Guid.Parse(listId);
            TodoList? todoList = _unitOfWork.TodoListsRepository.GetTodoListById(guid);

            try
            {
                Guard.AgainstNull(todoList, $"Can't find todo list with id {guid}");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
          
            Todo todo = _mapper.ToEntity<Todo>(newTodo);
            todo.TodoListId = todoList!.Id;
            
            bool state = _unitOfWork.TodoListsRepository.AddTodo(todo);
            _unitOfWork.Save();

            return state;
        }

        public bool MarkTodoCompleted(string id)
        {
            Guid guid = Guid.Parse(id);
            Todo? selectedTodo = _unitOfWork.TodoListsRepository.GetTodoById(guid);

            try
            {
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {guid}");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            selectedTodo!.MarkCompleted();
            
            bool state = _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
            _unitOfWork.Save();

            return state;
        }

        public bool UpdateTodoImportantStatus(string id, bool isImportant)
        {
            Guid guid = Guid.Parse(id);
            Todo? selectedTodo = _unitOfWork.TodoListsRepository.GetTodoById(guid);

            try
            {
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {guid}");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            selectedTodo!.Important = isImportant;

            bool state = _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
            _unitOfWork.Save();

            return state;
        }

        public bool UpdateTodoPriorityInList(string id, int priority)
        {
            Guid guid = Guid.Parse(id);
            Todo? selectedTodo = _unitOfWork.TodoListsRepository.GetTodoById(guid);

            try
            {
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {guid}.");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            selectedTodo!.Priority = priority;

            bool state = _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
            _unitOfWork.Save();

            return state;
        }
    }
}
