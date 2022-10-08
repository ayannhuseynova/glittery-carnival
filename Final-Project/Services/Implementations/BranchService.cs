using System;
using System.Linq;
using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services.Interfaces;

namespace Final_Project.Services.Implementations
{
    public class BranchService : IBankService<Branch>, IBranchService
    {
        public readonly Bank<Branch> bank;
        public readonly Bank<Employee> employees;
        public BranchService()
        {
            bank = new Bank<Branch>();
            employees = new Bank<Employee>();
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
            Branch branch = bank.Datas.Where(x => x.Name.Trim() == name.Trim()).FirstOrDefault();
            if (branch != null)
            {
                branch.SoftDelete = true;
                GetEverything();
            }
            else
            {
                Console.WriteLine("branch entered is null");
            }
        }

        public void Get(string name)
        {
            try
            {
                Branch branch = bank.Datas.Find(m => m.Name.Contains(name.Trim())
                || m.Address.Contains(name.Trim()));
                Console.WriteLine(branch.Name + " " + branch.Address + " " + branch.Budget);
            }
            catch (Exception)
            {
                Console.WriteLine("Branch not found");
            }
        }

        public void GetEverything()
        {
            var i = 1;
            foreach (var branch in bank.Datas)
            {
                if (branch.SoftDelete == false)
                {
                    Console.WriteLine(i + ") " + branch.Name + " " + branch.Address + " " + branch.Budget);
                    i++;
                }
            }
        }

        public void Update(string name, decimal budget, string address)
        {
            Branch branch = bank.Datas.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            if (branch != null)
            {
                branch.Address = address;
                branch.Budget = budget;
                Console.WriteLine("Branch Updated !\n");
            }
            else
            {
                Console.WriteLine("branch entered is null or unavailable");
            }
        }

        public void GetProfit(string name)
        {
            Branch branch = bank.Datas.Find(b => b.Name.ToLower().Trim() == name.ToLower().Trim());
            if (branch != null)
            {
                if (branch.Employees.Any())
                {
                    decimal totsalary = 0;
                    foreach (var employee in branch.Employees)
                    {
                        totsalary += employee.Salary;
                    }
                    decimal ourprofit = branch.Budget - totsalary;
                    Console.WriteLine("Our profit monthly: " + ourprofit);
                }
            }
            else
            {
                Console.WriteLine("Branch entered is null or unavailable");
            }
        }

        public void HireEmployee(string namaBra, string nameEmp)
        {
            Branch branch = bank.Datas.Find(x => x.Name.ToLower().Trim() == namaBra.ToLower().Trim());
        }

        public void TransferEmployee(string fromBranch, string toBranch, string name3)
        {
            Branch branch1 = bank.Datas.Find(a => a.Name.Trim() == fromBranch.Trim());
            Branch branch2 = bank.Datas.Find(a => a.Name.Trim() == toBranch.Trim());
            Employee empTransfer = branch1.Employees.Find(a => a.Name.Trim() == name3.Trim());
            empTransfer.SoftDelete = true;
            branch1.Employees.Remove(empTransfer);
            branch2.Employees.Add(empTransfer);
            Console.WriteLine("Employee transferred");
            foreach (Employee employee in branch2.Employees)
            {
                Console.WriteLine(employee.Name + " " + employee.Surname + " " + employee.Salary + " " + employee.Profession);
            }
        }

        public void TransferMoney(string name1, string name2, decimal budget)
        {
            Branch branch1 = bank.Datas.Find(x => x.Name.ToLower().Trim() == name1.ToLower().Trim());
            Branch branch2 = bank.Datas.Find(x => x.Name.ToLower().Trim() == name2.ToLower().Trim());
            branch1.Budget = branch1.Budget - budget;
            branch2.Budget = branch2.Budget + budget;
            Console.WriteLine($"The amount of {budget}  was already transferred !");
            GetEverything();
        }
    }
}

