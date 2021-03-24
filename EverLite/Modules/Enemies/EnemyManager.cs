// <copyright file="EnemyManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the enemies that are spawned and remove them when their lifespan surpassed.
    /// </summary>
    public class EnemyManager : IUpdateable
    {
        private List<Enemy> activeEnemies;
        private List<BulletSpawner> activeSpawners;
        private Game mGame;
        private WaveManager waveManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyManager"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public EnemyManager(Game game)
        {
            this.mGame = game;
            this.activeEnemies = new List<Enemy>();
            this.activeSpawners = new List<BulletSpawner>();
            this.waveManager = new WaveManager(game, this.activeEnemies, activeSpawners);

        }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => true;

        public int UpdateOrder => 1;

        public void Update(GameTime gameTime)
        {
            this.waveManager.Update(gameTime);
            for (int i = this.activeSpawners.Count - 1; i >= 0; i--)
            {
                BulletSpawner s = this.activeSpawners[i];
                s.Update(gameTime);
                if (!s.IsAlive)
                {
                    this.activeSpawners.Remove(s);
                }
            }
            for (int i = this.activeEnemies.Count - 1; i >= 0; i--)
            {
                Enemy e = this.activeEnemies[i];
                e.Update(gameTime);
                if (!e.IsAlive)
                {
                    this.activeEnemies.Remove(e);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var e in this.activeEnemies)
            {
                e.Draw(spriteBatch);
            }
            foreach (var s in activeSpawners)
            {
                s.Draw(spriteBatch);
            }
        }
    }
}
