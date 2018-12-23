using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using KarlovasiHome.Models;
using SQLite;

namespace KarlovasiHome.Services
{
    public class BaseDataService : INotifyPropertyChanged
    {
        private User _user;
        private List<User> _users;
        private List<Apartment> _favorites;
        private List<Apartment> _apartments;

        private SQLiteAsyncConnection _database;
        public AsyncTableQuery<User> UserDatabase { get; set; }
        public AsyncTableQuery<Apartment> ApartmentDatabase { get; set; }
        public AsyncTableQuery<Favorite> FavoriteDatabase { get; set; }

        public List<User> MockUsers { get; set; }
        public List<Apartment> MockApartments { get; set; }
        
        //------------------------------------------------------------------------------------

        public async Task Load()
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
                new Apartment { Id = "7", OwnerId = "1", Name = "Apartment1", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "8", OwnerId = "1", Name = "Apartment2", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "9", OwnerId = "1", Name = "Apartment3", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "10", OwnerId = "1", Name = "Apartment4", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "11", OwnerId = "1", Name = "Apartment5", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "12", OwnerId = "1", Name = "Apartment6", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single},
                new Apartment { Id = "13", OwnerId = "1", Name = "Apartment7", IsAvailable = true, Address = "Αισώπου 3, Νέο Καρλόβασι, Σάμος", Price = 230.00, FloorArea = 35.00, Rooms = 2, Year = 2004, Description = "Το σπίτι γαμάη ψήστο! Έχει και ερκοδίσο!", RoomType = RoomType.Single}
            };

            foreach (var user in MockUsers)
                await InsertItem(user);

            foreach (var apartment in MockApartments)
                await InsertItem(apartment);
        }

        public async Task LoadLists()
        {
            Users = await UserDatabase.ToListAsync();
            Apartments = await ApartmentDatabase.ToListAsync();
        }

        public Task<int> InsertItem(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            LoadLists();
            return Database.InsertAsync(user);
        }

        public Task<int> InsertItem(Apartment apartment)
        {
            apartment.Id = Guid.NewGuid().ToString();
            LoadLists();
            return Database.InsertAsync(apartment);
        }

        public Task<int> InsertItem(Favorite favorite)
        {
            favorite.Id = Guid.NewGuid().ToString();
            LoadLists();
            return Database.InsertAsync(favorite);
        }

        public SQLiteAsyncConnection Database
        {
            get { return _database; }
            set
            {
                _database = value;
                OnPropertyChanged(nameof(Database));
            }
        }

//------------------------------------------------------------------------------------

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(Models.User));
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public List<Apartment> Favorites
        {
            get { return _favorites; }
            set
            {
                _favorites = value;
                OnPropertyChanged(nameof(Favorites));
            }
        }

        public List<Apartment> Apartments
        {
            get { return _apartments; }
            set
            {
                _apartments = value;
                OnPropertyChanged(nameof(Apartments));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}