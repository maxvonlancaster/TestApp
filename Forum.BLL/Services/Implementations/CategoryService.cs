using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private ForumsDbContext _context;

        public CategoryService(ForumsDbContext context)
        {
            _context = context;
        }

        public async Task Add(Category entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<List<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }
    }
}
