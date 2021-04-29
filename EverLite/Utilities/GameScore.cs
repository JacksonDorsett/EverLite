namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Tracks the players current score.
    /// </summary>
    public class GameScore
    {
        private static uint score = 0;
        private static GameScore mInstance;
        private static string playerName;
        private static List<HighScore> scoreList1;
        public static HighScore highScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameScore"/> class.
        /// </summary>
        private GameScore()
        {
        }

        /// <summary>
        /// Gets instance of GameScore.
        /// </summary>
        public static GameScore Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new GameScore();
                    playerName = string.Empty;
                    scoreList1 = new List<HighScore>();
                }

                return mInstance;
            }
        }

        /// <summary>
        /// Gets the HighScore entity from GameScore.
        /// </summary>
        public HighScore HighScore
        {
            get { return GameScore.highScore; }
        }

        /// <summary>
        /// Gets the total score for the game.
        /// </summary>
        public uint Score
        {
            get { return GameScore.score; }
        }
        
        /// <summary>
        /// Gets the player's initials.
        /// </summary>
        public string PlayerName
        {
            get { return GameScore.playerName; }
        }

        /// <summary>
        /// Loads the local high score list from the Sql DB.
        /// </summary>
        /// <param name="score">Sql DB.</param>
        public void GetSqlData(List<HighScore> score)
        {
            GameScore.scoreList1.Clear();
            foreach (HighScore s in score)
                GameScore.scoreList1.Add(s);
            List<HighScore> sorted = GameScore.scoreList1.OrderByDescending(o => o.Score).ToList();
            GameScore.scoreList1.Clear();
            GameScore.scoreList1 = sorted;
        }

        /// <summary>
        /// Adds points to total score.
        /// </summary>
        /// <param name="points">total points earned.</param>
        public void Add(uint points)
        {
            GameScore.score += points;
        }

        /// <summary>
        /// Gets the local high score list.
        /// </summary>
        /// <returns>Local high score list.</returns>
        public List<HighScore> GetScoreList()
        {
            return GameScore.scoreList1;
        }

        /// <summary>
        /// Adds the score and player initials from just finished game.
        /// </summary>
        /// <param name="points">Points the player finished with.</param>
        public void AddToScoreList(uint points)
        {
            highScore = new HighScore { Id = GetNextId(), Name = GameScore.playerName, Score = points };
            GameScore.scoreList1.Add(highScore);
            
            List<HighScore> sorted = GameScore.scoreList1.OrderByDescending(o => o.Score).ToList();
            GameScore.scoreList1.Clear();
            GameScore.scoreList1 = sorted;
        }

        /// <summary>
        /// Assigns the next high score unique id.
        /// </summary>
        /// <returns>Returns the next available unique id.</returns>
        public int GetNextId()
        {
            int temp = 0;
            foreach (HighScore h in GameScore.scoreList1)
            {
                if (temp < h.Id)
                    temp = h.Id;
            }
            return temp + 1;
        }

        /// <summary>
        /// Adds the player's initials to playerName.
        /// </summary>
        /// <param name="name">String of 3 characters.</param>
        public void AddPlayerInitials(string name)
        {
            GameScore.playerName = name;
        }

        /// <summary>
        /// Resets the score to 0.
        /// </summary>
        public void Reset()
        {
            GameScore.score = 0;
        }
    }
}
