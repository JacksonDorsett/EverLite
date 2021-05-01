namespace EverLite.Models.Enemies
{
    using System;
    using System.Collections.Generic;

    public class WaveQueue
    {
        private SortedList<double, Wave> q;
        private GameClock gameClock;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveQueue"/> class.
        /// </summary>
        /// <param name="clock">game clock handling time passed.</param>
        public WaveQueue(GameClock clock)
        {
            q = new SortedList<double, Wave>();
            gameClock = clock; // could be refactored into Wave Queue.
        }

        /// <summary>
        /// Gets a value indicating whether the queue is ready to be popped.
        /// </summary>
        public bool IsReady
        {
            get
            {
                if (q.Count != 0 && gameClock.ElapsedTime.TotalSeconds >= q.Values[0].StartTime)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the number of queued waves.
        /// </summary>
        public int Count { get => q.Count; }

        /// <summary>
        /// Precondition: time passed must exceed head wave.
        /// </summary>
        /// <returns>returns the next active wave.</returns>
        public Wave PopWave()
        {
            if (q.Count == 0) throw new Exception("Cannot pop from queue since there are no entries");
            if (!IsReady) throw new Exception("Wave cannot be poped yet. Please use IsReady Property to verify before calling PopWave()");

            var wave = q.Values[0];
            q.RemoveAt(0);
            return wave;
        }

        /// <summary>
        /// Adds wave to the priority Queue.
        /// </summary>
        /// <param name="wave">wave to be added.</param>
        public void Add(Wave wave)
        {
            while (q.ContainsKey(wave.StartTime))
            {
                wave.StartTime += 0.0001d;
            }
            q.Add(wave.StartTime, wave);
        }
    }
}
