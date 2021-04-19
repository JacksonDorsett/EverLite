// <copyright file="GameScore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
        public static uint mScore = 0;
        public static uint topScore;
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
            get { return GameScore.mScore; }
        }

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
            GameScore.mScore += points;
            if (GameScore.mScore > GameScore.topScore)
                GameScore.topScore = GameScore.mScore;
        }

        /// <summary>
        /// Resets the score to 0.
        /// </summary>
        public void Reset()
        {
            GameScore.mScore = 0;
        }
    }
}
