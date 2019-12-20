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
        Task Delete(string id);
        Task<List<User>> Get();
        Task<User> Get(string id);
        Task Update(User entity);
    }
}
