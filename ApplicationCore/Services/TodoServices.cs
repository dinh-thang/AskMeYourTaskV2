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

        public async Task<bool> AddNewTodoAsync(string listId, TodoDto newTodo)
        {
            Guid guid = Guid.Parse(listId);
            TodoList? todoList = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(guid);

            try
            {
                Guard.AgainstNull(todoList, $"Can't find todo list with id {guid}");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            newTodo.Important = false;
            newTodo.Completed = false;
          
            Todo todo = _mapper.ToEntity<Todo>(newTodo);
            todo.TodoListId = todoList!.Id;
            
            bool state = await _unitOfWork.TodoListsRepository.AddTodoAsync(todo);
            _unitOfWork.Save();

            return state;
        }

        public async Task<bool> MarkTodoCompletedAsync(string id)
        {
            Guid guid = Guid.Parse(id);
            Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(guid);

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

        public async Task<bool> UpdateTodoImportantStatusAsync(string id, bool isImportant)
        {
            Guid guid = Guid.Parse(id);
            Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(guid);

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

        public async Task<bool> UpdateTodoPriorityInListAsync(string id, int priority)
        {
            Guid guid = Guid.Parse(id);
            Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(guid);

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
