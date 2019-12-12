using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private ForumDbContext _context;

        public UserService(ForumDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
