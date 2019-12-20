using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Add(Category entity);
        Task Delete(int id);
        Task<List<Category>> Get();
        Task<Category> Get(int id);
        Task Update(Category entity);
    }
}
