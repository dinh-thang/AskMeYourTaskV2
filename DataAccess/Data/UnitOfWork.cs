﻿using ApplicationCore.Entities.Todo;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Repositories;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        private ITodoListRepository _todoListRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ITodoListRepository TodoListsRepository
        {
            get
            {
                if (_todoListRepository == null)
                {
                    _todoListRepository = new TodoListRepository(_context); 
                }
                return _todoListRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
