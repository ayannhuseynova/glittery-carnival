using System;
using Final_Project.Models;

namespace Final_Project.Services.Interfaces
{
    public interface IBranchService : IBankService<Branch>
    {
        void HireEmployee(string nameBra, string nameEmp);
        void GetProfit(string name);
        void TransferMoney(string name1, string name2, decimal budget);
        void TransferEmployee(string fromBranch, string toBranch, string name3);
    }
}

