using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Implementations
{
    public class PostService : IPostService
    {
        private ForumDbContext _context;

        public PostService(ForumDbContext context)
        {
            _context = context;
        }

        public void Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> Get()
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
