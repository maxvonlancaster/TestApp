using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private ForumsDbContext _context;

        public CategoryService(ForumsDbContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
