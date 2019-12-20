using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Implementations
{
    public class PostService : IPostService
    {
        private ForumsDbContext _context;

        public PostService(ForumsDbContext context)
        {
            _context = context;
        }

        public Task Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Post> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
