namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Tracks the players current score.
    /// </summary>
    public class GameScore
    {
        public static uint score = 0;
        private static GameScore mInstance;
        private static string playerName;
        public static List<Tuple<uint,string>> scoreList;
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
                    scoreList = new List<Tuple<uint, string>>();
                    scoreList.Add(new Tuple<uint, string>(50, "BOB"));
                    scoreList.Add(new Tuple<uint, string>(40, "ABC"));
                    scoreList.Add(new Tuple<uint, string>(30, "ABC"));
                    scoreList.Add(new Tuple<uint, string>(20, "MOB"));
                    scoreList.Add(new Tuple<uint, string>(10, "NOM"));
                }

                return mInstance;
            }
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
        /// Adds points to total score.
        /// </summary>
        /// <param name="points">total points earned.</param>
        public void Add(uint points)
        {
            GameScore.score += points;
        }

        /// <summary>
        /// Returns tuple list of top scores and players' initials.
        /// </summary>
        /// <returns>List of top scores.</returns>
        public List<Tuple<uint, string>> GetScoreList()
        {
            GameScore.scoreList = GameScore.scoreList.OrderByDescending(t => t.Item1).ToList();
            return GameScore.scoreList;
        }

        /// <summary>
        /// Adds the score and player initials from just finished game.
        /// </summary>
        /// <param name="points">Points the player finished with.</param>
        public void AddToScoreList(uint points)
        {
            GameScore.scoreList.Add(new Tuple<uint, string>(points, GameScore.playerName));
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

        /// <summary>
        /// Resets the top 10 scores.
        /// </summary>
        public void ResetTopTen()
        {
            GameScore.scoreList.Clear();
            scoreList.Add(new Tuple<uint, string>(50, "BOB"));
            scoreList.Add(new Tuple<uint, string>(40, "ABC"));
            scoreList.Add(new Tuple<uint, string>(30, "ABC"));
            scoreList.Add(new Tuple<uint, string>(20, "MOB"));
            scoreList.Add(new Tuple<uint, string>(10, "NOM"));
        }
    }
}
