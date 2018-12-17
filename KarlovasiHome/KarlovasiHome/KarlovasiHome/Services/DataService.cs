using System;
using System.Collections.Generic;
using System.Linq;
using KarlovasiHome.Models;

namespace KarlovasiHome.Services
{
    public class DataService
    {
        public User User { get; set; }

        public List<User> Users { get; set; }
        public List<Apartment> Apartments;

        public DataService()
        {
            Users = new List<User>
            {
                new User { Id = Guid.NewGuid().ToString(), Username = "", Password = "", UserType = UserType.Landlord },
                new User { Id = Guid.NewGuid().ToString(), Username = "2", Password = "2", UserType = UserType.Landlord },
                new User { Id = Guid.NewGuid().ToString(), Username = "3", Password = "3", UserType = UserType.Landlord },
                new User { Id = Guid.NewGuid().ToString(), Username = "4", Password = "4", UserType = UserType.Tenant },
                new User { Id = Guid.NewGuid().ToString(), Username = "5", Password = "5", UserType = UserType.Tenant },
                new User { Id = Guid.NewGuid().ToString(), Username = "6", Password = "6", UserType = UserType.Tenant }
            };

            /*Apartments = new List<Apartment>
            {
                new Apartment { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
               
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }*/
        }

        public bool SignIn(string username, string password)
        {
            if (!Users.Any(x => x.Username == username && x.Password == password))
                return false;

            User = Users.FirstOrDefault(x => x.Username == username);
            return true;
        }
    }
}