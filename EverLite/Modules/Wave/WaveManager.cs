// <copyright file="WaveManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Wave;
    using EverLite.Utilities;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the Wave of enemies.
    /// </summary>
    public class WaveManager : GameComponent
    {
        private List<Wave> activeWaves;
        private GameClock clock;
        private WaveQueue queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveManager"/> class.
        /// </summary>
        /// <param name="game">game ref.</param>
        public WaveManager(Game game)
            : base(game)
        {
            this.clock = new GameClock();
            this.activeWaves = new List<Wave>();
            this.queue = new WaveQueue(this.clock);
        }

        /// <summary>
        /// Gets number of active waves.
        /// </summary>
        public int CountActive { get => this.activeWaves.Count; }

        /// <summary>
        /// Gets number of queued waves.
        /// </summary>
        public int CountQueued { get => this.queue.Count; }

        /// <summary>
        /// Adds wave to wave manager.
        /// </summary>
        /// <param name="wave">wave to be added.</param>
        /// <returns>returns if the wave was successully added.</returns>
        public bool AddWave(Wave wave)
        {
            if (wave.StartTime < this.clock.ElapsedTime.TotalSeconds) return false;

            this.queue.Add(wave);
            return true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.clock.Update(gameTime);
        }
    }
}
