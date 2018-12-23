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
            if (!Users.Any(x => x.Username == username && x.Password == password))
                return false;

            User = Users.FirstOrDefault(x => x.Username == username);
            return true;
        }
    }
}