using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Services.Interfaces
{
    public interface IService<T,S>
    {
        void Add(T entity);
        List<T> Get();
        T Get(S id);
        void Update(T entity);
        void Delete(S id);
    }
}
