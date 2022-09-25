using System;
namespace Final_Project.Models
{
    public class Manager
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid Username { get; set; }
        public string Password { get; set; }
        public string SoftDelete { get; set; }
    }
}

