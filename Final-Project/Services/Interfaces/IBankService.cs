using System;
using Final_Project.Models;

namespace Final_Project.Services.Interfaces
{
    public interface IBankService<T> where T : BaseEntity
    {
        void Create(T entity);
        void Delete(string name, string info, int infos);
        void Update(string name, int money, string word);
        void Get(string input);
        void GetEverything();
    }
}

