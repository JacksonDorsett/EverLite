// <copyright file="Wave.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Wave
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Represents a wave.
    /// </summary>
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
            if (this.IsWaveActive)
            {
                // update clock
                this.timeElapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (this.timeElapsed >= this.spawnInterval)
                {
                    spawner.Spawn();
                    this.totalSpawned++;
                    this.timeElapsed -= this.spawnInterval;

                }
            }
        }
    }
}