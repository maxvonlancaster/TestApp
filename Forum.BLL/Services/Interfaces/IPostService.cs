using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Interfaces
{
    public interface IPostService
    {
        Task Add(Post entity);
        Task Delete(int id);
        Task<List<Post>> Get();
        Task<Post> Get(int id);
        bool PostExists(int id);
        Task Update(Post entity);
    }
}
