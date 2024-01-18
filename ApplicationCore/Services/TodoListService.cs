﻿using ApplicationCore.Dtos;
using ApplicationCore.Entities.Todo;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Mappers;

namespace ApplicationCore.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<TodoListDto> GetAllTodoLists()
        {
            List<TodoListDto> resultList = new List<TodoListDto>();
            List<TodoDto> todos = new List<TodoDto>();

            foreach (TodoList list in _unitOfWork.TodoList.GetAllTodoList())
            {
                TodoListDto listDto = _mapper.ToDto<TodoListDto>(list);
                
                // manually mapping the Todos property
                todos = _mapper.ToDtoList<TodoDto>(list.Todos).ToList();
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
                _unitOfWork.TodoList.AddTodoList(list);
            }
            catch (Exception)
            {
                return false;
            }
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateTodoListColor(int id, Color color)
        {
            TodoList? list = _unitOfWork.TodoList.GetTodoListById(id);

            if (list == null) 
            {
                return false;
            }
            list.Color = color;
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveTodoListById(int id)
        {
            TodoList? list = _unitOfWork.TodoList.GetTodoListById(id);

            if (list == null) 
            {
                return false;
            }
            _unitOfWork.TodoList.DeleteTodoList(list);
            _unitOfWork.Commit();
            return true;
        }

    }
}
