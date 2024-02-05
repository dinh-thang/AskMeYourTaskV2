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

        public IEnumerable<TodoListDto> GetAllTodoLists()
        {
            List<TodoListDto> resultList = new List<TodoListDto>();
            IEnumerable<Todo> todoEntities = new List<Todo>();
            IEnumerable<TodoDto> todoDtos = new List<TodoDto>();

            foreach (TodoList list in _unitOfWork.TodoListsRepository.GetAllTodoList())
            {
                TodoListDto listDto = _mapper.ToDto<TodoListDto>(list);
                
                todoEntities = _unitOfWork.TodoListsRepository.GetAllTodo(list.Id);
                todoDtos = _mapper.ToDtoList<TodoDto>(todoEntities);
                listDto.Todos = todoDtos;

                resultList.Add(listDto);
            }
            return resultList;
        }

        public bool AddNewTodoList(TodoListDto newTodoList)
        {
            TodoList list = _mapper.ToEntity<TodoList>(newTodoList);
            bool success = _unitOfWork.TodoListsRepository.AddTodoList(list);
            _unitOfWork.Save();
            return success;
        }

        public bool UpdateTodoListColor(string id, string hexValue)
        {
            Guid guid = Guid.Parse(id);
            TodoList? list = _unitOfWork.TodoListsRepository.GetTodoListById(guid);

            try
            {
                Guard.AgainstNull(list, $"Can't find todo list with id: {guid}.");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            list!.SetColor(hexValue);

            bool success = _unitOfWork.TodoListsRepository.Update<TodoList>(list);
            _unitOfWork.Save();
            return success;
        }

        public bool RemoveTodoListById(string id)
        {
            Guid guid = Guid.Parse(id);
            TodoList? list = _unitOfWork.TodoListsRepository.GetTodoListById(guid);

            try
            {
                Guard.AgainstNull(list, $"Can't find todo list with id: {guid}.");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            bool success = _unitOfWork.TodoListsRepository.DeleteTodoList(list!);
            _unitOfWork.Save();
            return success;
        }
    }
}
