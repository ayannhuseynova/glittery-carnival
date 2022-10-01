using System;
using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services.Interfaces;

namespace Final_Project.Services.Implementations
{
    public class EmployeeService : IBankService<Employee>, IEmployeeService
    {
        private Bank<Employee> bank;
        public EmployeeService()
        {
            bank = new Bank<Employee>();
        }

        public void Create(Employee entity)
        {
            if (entity.SoftDelete == false)
            {
                bank.Datas.Add(entity);
            }
        }

        public void Delete(string name)
        {
            Employee employee = bank.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            employee.SoftDelete = true;
            GetEverything();
        }

        public void Get(string input)
        {
            try
            {
                Employee employee = bank.Datas.Find(m => m.Name.Contains(input.ToLower().Trim()) || m.Surname.Contains(input.ToLower().Trim()) || m.Profession.Contains(input.ToLower().Trim()));

                Console.WriteLine(employee.Name + " " + employee.Surname + " " + employee.Profession);
            }
            catch (Exception)
            {
                Console.WriteLine("Employee is not found");
            }
        }

        public void GetEverything()
        {
            foreach (Employee employee in bank.Datas.FindAll(m => m.SoftDelete == false))
            {
                Console.WriteLine(employee.Name + " " + employee.Surname);
            }
        }

        public void Update(string name, int salary, string profession)
        {
            Employee employee = bank.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            employee.Salary = salary;
            employee.Profession = profession;
        }

        internal static void Create(object entity)
        {
            throw new NotImplementedException();
        }
    }
}

