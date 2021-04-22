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
