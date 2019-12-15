using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Interfaces
{
    public interface ICommentService
    {
        void Add(Comment entity);
        void Delete(int id);
        List<Comment> Get();
        Comment Get(int id);
        void Update(Comment entity);
    }
}
