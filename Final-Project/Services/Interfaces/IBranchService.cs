using System;
using Final_Project.Models;

namespace Final_Project.Services.Interfaces
{
    public interface IBranchService : IBankService<Branch>
    {
        void HireEmployee();
        void GetProfit(int budget);
        void TransferMoney();
        void TransferEmployee(string name);
    }
}

