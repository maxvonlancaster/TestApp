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
    public class PostService : IPostService
    {
        private ForumsDbContext _context;

        public PostService(ForumsDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<List<Post>> Get()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> Get(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task Update(Post entity)
        {
            _context.Posts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool PostExists(int id) 
        {
            return _context.Posts.Any(p => p.PostId == id);
        }
    }
}
