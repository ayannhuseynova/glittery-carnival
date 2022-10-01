using System;
namespace Final_Project.Models
{
    public class Manager : BaseEntity
    {
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Manager(string name, string surname, string username, string password)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            SoftDelete = false;
        }
    }
}

