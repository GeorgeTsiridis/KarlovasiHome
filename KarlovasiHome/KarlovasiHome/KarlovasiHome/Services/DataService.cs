using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KarlovasiHome.Models;

namespace KarlovasiHome.Services
{
    public class DataService : BaseDataService
    {
        public List<User> MockUsers { get; set; }
        public List<Apartment> MockApartments { get; set; }

        public DataService()
        {
            MockUsers = new List<User>
            {
                new User { Id = "1", Username = "", Password = "", UserType = UserType.Landlord },
                new User { Id = "2", Username = "2", Password = "2", UserType = UserType.Landlord },
                new User { Id = "3", Username = "3", Password = "3", UserType = UserType.Landlord },
                new User { Id = "4", Username = "4", Password = "4", UserType = UserType.Tenant },
                new User { Id = "5", Username = "5", Password = "5", UserType = UserType.Tenant },
                new User { Id = "6", Username = "6", Password = "6", UserType = UserType.Tenant }
            };

            MockApartments = new List<Apartment>
            {
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single}
            };
        }

        public bool SignIn(string username, string password)
        {//hash password
            if (!MockUsers.Any(x => x.Username == username && x.Password == password))
                return false;

            User = MockUsers.FirstOrDefault(x => x.Username == username);
            LoadUserInfo();
            return true;
        }

        public void LoadUserInfo()
        {
            Apartments = new ObservableCollection<Apartment>(MockApartments.Where(x => x.OwnerId == User.Id));
        }

        public bool InsertUser(User user)
        {
            if (MockUsers.Any(x => x.Username == user.Username))
                return false;
            //id + hash password
            MockUsers.Add(user);
            return true;
        }
    }
}