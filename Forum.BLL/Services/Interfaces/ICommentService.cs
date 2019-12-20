using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Interfaces
{
    public interface ICommentService
    {
        Task Add(Comment entity);
        Task Delete(int id);
        Task<List<Comment>> Get();
        Task<Comment> Get(int id);
        Task Update(Comment entity);
    }
}
