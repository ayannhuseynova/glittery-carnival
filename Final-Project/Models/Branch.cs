using System;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public class Branch : BaseEntity
    {
        public string Address { get; set; }
        public decimal Budget { get; set; }
        public List<Employee> Employees { get; set; }

        public Branch(string name, string address, decimal budget)
        {
            Name = name;
            Address = address;
            Budget = budget;
            Employees = new List<Employee>();
            SoftDelete = false;
        }
    }
}

