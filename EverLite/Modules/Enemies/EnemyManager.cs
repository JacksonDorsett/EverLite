// <copyright file="EnemyManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Managers;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the enemies that are spawned and remove them when their lifespan surpassed.
    /// </summary>
    public class EnemyManager : IUpdateable
    {
        private List<LifetimeEntity> activeEnemies;
        private List<LifetimeEntity> activeSpawners;
        private Game mGame;
        private WaveManager waveManager;
        private LifetimeEntityManager spawnerLifeManager;
        private LifetimeEntityManager enemyLifeManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyManager"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public EnemyManager(Game game)
        {
            this.mGame = game;
            this.spawnerLifeManager = new LifetimeEntityManager();
            this.enemyLifeManager = new LifetimeEntityManager();
            this.activeEnemies = this.enemyLifeManager.EntityList;
            this.activeSpawners = this.spawnerLifeManager.EntityList;
            this.waveManager = new WaveManager(game, this.activeEnemies, activeSpawners);

        }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => true;

        public int UpdateOrder => 1;

        public void Update(GameTime gameTime)
        {
            this.waveManager.Update(gameTime);
            this.spawnerLifeManager.Update(gameTime);
            this.enemyLifeManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.enemyLifeManager.Draw(spriteBatch);
            this.spawnerLifeManager.Draw(spriteBatch);
        }
    }
}
