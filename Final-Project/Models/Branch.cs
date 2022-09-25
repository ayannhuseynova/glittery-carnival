using System;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public class Branch
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Budget { get; set; }
        public List<Employee> Employees { get; set; }
        public string SoftDelete { get; set; }
    }
}

