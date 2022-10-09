using System;
using Final_Project.Models;

namespace Final_Project.Services.Interfaces
{
    public interface IBranchService : IBankService<Branch>
    {
        bool HireEmployee(string fullNameofEmployee, string branchName);
        void GetProfit(string name);
        //void TransferMoney(string name1, string name2, decimal budget);
    }
}

