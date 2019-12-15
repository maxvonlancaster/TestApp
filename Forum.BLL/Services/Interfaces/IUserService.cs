using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User entity);
        void Delete(string id);
        List<User> Get();
        User Get(string id);
        void Update(User entity);
    }
}
