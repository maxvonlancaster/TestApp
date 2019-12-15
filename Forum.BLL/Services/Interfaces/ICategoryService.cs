using Forum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        void Add(Category entity);
        void Delete(int id);
        List<Category> Get();
        Category Get(int id);
        void Update(Category entity);
    }
}
