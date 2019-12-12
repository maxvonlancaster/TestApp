using Forum.BLL.Services.Interfaces;
using Forum.DAL.Entities;
using Forum.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ForumDbContext _context;

        public CommentService(ForumDbContext context)
        {
            _context = context;
        }

        public void Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> Get()
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
