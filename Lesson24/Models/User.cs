using Lesson24.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson24.Models
{
    internal class User : IGeneralInterface
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public decimal Balance { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Room> BookedRooms { get; set; } = new List<Room>();
        public static int UserCount { get; set; } = 0;

        public User(string fullname, string email, string password, decimal balance)
        {
            UserCount++;
            Id = UserCount;
            Fullname = fullname;
            Email = email;
            Password = password;
            Balance = balance;
        }

        public string WriteInConsole()
        {
            return $"[{Id}]: {Fullname}, {Email}, {Password}, {Balance}.";
        }

        public override string ToString()
        {
            return $"{Id}|{Fullname}|{Email}|{Password}|{Balance}";
        }
    }
}
