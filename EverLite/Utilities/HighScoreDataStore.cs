namespace EverLite
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using SQLite;

    /// <summary>
    /// Manages the database.
    /// </summary>
    public class HighScoreDataStore
    {
        readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreDataStore"/> class.
        /// </summary>
        public HighScoreDataStore()
        {
            string dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            dbPath = Path.Combine(dbPath, "highscorelist.sqlite");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<HighScore>().Wait();
        }

        /// <summary>
        /// Add highscore to DB.
        /// </summary>
        /// <param name="HighScore">New high score.</param>
        /// <returns>T or F.</returns>
        public async Task<bool> AddAsync(HighScore HighScore)
        {
            await _database.InsertAsync(HighScore);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Deletes highscore from DB.
        /// </summary>
        /// <param name="id">ID of highscore.</param>
        /// <returns>T or F.</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            await _database.DeleteAsync(id);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Gets all the highscores from the DB.
        /// </summary>
        /// <param name="forceRefresh">False.</param>
        /// <returns>T or F.</returns>
        public async Task<List<HighScore>> GetAsync(bool forceRefresh = false)
        {
            return await _database.Table<HighScore>().ToListAsync();
        }
    }
}
