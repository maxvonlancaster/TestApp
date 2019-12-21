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
    public class UserService : IUserService
    {
        private ForumsDbContext _context;

        public UserService(ForumsDbContext context)
        {
            _context = context;
        }

        public async Task Add(User entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<List<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool UserExists(int id) 
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
