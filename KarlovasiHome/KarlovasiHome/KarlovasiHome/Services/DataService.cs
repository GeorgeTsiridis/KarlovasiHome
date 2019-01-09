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
                });
            }
            catch
            {
                Console.WriteLine("Database Connection Error!");
            }
        }

        /*
        public async Task Load()
        {
            var MockUsers = new List<User>
            {
                new User { Id = "1", Username = "", Password = "", UserType = UserType.Landlord },
                new User { Id = "2", Username = "2", Password = "2", UserType = UserType.Landlord },
                new User { Id = "3", Username = "3", Password = "3", UserType = UserType.Landlord },
                new User { Id = "4", Username = "4", Password = "4", UserType = UserType.Tenant },
                new User { Id = "5", Username = "5", Password = "5", UserType = UserType.Tenant },
                new User { Id = "6", Username = "6", Password = "6", UserType = UserType.Tenant }
            };

            var MockApartments = new List<Apartment>
            {
                new Apartment { Id = "7", OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "8", OwnerId = "1", Name = "Apartment2", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "9", OwnerId = "1", Name = "Apartment3", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "10", OwnerId = "1", Name = "Apartment4", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "11", OwnerId = "1", Name = "Apartment5", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "12", OwnerId = "1", Name = "Apartment6", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "13", OwnerId = "1", Name = "Apartment7", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single}
            };

            foreach (var user in MockUsers)
                await SyncUsers.InsertAsync(user);

            foreach (var apartment in MockApartments)
                await SyncApartments.InsertAsync(apartment);
        }
        */
    }
}