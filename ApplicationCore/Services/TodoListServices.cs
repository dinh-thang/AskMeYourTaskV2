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
            Guid guid = Guid.Parse(id);
            TodoList? list = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(guid);
            Guard.AgainstNull(list, $"Can't find todo list with id: {guid}.");
       
            list!.SetColor(hexValue);

            _unitOfWork.TodoListsRepository.Update<TodoList>(list);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveTodoListByIdAsync(string id)
        {
            Guid guid = Guid.Parse(id);
            TodoList? list = await _unitOfWork.TodoListsRepository.GetTodoListByIdAsync(guid);
            Guard.AgainstNull(list, $"Can't find todo list with id: {guid}.");

            _unitOfWork.TodoListsRepository.DeleteTodoList(list!);
            await _unitOfWork.SaveAsync();
        }
    }
}
