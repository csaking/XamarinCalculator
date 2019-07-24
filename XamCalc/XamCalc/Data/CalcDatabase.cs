using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XamCalc.Models;

namespace XamCalc.Data
{
    public class CalcDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CalcDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Entry>().Wait();
        }

        public Task<List<Entry>> GetEntriesAsync()
        {
            return _database.Table<Entry>().ToListAsync();
        }

        public Task<Entry> GetEntryAsync(int id)
        {
            return _database.Table<Entry>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEntryAsync(Entry entry)
        {
            if (entry.ID != 0)
            {
                return _database.UpdateAsync(entry);
            }
            else
            {
                return _database.InsertAsync(entry);
            }
        }

        public Task<int> DeleteEntryAsync(Entry entry)
        {
            return _database.DeleteAsync(entry);
        }
    }
}
