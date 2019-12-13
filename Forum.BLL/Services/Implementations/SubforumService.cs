using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Implementations
{
    public class SubforumService : ISubforumService
    {
        private ForumsDbContext _context;

        public SubforumService(ForumsDbContext context)
        {
            _context = context;
        }

        public void Add(SubForum entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubForum> Get()
        {
            throw new NotImplementedException();
        }

        public SubForum Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SubForum entity)
        {
            throw new NotImplementedException();
        }
    }
}
