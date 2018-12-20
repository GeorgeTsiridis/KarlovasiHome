using KarlovasiHome.Models;
using SQLite;

namespace KarlovasiHome.SQLite
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>();
            database.CreateTableAsync<Favorite>();
            database.CreateTableAsync<Apartment>();
        }

        public SQLiteAsyncConnection Database
        {
            get { return database; }
        }
    }
}