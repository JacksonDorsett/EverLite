// <copyright file="Wave.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Wave
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Enemies;
    using Microsoft.Xna.Framework;


    /// <summary>
    /// Represents a wave
    /// </summary>
    public class Wave : IComparable
    {
        private float spawnInterval;
        private int spawnCount;
        private EnemyFactory spawner;
        private float timeElapsed;

        public Wave(EnemyFactory spawner, float spawnInterval, int spawnCount, float startTime)
        {
            this.spawnInterval = spawnInterval;
            this.spawnCount = spawnCount;
            this.spawner = spawner;
            this.StartTime = startTime;
            this.timeElapsed = 0;
        }

        public float StartTime { get; private set; }

        public int CompareTo(object obj)
        {
            if ((obj as Wave).StartTime == this.StartTime) return 0;
            if ((obj as Wave).StartTime > this.StartTime) return -1;
            return 1;
        }

        public void Update(GameTime gameTime)
        {
            if () this.spawner.Spawn();
        }
    }
}