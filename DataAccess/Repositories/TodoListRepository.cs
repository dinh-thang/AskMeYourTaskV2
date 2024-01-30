﻿using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Repository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly AppDbContext _context;
       
        public TodoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public Todo? GetTodoById(string id)
        {            
            Guid guid = Guid.Parse(id);
            return _context.Todos.FirstOrDefault(todo => todo.Id == guid);
        }

        public TodoList? GetTodoListById(string id)
        {
            Guid guid = Guid.Parse(id);
            return _context.TodoLists.FirstOrDefault(todoList => todoList.Id == guid);
        }    

        public IEnumerable<TodoList> GetAllTodoList()
        {
            return _context.TodoLists.ToList();
        }

        public IEnumerable<Todo>? GetAllTodo(string id)
        {
            TodoList? list = GetTodoListById(id);

            if (list == null) 
            {
                return null;
            }

            _context.Entry(list)
                .Collection(l => l.Todos)
                .Load();

            return list.Todos;
        }

        public bool AddTodoList(TodoList todoList)
        {
            try
            {
                _context.TodoLists.Add(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool AddTodo(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
            }
            catch (Exception) 
            {
                return false;
            }
            return true;
        }

        public bool UpdateTodoList(TodoList todoList)
        {
            try
            {
                _context.TodoLists.Attach(todoList);
                _context.Entry(todoList).State = EntityState.Modified;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTodo(Todo todo)
        {
            try
            {
                _context.Todos.Remove(todo);
            }
            catch (Exception) 
            {
                return false;
            }
            return true;
        }

        public bool DeleteTodoList(TodoList todoList)
        {
            try
            {
                _context.TodoLists.Remove(todoList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
        