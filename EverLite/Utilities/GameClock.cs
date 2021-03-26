// <copyright file="GameClock.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Utilities
{
    using System;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Game Clock stores the time.
    /// </summary>
    public class GameClock
    {
        private bool isPaused;
        private TimeSpan mTimePassed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameClock"/> class.
        /// </summary>
        public GameClock()
        {
            this.isPaused = false;
            this.mTimePassed = new TimeSpan(0);
        }

        /// <summary>
        /// Gets the elapsed time for GameClock.
        /// </summary>
        public TimeSpan ElapsedTime
        {
            get
            {
                return this.mTimePassed;
            }
        }

        /// <summary>
        /// Updates the GameClock called every frame.
        /// </summary>
        /// <param name="gameTime">game time.</param>
        public void Update(GameTime gameTime)
        {
            if (!this.isPaused)
            {
                this.mTimePassed += gameTime.ElapsedGameTime;
            }
        }

        /// <summary>
        /// Starts the GameClock if it is paused.
        /// </summary>
        public void Start()
        {
            this.isPaused = false;
        }

        /// <summary>
        /// Pauses clock if it has started.
        /// </summary>
        public void Pause()
        {
            this.isPaused = true;
        }

        /// <summary>
        /// Resets the clock time. Note: The clock stays in its current state.
        /// </summary>
        public void Reset()
        {
            this.mTimePassed = new TimeSpan(0);
        }
    }
}
