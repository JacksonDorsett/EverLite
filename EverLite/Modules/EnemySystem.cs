// <copyright file="EnemySystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using EverLite.Modules.Blaster;
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
        private Game mGame;
        private List<EnemyBatch> enemyBatches = new List<EnemyBatch>() { };

        /// <summary>
        /// current boss fighting.
        /// </summary>
        private Enemy midBoss;
        private Enemy finalBoss;

        private int lastEnemyType = 0;

        private Player mPlayer;
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
                        this.bullets.Add(bullet);
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

            // Check for the first stage
            if (enemiesCount == 0 && this.FirstStage(gameTime.TotalGameTime))
            {
                string[] enemyTypes = new string[] { "regular", "regular-alt" };
                Random rand = new Random();
                // Spawn early mobs
                Vector2 velocity = new Vector2(-2.5F, 0);
                EnemyBatchVFormation enemyBatch = new EnemyBatchVFormation(this.mGame.Content, graphics, enemyTypes[this.lastEnemyType], 9, this.mPlayer);
                this.lastEnemyType = this.lastEnemyType == 0 ? 1 : 0;
                this.enemyBatches.Add(enemyBatch);
            }

            // We are in the mid boss fight
            if (this.MidBossStage(gameTime.TotalGameTime))
            {
                this.LeaveMap();


                if (this.midBoss == null)
                {
                    Vector2 enterTarget = new Vector2((float)(graphics.Viewport.Width * 0.4), (float)(graphics.Viewport.Height * 0.25));
                    this.midBoss = EnemyFactory.CreateEnemy("mid-boss", this.mGame.Content, new Vector2((float)(graphics.Viewport.Width * 0.4), (float)(0 - (graphics.Viewport.Height * 0.1))), new EnemyBlaster(this.mPlayer, this.mGame.Content.Load<Texture2D>("TinyRed")));
                    this.midBoss.ChangeTarget(enterTarget);
                }
            }

            // We are in the mid boss fight
            else if (this.FinalBossStage(gameTime.TotalGameTime))
            {
                if (this.finalBoss == null)
                {
                    // Make midboss leave
                    this.midBoss.LeaveMap();
                    this.DeleteEnemyAfterTime(this.midBoss, new TimeSpan(0, 0, 3));

                    Vector2 enterTarget = new Vector2((float)(graphics.Viewport.Width * 0.4), (float)(graphics.Viewport.Height * 0.25));
                    this.finalBoss = EnemyFactory.CreateEnemy("final-boss", this.mGame.Content, new Vector2((float)(graphics.Viewport.Width * 0.4), (float)(0 - (graphics.Viewport.Height * 0.1))), new EnemyBlaster(this.mPlayer, this.mGame.Content.Load<Texture2D>("TinyRed")));
                    this.finalBoss.ChangeTarget(enterTarget);
                }
            }

            if (this.midBoss != null)
            {
                this.midBoss.Update(graphics, gameTime);
                var bullet = this.midBoss.Shoot();
                if (bullet != null)
                {
                    this.bullets.Add(bullet);
                }
            }

            if (this.finalBoss != null)
            {
                this.finalBoss.Update(graphics, gameTime);
                var bullet = this.finalBoss.Shoot();
                if (bullet != null)
                {
                    this.bullets.Add(bullet);
                }
            }
        }

        /// <summary>
        /// Deletes enemy after certain amount of time.
        /// </summary>
        /// <param name="enemy">enemy to delete.</param>
        /// <param name="time">time after.</param>
        public void DeleteEnemyAfterTime(Enemy enemy, TimeSpan time)
        {
            Timer timer = new Timer(time.TotalMilliseconds);
            timer.AutoReset = false;
            timer.Elapsed += (a, e) => this.DeleteEnemyOrBoss(enemy);
            timer.Start();
        }

        /// <summary>
        /// Deletes an enemy or boss
        /// </summary>
        /// <param name="enemy">enemy to delete.</param>
        public void DeleteEnemyOrBoss(Enemy enemy)
        {
            if (enemy == this.midBoss)
            {
                this.midBoss = null;
            }
            else if (enemy == this.finalBoss)
            {
                this.finalBoss = null;
            }
            else
            {
                foreach (EnemyBatch enemyBatch in this.enemyBatches)
                {
                    enemyBatch.EnemiesList.Remove(enemy);
                }
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

            if (this.midBoss != null)
            {
                this.midBoss.Draw(sprite);
            }

            if (this.finalBoss != null)
            {
                this.finalBoss.Draw(sprite);
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
        /// Tells regular enemies to exit the map.
        /// </summary>
        public void LeaveMap()
        {
            foreach (EnemyBatch enemyBatch in this.enemyBatches)
            {
                enemyBatch.LeaveMap();
            }
        }

        /// <summary>
        /// Check if we are in the first stage.
        /// </summary>
        /// <param name="gameTime"> current total gametime.</param>
        /// <returns>boolean.</returns>
        public bool FirstStage(TimeSpan gameTime)
        {
            return gameTime.TotalSeconds < 46;
        }

        /// <summary>
        /// Check if we are in mid boss stage.
        /// </summary>
        /// <param name="gameTime"> current total gametime.</param>
        /// <returns>boolean.</returns>
        public bool MidBossStage(TimeSpan gameTime)
        {
            if (this.FirstStage(gameTime))
            {
                return false;
            }
            else if (gameTime.TotalSeconds < 75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if we are in mid boss stage.
        /// </summary>
        /// <param name="gameTime"> current total gametime.</param>
        /// <returns>boolean.</returns>
        public bool FinalBossStage(TimeSpan gameTime)
        {
            if (this.FirstStage(gameTime) || this.MidBossStage(gameTime))
            {
                return false;
            }
            else if (gameTime.TotalSeconds > 92)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
