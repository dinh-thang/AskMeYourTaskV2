using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using CustomLibraries.Guards;
using CustomLibraries.Mappers;

namespace ApplicationCore.Services
{
    public class TodoListServices : ITodoListServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Guid _guid;

        public TodoListServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TodoListDto>> GetAllTodoListsAsync()
        {
            List<TodoListDto> resultList = new List<TodoListDto>();
            IEnumerable<Todo> todoEntities = new List<Todo>();
            IEnumerable<TodoDto> todoDtos = new List<TodoDto>();

            foreach (TodoList list in await _unitOfWork.TodoListsRepository.GetAllTodoListAsync())
            {
                TodoListDto listDto = _mapper.ToDto<TodoListDto>(list);

                todoEntities = await _unitOfWork.TodoListsRepository.GetAllTodoAsync(list.Id);
                todoDtos = _mapper.ToDtoList<TodoDto>(todoEntities);
                listDto.Todos = todoDtos;

                resultList.Add(listDto);
            }
            return resultList;
        }

        public async Task AddNewTodoListAsync(TodoListDto newTodoList)
        {
            TodoList list = _mapper.ToEntity<TodoList>(newTodoList);
            await _unitOfWork.TodoListsRepository.AddTodoListAsync(list);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTodoListColorAsync(string id, string hexValue)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                TodoList? list = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(_guid);
                Guard.AgainstNull(list, $"Can't find todo list with id: {_guid}.");

                list!.SetColor(hexValue);

                _unitOfWork.TodoListsRepository.Update(list);
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

        public async Task UpdateTodoListTagAsync(string id, string tag)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                TodoList? list = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(_guid);
                Guard.AgainstNull(list, $"Can't find todo list with id: {_guid}.");

                list!.Tag = tag;

                _unitOfWork.TodoListsRepository.Update(list);
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

        public async Task RemoveTodoListByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out _guid))
                {
                    throw new ArgumentException("Invalid id format.");
                }
                TodoList? list = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(_guid);
                Guard.AgainstNull(list, $"Can't find todo list with id: {_guid}.");

                _unitOfWork.TodoListsRepository.DeleteTodoList(list!);
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