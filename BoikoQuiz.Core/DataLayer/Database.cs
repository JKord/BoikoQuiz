#region namespace
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using BoikoQuiz.Core.BusinessLayer;
#endregion

namespace BoikoQuiz.Core.DataLayer
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _dbConnection;
        private readonly SQLiteConnectionString _connectionParameters;
        private readonly SQLiteConnectionPool _sqliteConnectionPool;

        public Database(ISQLitePlatform platform, string databasePath)
        {
            _connectionParameters = new SQLiteConnectionString(databasePath, false);
            _sqliteConnectionPool = new SQLiteConnectionPool(platform);

            _dbConnection = new SQLiteAsyncConnection(() => _sqliteConnectionPool.GetConnection(_connectionParameters));
        }

        public async Task Initialize()
        {
            //await _dbConnection.CreateTableAsync<ToDo>();
        }

        public async Task<int> AddNew(Entity item)
        {
            var result = await _dbConnection.InsertAsync(item);
            return result;
        }

        public async Task<int> Update(Entity item)
        {
            var result = await _dbConnection.UpdateAsync(item);
            return result;
        }

        public async Task<int> Delete(Entity item)
        {
            var result = await _dbConnection.DeleteAsync(item);
            return result;
        }

        /*public async Task<List<Entity>> GetAllToDos()
        {
            var result = await _dbConnection.Table<Entity>().OrderByDescending(t => t.TimeStamp).ToListAsync();
            return result;
        }

        public async Task<Entity> GetToDoById(int id)
        {
            var result = await _dbConnection.Table<Entity>().Where(t => t.Id == id).FirstOrDefaultAsync();
            return result;
        }*/
    }
}