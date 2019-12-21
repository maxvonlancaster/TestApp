using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task Add(User entity);
        Task Delete(int id);
        Task<List<User>> Get();
        Task<User> Get(int id);
        Task Update(User entity);
        bool UserExists(int id);
    }
}
