using System;
namespace Final_Project.Models
{
    public class Employee : BaseEntity
    {
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Profession { get; set; }

        public Employee(string name, string surname, decimal salary, string profession, bool softdelete)
        {
            Name = name;
            Surname = surname;
            Salary = salary;
            Profession = profession;
            SoftDelete = false;
        }
    }
}

