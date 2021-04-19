// <copyright file="WaveManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using EverLite.Modules.Wave;
    using EverLite.Utilities;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// The primary responsibility of the wave manager
    /// is to track the active waves queueing up the active waves.
    /// </summary>
    public class WaveManager
    {
        private List<Wave> activeWaves;
        private GameClock clock;
        private WaveQueue queue;
        private Game mGame;
        private List<LifetimeEntity> enemies;
        private List<LifetimeEntity> spawners;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveManager"/> class.
        /// </summary>
        /// <param name="game">game ref.</param>
        /// <param name="enemies">list of active enemies.</param>
        /// <param name="spawners">list of spawners.</param>
        public WaveManager(Game game, List<LifetimeEntity> enemies, List<LifetimeEntity> spawners)
            : base()
        {
            this.clock = new GameClock();
            this.activeWaves = new List<Wave>();
            this.queue = new WaveQueue(this.clock);
            this.enemies = enemies;
            this.spawners = spawners;
            this.mGame = game;
            this.Initialize();
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

        public void Initialize()
        {
            // Adjusted spawn locations and the curve point so that they do not spawn/shoot under the sideGamePanel.
            var linear = new LinearMovement(new Vector2(2000, 480), new Vector2(480, 800));
            var curved = new CurvedMovement(new Vector2(480, 700), new Vector2(2000, 950), new Vector2(1000, 100));

            this.AddWave(new Wave(new EnemyFactory(this.enemies, this.spawners, new BulletSpawner(curved, 4, new LinearPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), .1f, 20, 2000)), SpriteLoader.LoadSprite("enemy1"), curved, 4), 1000, 10, 0));
            this.AddWave(new Wave(new EnemyFactory(this.enemies, this.spawners, new BulletSpawner(linear, 4, new LinearPattern(BulletManager.Instance.EnemyBullets, SpriteLoader.LoadSprite("redBullet"), .1f, 20, 2000)), SpriteLoader.LoadSprite("enemy2"), linear, 4), 1000, 10, 0));
        }

        public void Update(GameTime gameTime)
        {
            this.clock.Update(gameTime);

            if (this.queue.IsReady)
            {
                this.activeWaves.Add(this.queue.PopWave());
            }

            List<Wave> deadWaves = new List<Wave>();
            foreach (Wave w in this.activeWaves)
            {
                w.Update(gameTime);
                if (!w.IsWaveActive)
                {
                    deadWaves.Add(w);
                }
            }

            // Cleanup dead waves
            foreach (var w in deadWaves)
            {
                this.activeWaves.Remove(w);
            }
        }
    }
}
