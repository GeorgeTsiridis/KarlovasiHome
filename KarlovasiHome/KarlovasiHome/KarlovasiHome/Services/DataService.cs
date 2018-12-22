using System.Collections.ObjectModel;
using System.Linq;
using KarlovasiHome.Models;
using SQLite;

namespace KarlovasiHome.Services
{
    public class DataService : BaseDataService
    {
        public DataService(string path)
        {
            Database = new SQLiteAsyncConnection(path);
            Database.GetConnection();

            Database.CreateTableAsync<User>().Wait();
            Database.CreateTableAsync<Apartment>().Wait();
            Database.CreateTableAsync<Favorite>().Wait();

            UserDatabase = Database.Table<User>();
            ApartmentDatabase = Database.Table<Apartment>();
            FavoriteDatabase = Database.Table<Favorite>();
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