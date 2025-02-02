using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpark_system
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Date_create { get; set; } = DateTime.Now;
        public DateTime Date_updated { get; set; } = DateTime.Now;
        public bool Is_admin { get; set; }
        public bool Is_login { get; set; } = false;
        public string Gender { get; set; }

        public User(int id, string username, string phone, string email, string password, string gender, bool is_admin)
        {
            Id = id;
            Username = username;
            Phone = phone;
            Email = email;
            Password = HashandCheck.Hash(password);
            Gender = gender;
            Is_admin = is_admin;
        }
    }
}
