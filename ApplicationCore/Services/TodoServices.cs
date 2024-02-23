using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using CustomLibraries.Guards;
using CustomLibraries.Mappers;

namespace ApplicationCore.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Guid _guid;
        

        public TodoServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddNewTodoAsync(string listId, TodoDto newTodo)
        {
            try
            {
                if (!Guid.TryParse(listId, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }

                TodoList? todoList = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(_guid);
                Guard.AgainstNull(todoList, $"Can't find todo list with id {_guid}");

                newTodo.Important = false;
                newTodo.Completed = false;

                Todo todo = _mapper.ToEntity<Todo>(newTodo);
                todo.TodoListId = todoList!.Id;

                await _unitOfWork.TodoListsRepository.AddTodoAsync(todo);
                await _unitOfWork.SaveAsync();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Can't find todo list with id {_guid}. {e.Message}");
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid id format.", e.Message);
            }
        }

        public async Task DeleteTodoAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(_guid);
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {_guid}");

                _unitOfWork.TodoListsRepository.DeleteTodo(selectedTodo!);
                await _unitOfWork.SaveAsync();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Can't find todo list with id {_guid}. {e.Message}");
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid id format.", e.Message);
            }
        }

        public async Task MarkTodoCompletedAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(_guid);
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {_guid}");
           
                selectedTodo!.MarkCompleted();
            
                _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
                await _unitOfWork.SaveAsync();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Can't find todo list with id {_guid}. {e.Message}");
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid id format.", e.Message);
            }
        }

        public async Task UpdateTodoImportantStatusAsync(string id, bool isImportant)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(_guid);
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {_guid}");
           
                selectedTodo!.Important = isImportant;

                _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
                await _unitOfWork.SaveAsync();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Can't find todo list with id {_guid}. {e.Message}");
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid id format.", e.Message);
            }
        }

        public async Task UpdateTodoPriorityInListAsync(string id, int priority)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                Todo? selectedTodo = await _unitOfWork.TodoListsRepository.GetTodoByIdAsync(_guid);
                Guard.AgainstNull(selectedTodo, $"Can't find todo list with id {_guid}.");

                selectedTodo!.Priority = priority;

                _unitOfWork.TodoListsRepository.Update<Todo>(selectedTodo);
                await _unitOfWork.SaveAsync();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Can't find todo list with id {_guid}. {e.Message}");
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid id format.", e.Message);
            }
        }
    }
}
