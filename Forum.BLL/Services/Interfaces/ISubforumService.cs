using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Interfaces
{
    public interface ISubforumService
    {
        Task Add(SubForum entity);
        Task Delete(int id);
        Task<List<SubForum>> Get();
        Task<SubForum> Get(int id);
        Task Update(SubForum entity);
    }
}
