using System;
using System.Linq;
using System.Xml.Linq;
using Final_Project.Data;
using Final_Project.Models;
using Final_Project.Services.Interfaces;

namespace Final_Project.Services.Implementations
{
    public class EmployeeService : IBankService<Employee>, IEmployeeService
    {
        public readonly Bank<Employee> bank;
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
            Employee employee = bank.Datas.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            if (employee != null)
            {
                employee.SoftDelete = true;
                GetEverything();
            }
            else
            {
                Console.WriteLine("employee entered is null or unavailable");
            }
        }

        public void Get(string name)
        {
            try
            {
                Employee employee = bank.Datas.Find(m => m.Name.Contains(name.Trim())
                || m.Surname.Contains(name.Trim()));
                Console.WriteLine(employee.Name + " " + employee.Surname + " " + employee.Profession + " " + employee.Salary);
            }
            catch (Exception)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void GetEverything()
        {
            var i = 1;
            foreach (Employee employee in bank.Datas.Where(m => m.SoftDelete == false).ToList())
            {
                Console.WriteLine(i + ") " + employee.Name + " " + employee.Surname + " " + employee.Salary + " " + employee.Profession);
                i++;
            }
        }

        public void Update(string name, decimal salary, string profession)
        {
            Employee employee = bank.Datas.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            employee.Salary = salary;
            employee.Profession = profession;
            Console.WriteLine("Employee Updated !");
        }
    }
}

