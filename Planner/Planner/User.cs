using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } //We should hash the password before saving it in order to improve security
        public List<Activity> Activities { get; set; }
        public List<DailyRemider> DailyRemiders { get; set; }
        public User() { }
        public User(int id, string name, string username, string passwordHash)
        {
            Id = id;
            Name = name;
            Username = username;
            PasswordHash = passwordHash;
            Activities = new List<Activity>();
            DailyRemiders = new List<DailyRemider>();
        }
    }
}
