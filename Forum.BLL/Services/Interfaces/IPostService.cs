using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Interfaces
{
    public interface IPostService
    {
        void Add(Post entity);
        void Delete(int id);
        List<Post> Get();
        Post Get(int id);
        void Update(Post entity);
    }
}
