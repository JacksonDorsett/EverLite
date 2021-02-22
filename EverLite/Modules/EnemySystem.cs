// <copyright file="EnemySystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using System;
    using System.Collections.Generic;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Enemy system class that handles enemies.
    /// </summary>
    internal class EnemySystem
    {
        private Player mPlayer;
        private Game mGame;
        private List<EnemyBatch> enemyBatches = new List<EnemyBatch>() { };
        private List<Sprite> bullets;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemySystem"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public EnemySystem(Game game, Player player)
        {
            this.mGame = game;
            this.mPlayer = player;
            bullets = new List<Sprite>();
        }

        /// <summary>
        /// Updates all enemy batches in the list.
        /// </summary>
        /// <param name="gameTime"> game time.</param>
        public void Update(GameTime gameTime)
        {
            GraphicsDevice graphics = this.mGame.GraphicsDevice;
            int enemiesCount = 0;
            foreach (EnemyBatch enemyBatch in this.enemyBatches)
            {
                foreach (Enemy e in enemyBatch.EnemiesList)
                {
                    var bullet = e.Shoot();
                    if (bullet != null)
                    {
                        bullets.Add(bullet);
                    }
                }

                enemyBatch.Update(graphics, gameTime);
                enemiesCount += enemyBatch.EnemiesList.Count;
            }

            foreach (Sprite s in this.bullets)
            {
                s.Update(gameTime);
            }

            Vector2 testVec = new Vector2(graphics.Viewport.Width / 2, (float)(graphics.Viewport.Height * 0.7));

            // TODO: for debug only, remove!
            if (enemiesCount == 0)
            {
                EnemyBatch enemyBatch = new EnemyBatch(this.mGame.Content, 1, this.mPlayer);
                Enemy enemy = enemyBatch.CreateEnemy("regular", testVec, this.mPlayer);
                this.enemyBatches.Add(enemyBatch);
            }

            // TODO: add event system.
            // Check for the first stage
            if (enemiesCount <= 1 && this.FirstStage(gameTime.TotalGameTime))
            {
                // Spawn early mobs
                Vector2 velocity = new Vector2(-2.5F, 0);
                EnemyBatchVFormation enemyBatch = new EnemyBatchVFormation(this.mGame.Content, graphics, "regular-alt", 8, mPlayer);
                this.enemyBatches.Add(enemyBatch);
            }

            // We are in the mid boss fight
            if (this.MidBossStage(gameTime.TotalGameTime))
            {
                this.ClearAllEnemies();

                // TODO: handle mid boss spawn here.
            }
        }

        /// <summary>
        /// Draws all enemy batches in the list.
        /// </summary>
        /// <param name="sprite"> sprite batch.</param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            foreach (Sprite s in bullets)
            {
                s.Draw(sprite);
            }
            sprite.End();
            foreach (EnemyBatch enemy in this.enemyBatches)
            {
                enemy.Draw(sprite);
            }
        }

        /// <summary>
        /// Counts how namy enemies are currently on the screen.
        /// </summary>
        /// <returns> number of enemies on the screen.</returns>
        public int GetCurrentEnemyCount()
        {
            int count = 0;
            foreach (EnemyBatch enemyBatch in this.enemyBatches)
            {
                count += enemyBatch.EnemiesList.Count;
            }

            return count;
        }

        /// <summary>
        /// Clears out all enemies.
        /// </summary>
        public void ClearAllEnemies()
        {
            this.enemyBatches = new List<EnemyBatch>() { };
        }

        /// <summary>
        /// Check if we are in the first stage.
        /// </summary>
        /// <param name="gameTime"> current total gametime.</param>
        /// <returns>boolean.</returns>
        public bool FirstStage(TimeSpan gameTime)
        {
            if (gameTime.TotalMinutes >= 1)
            {
                return false;
            }
            else
            {
                return gameTime.TotalSeconds < 48;
            }
        }

        /// <summary>
        /// Check if we are in mid boss stage.
        /// </summary>
        /// <param name="gameTime"> current total gametime.</param>
        /// <returns>boolean.</returns>
        public bool MidBossStage(TimeSpan gameTime)
        {
            if (gameTime.TotalMinutes > 1)
            {
                return false;
            }
            else if (gameTime.TotalMinutes == 1)
            {
                return gameTime.TotalSeconds < 15;
            }
            else
            {
                return false;
            }
        }
    }
}
