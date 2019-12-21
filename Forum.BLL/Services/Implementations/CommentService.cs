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
    public class CommentService : ICommentService
    {
        private ForumsDbContext _context;

        public CommentService(ForumsDbContext context)
        {
            _context = context;
        }

        public async Task Add(Comment entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<List<Comment>> Get()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> Get(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        }

        public async Task Update(Comment entity)
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool CommentExists(int id)
        {
            return _context.Comments.Any(c => c.CommentId == id);
        }
    }
}
