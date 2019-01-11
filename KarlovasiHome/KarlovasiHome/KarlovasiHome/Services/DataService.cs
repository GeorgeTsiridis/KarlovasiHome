using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarlovasiHome.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace KarlovasiHome.Services
{
    public class DataService
    {
        public MobileServiceClient Client { get; set; }

        public IMobileServiceTable<User> SyncUsers { get; set; }
        public IMobileServiceTable<Apartment> SyncApartments { get; set; }
        public IMobileServiceTable<Favorite> SyncFavorites { get; set; }

        public User User { get; set; }
        public List<User> Users { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<Apartment> Favorites { get; set; }

        public Task Init { get; set; }

        public DataService()
        {
            try
            {
                Client = new MobileServiceClient("https://karlovasihome.azurewebsites.net");

                SyncUsers = Client.GetTable<User>();
                SyncApartments = Client.GetTable<Apartment>();
                SyncFavorites = Client.GetTable<Favorite>();

                Init = Task.Run(async () =>
                {
                    Users = new List<User>();
                    Users = await SyncUsers.ToListAsync();
                    //await Load();
                });
            }
            catch
            {
                Console.WriteLine("Database Connection Error!");
            }
        }

        
        public async Task Load()
        {
            var MockApartments = new List<Apartment>
            {
                new Apartment { Id = "7", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment1", Latitude = 37.795582, Longitude = 26.701851, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single},
                new Apartment { Id = "8", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment2", Latitude = 37.796473, Longitude = 26.702772, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single},
                new Apartment { Id = "9", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment3", Latitude = 37.793949, Longitude = 26.706012, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single},
                new Apartment { Id = "10", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment4", Latitude = 37.794346, Longitude = 26.705292, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single},
                new Apartment { Id = "11", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment5", Latitude = 37.795621, Longitude = 26.702930, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single},
                new Apartment { Id = "12", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment6", Latitude = 37.793878, Longitude = 26.695733, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single},
                new Apartment { Id = "13", OwnerId = "5adea3c4-9a8f-413c-9382-b66bff89caf8", Name = "Apartment7", Latitude = 37.796269, Longitude = 26.693385, IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο! Έχει και θέρμανση και έχει και έπιπλα! Είναι το καλυτερότερο!", RoomType = RoomType.Single}
            };

            foreach (var apartment in MockApartments)
                await SyncApartments.InsertAsync(apartment);
        }
        
    }
}