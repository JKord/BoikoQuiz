#region namespace
using System.IO;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.Event;
#endregion

namespace BoikoQuiz.Core.DataLayer
{
    public delegate void DBEventHandler<T>(object sender, DBEventArgs<T> e);

    public class Database
    {
        #region Fields

        private readonly SQLiteAsyncConnection _dbConnection;
        private readonly SQLiteConnectionString _connectionParameters;
        private readonly SQLiteConnectionPool _sqliteConnectionPool;
        public SQLiteAsyncConnection Dbc { get { return _dbConnection; } }

        #endregion

        public Database(ISQLitePlatform platform, string databasePath)
        {
            _connectionParameters = new SQLiteConnectionString(databasePath, false);
            _sqliteConnectionPool = new SQLiteConnectionPool(platform);

            _dbConnection = new SQLiteAsyncConnection(() => _sqliteConnectionPool.GetConnection(_connectionParameters));

            Repository.Repository.Db = this;
        }

        public async void Initialize()
        {
            await _dbConnection.CreateTableAsync<User>();
            await _dbConnection.CreateTableAsync<Answer>();
            await _dbConnection.CreateTableAsync<Question>();

            Task.WaitAll();
            loadData();

            return;
        }

        private void loadData()
        {
            string text = "";            
            Stream stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("BoikoQuiz.Core.data.json");
            using (var reader = new StreamReader(stream)) {
                text = reader.ReadToEnd();               
            }

            var parsedJson = JObject.Parse(text);

            List<User> users = new List<User>();
            foreach (var question in parsedJson["users"])
                users.Add(User.createByJToken(question));
            AddNew(users);

            List<Question> questions = new List<Question>();
            foreach (var question in parsedJson["questions"])
            {
                Question q = Question.createByJToken(question);
                questions.Add(q);
                AddNew(q.Answers);
            }               
            AddNew(questions);
        }

        public async void AddNew(Entity item)
        {
            await _dbConnection.InsertAsync(item);
        }

        public async void AddNew(IEnumerable<Entity> items)
        {
            await _dbConnection.InsertAllAsync(items);
        }

        public async void Update(Entity item)
        {
            await _dbConnection.UpdateAsync(item);
        }

        public async void Delete(Entity item)
        {
            await _dbConnection.DeleteAsync(item);
        }

        public async void ExecuteList<T>(DBEventHandler<T> completed) where T : Entity
        {
            var eventArgs = new DBEventArgs<T>();
            eventArgs.Result = await _dbConnection.Table<T>().ToListAsync();

            completed(this, eventArgs);
            completed = null;
        }

        public async void Execute<T>(AsyncTableQuery<T> query, DBEventHandler<T> completed) where T : Entity
        {
            var eventArgs = new DBEventArgs<T>();
            eventArgs.Result = await query.ToListAsync();

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