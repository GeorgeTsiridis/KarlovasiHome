using System.Collections.Generic;
using System.Threading.Tasks;
using KarlovasiHome.Models;
using SQLite;

namespace KarlovasiHome.SQLite
{
    public class ItemController
    {
        public readonly SQLiteAsyncConnection database;

        public ItemController()
        {
            database = App.ItemDatabase.Database;
            database.GetConnection();
        }

        public Task<List<User>> GetTasks()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<int> InsertTask(Task task)
        {
            return database.InsertAsync(task);
        }

        public Task<int> DeleteTask(Task task)
        {
            return database.DeleteAsync(task);
        }
    }
}
