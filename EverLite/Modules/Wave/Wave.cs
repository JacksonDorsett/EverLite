// <copyright file="Wave.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Wave
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using EverLite.Modules.Enemies;
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
        private List<Enemy> enemyList;

        public Wave(List<Enemy> enemies, EnemyFactory spawner, double spawnInterval, int spawnCount, double startTime)
        {
            this.spawnInterval = spawnInterval;
            this.spawnCount = spawnCount;
            this.spawner = spawner;
            this.StartTime = startTime;
            this.timeElapsed = 0;
            this.totalSpawned = 0;
            this.enemyList = enemies;
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
                if (this.totalSpawned < this.spawnCount && this.timeElapsed >= this.spawnInterval)
                {
                    this.enemyList.Add(this.spawner.Spawn());
                    this.totalSpawned++;
                    this.timeElapsed -= this.spawnInterval;

                }
            }
        }
    }
}