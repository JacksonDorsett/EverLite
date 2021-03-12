// <copyright file="WaveQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Wave
{

    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Utilities;

    /// <summary>
    /// Stores the Queues to be added.
    /// </summary>
    internal class WaveQueue
    {
        private SortedList<float, Wave> q;
        private GameClock gameClock;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveQueue"/> class.
        /// </summary>
        /// <param name="clock">game clock handling time passed.</param>
        public WaveQueue(GameClock clock)
        {
            q = new SortedList<float, Wave>();
            this.gameClock = clock; // could be refactored into Wave Queue.
        }

        /// <summary>
        /// Gets a value indicating whether the queue is ready to be popped.
        /// </summary>
        public bool IsReady
        {
            get
            {
                if (q.Count == 0 || this.gameClock.ElapsedTime.TotalSeconds < q.Values[0].StartTime)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Precondition: time passed must exceed head wave.
        /// </summary>
        /// <returns>returns the next active wave.</returns>
        public Wave PopWave()
        {
            if (q.Count == 0) throw new Exception("Cannot pop from queue since there are no entries");
            if (!this.IsReady) throw new Exception("Wave cannot be poped yet. Please use IsReady Property to verify before calling PopWave()");

            var wave = this.q.Values[0];
            this.q.RemoveAt(0);
            return wave;
        }

        /// <summary>
        /// Adds wave to the priority Queue.
        /// </summary>
        /// <param name="wave">wave to be added.</param>
        public void Add(Wave wave)
        {
            this.q.Add(wave.StartTime, wave);
        }
    }
}
