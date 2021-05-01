namespace EverLite.Models.Enemies
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Wave : IComparable
    {
        private double spawnInterval;
        private int spawnCount;
        private int totalSpawned;
        private EnemyFactory spawner;
        private double timeElapsed;


        public Wave(EnemyFactory spawner, double spawnInterval, int spawnCount, double startTime)
        {
            this.spawnInterval = spawnInterval;
            this.spawnCount = spawnCount;
            this.spawner = spawner;
            StartTime = startTime;
            timeElapsed = 0;
            totalSpawned = 0;
        }

        public double StartTime { get; internal set; }

        public bool IsWaveActive { get => spawnCount > totalSpawned; }

        public int CompareTo(object obj)
        {
            if ((obj as Wave).StartTime == StartTime) return 0;
            if ((obj as Wave).StartTime > StartTime) return -1;
            return 1;
        }

        public void Update(GameTime gameTime)
        {
            if (!IsWaveActive) return;

            // update clock
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed >= spawnInterval)
            {
                spawner.Spawn();
                totalSpawned++;
                timeElapsed -= spawnInterval;
            }
        }
    }
}
