using System;
using Final_Project.Models;

namespace Final_Project.Services.Interfaces
{
    public interface IBankService<T> where T : BaseEntity
    {
        void Create(T entity);
        void Delete(string name);
        void Update(string name, decimal money, string word);
        void Get(string name);
        void GetEverything();
    }
}

