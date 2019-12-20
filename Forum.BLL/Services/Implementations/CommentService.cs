using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ForumsDbContext _context;

        public CommentService(ForumsDbContext context)
        {
            _context = context;
        }

        public Task Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
