using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Interfaces
{
    public interface ISubforumService
    {
        void Add(SubForum entity);
        void Delete(int id);
        List<SubForum> Get();
        SubForum Get(int id);
        void Update(SubForum entity);
    }
}
