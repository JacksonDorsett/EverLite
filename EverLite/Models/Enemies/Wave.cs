﻿namespace EverLite
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
        private List<LifetimeEntity> enemyList;
        private List<LifetimeEntity> spawners;
        private BulletSpawner bulletSpawner;

        public Wave(EnemyFactory spawner, double spawnInterval, int spawnCount, double startTime)
        {
            this.spawnInterval = spawnInterval;
            this.spawnCount = spawnCount;
            this.spawner = spawner;
            this.StartTime = startTime;
            this.timeElapsed = 0;
            this.totalSpawned = 0;
        }

        public double StartTime { get; internal set; }

        public bool IsWaveActive { get => this.spawnCount > this.totalSpawned; }

        public int CompareTo(object obj)
        {
            if ((obj as Wave).StartTime == this.StartTime) return 0;
            if ((obj as Wave).StartTime > this.StartTime) return -1;
            return 1;
        }

        public void Update(GameTime gameTime)
        {
            if (!this.IsWaveActive) return;

            // update clock
            this.timeElapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (this.timeElapsed >= this.spawnInterval)
            {
                this.spawner.Spawn();
                this.totalSpawned++;
                this.timeElapsed -= this.spawnInterval;
            }
        }
    }
}