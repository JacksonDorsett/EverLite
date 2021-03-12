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


    /// <summary>
    /// Represents a wave
    /// </summary>
    public class Wave : IComparable
    {
        private float spawnInterval;
        private int spawnCount;
        private IMovement path;
        private EnemyFactory spawner;

        public Wave(EnemyFactory spawner, IMovement path, float spawnInterval, int spawnCount, float startTime)
        {
            this.spawnInterval = spawnInterval;
            this.spawnCount = spawnCount;
            this.path = path;
            this.spawner = spawner;
            this.StartTime = startTime;
        }

        public float StartTime { get; private set; }

        public int CompareTo(object obj)
        {
            if ((obj as Wave).StartTime == this.StartTime) return 0;
            if ((obj as Wave).StartTime > this.StartTime) return -1;
            return 1;
        }
    }
}