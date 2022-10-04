﻿using System;
using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services.Interfaces;

namespace Final_Project.Services.Implementations
{
    public class BranchService : IBankService<Branch>, IBranchService
    {
        private Bank<Branch> bank;
        public BranchService()
        {
            bank = new Bank<Branch>();
        }

        public void Create(Branch entity)
        {
            if (entity.SoftDelete == false)
            {
                bank.Datas.Add(entity);
            }
        }

        public void Delete(string name)
        {
            Branch branch = bank.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            branch.SoftDelete = true;
            GetEverything();
        }

        public void Get(string input)
        {
            Branch branch = bank.Datas.Find(m => m.Name.Contains(input.ToLower().Trim()) || m.Address.Contains(input.ToLower().Trim()));
            Console.WriteLine(branch.Name + " " + branch.Address);
        }

        public void GetEverything()
        {
            foreach (var branch in bank.Datas.FindAll(m => m.SoftDelete == false))
            {
                Console.WriteLine(branch.Name + " " + branch.Address);
            }
        }

        public void Update(string name, decimal budget, string address)
        {
            Branch branch = bank.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            branch.Address = address;
            branch.Budget = budget;
        }

        public void GetProfit(int budget)
        {

        }

        public void HireEmployee(string name)
        {
            throw new NotImplementedException();
        }

        public void TransferEmployee()
        {

        }

        public void TransferMoney(string name1, string name2, int budget)
        {
            throw new NotImplementedException();
        }
    }
}

