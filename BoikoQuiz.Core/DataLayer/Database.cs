#region namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.Event;
#endregion

namespace BoikoQuiz.Core.DataLayer
{
    public delegate void DBEventHandler<T>(object sender, Event.DBEventArgs<T> e);

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

        public async void Initialize()
        {
            //await _dbConnection.CreateTableAsync<User>();
        }

        public async void AddNew(Entity item)
        {
            await _dbConnection.InsertAsync(item);
        }

        public async void Update(Entity item)
        {
            await _dbConnection.UpdateAsync(item);
        }

        public async void Delete(Entity item)
        {
            await _dbConnection.DeleteAsync(item);
        }        

        public async void GetAllUser(DBEventHandler<User> completed)
        {
            var eventArgs = new DBEventArgs<User>();
            eventArgs.Result = await _dbConnection.Table<User>().ToListAsync();

            completed(this, eventArgs);
            completed = null;
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