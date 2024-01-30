using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Mappers;

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
            IEnumerable<Todo> todosE = new List<Todo>();
            IEnumerable<TodoDto> todos = new List<TodoDto>();

            foreach (TodoList list in _unitOfWork.TodoListsRepository.GetAllTodoList())
            {
                TodoListDto listDto = _mapper.ToDto<TodoListDto>(list);
                todosE = _unitOfWork.TodoListsRepository.GetAllTodo(list.Id.ToString());

                // manually mapping the Todos property
                todos = _mapper.ToDtoList<TodoDto>(todosE);
                listDto.Todos = todos;

                resultList.Add(listDto);
            }
            return resultList;
        }

        public bool AddNewTodoList(TodoListDto newTodoList)
        {
            try
            {
                TodoList list = _mapper.ToEntity<TodoList>(newTodoList);
                _unitOfWork.TodoListsRepository.AddTodoList(list);
            }
            catch (Exception)
            {
                return false;
            }
            _unitOfWork.Save();
            return true;
        }

        public bool UpdateTodoListColor(string id, string hexValue)
        {
            TodoList? list = _unitOfWork.TodoListsRepository.GetTodoListById(id);

            if (list == null) 
            {
                return false;
            }

            list.Color = hexValue;

            foreach (Todo todo in list.Todos) 
            {
                todo.Color = hexValue;
            }

            _unitOfWork.Save();
            return true;
        }

        public bool RemoveTodoListById(string id)
        {
            TodoList? list = _unitOfWork.TodoListsRepository.GetTodoListById(id);

            if (list == null) 
            {
                return false;
            }
            _unitOfWork.TodoListsRepository.DeleteTodoList(list);
            _unitOfWork.Save();
            return true;
        }
    }
}
