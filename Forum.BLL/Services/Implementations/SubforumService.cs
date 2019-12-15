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
    public class SubforumService : ISubforumService
    {
        private ForumsDbContext _context;

        public SubforumService(ForumsDbContext context)
        {
            _context = context;
        }

        public async Task Add(SubForum entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var subForum = await _context.SubForums.FindAsync(id);
            if (subForum != null)
            {
                _context.SubForums.Remove(subForum);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<List<SubForum>> Get()
        {
            return await _context.SubForums.ToListAsync();
        }

        public async Task<SubForum> Get(int id)
        {
            return await _context.SubForums.FirstOrDefaultAsync(s => s.SubForumId == id);
        }

        public async Task Update(SubForum entity)
        {
            _context.SubForums.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
