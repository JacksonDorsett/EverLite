// <copyright file="EnemyManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manages the enemies that are spawned and remove them when their lifespan surpassed.
    /// </summary>
    class EnemyManager : IUpdateable
    {
        private List<Enemy> activeEnemies;
        private Game mGame;
        private WaveManager waveManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyManager"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public EnemyManager(Game game)
        {
            this.mGame = game;
            this.waveManager = new WaveManager(game, activeEnemies);
        }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => true;

        public int UpdateOrder => 1;

        public void Update(GameTime gameTime)
        {
            this.waveManager.Update(gameTime);
        }
    }
}
