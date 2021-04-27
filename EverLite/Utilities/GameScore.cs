namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Tracks the players current score.
    /// </summary>
    public class GameScore
    {
        public static uint score = 0;
        public static uint topScore = 0;
        private static GameScore mInstance;
        private static string playerName;
        public static List<uint> scoreList;
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
                    scoreList = new List<uint>();
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
        /// Gets the TopScore for the game.
        /// </summary>
        public uint TopScore
        {
            get { return GameScore.topScore; }
        }

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


        public void AddTopScore(uint points)
        {
            if (points > GameScore.topScore)
                GameScore.topScore = GameScore.score;
        }

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

        public void ResetTopTen()
        {
            GameScore.topScore = 0;
        }
    }
}
