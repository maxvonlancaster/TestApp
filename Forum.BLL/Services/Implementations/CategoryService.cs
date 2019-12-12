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
        private ForumDbContext _context;

        public CategoryService(ForumDbContext context)
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
