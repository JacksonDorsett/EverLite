namespace EverLite.Modules
{
    using System.Collections.Generic;
    using EverLite.Modules.Enemies;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Enemy system class that handles enemies.
    /// </summary>
    internal class EnemySystem
    {
        /// <summary>
        /// Content manager ref.
        /// </summary>
        public ContentManager ContentManagerRef;

        public EnemySystem(ContentManager contentManager)
        {
            this.ContentManagerRef = contentManager;
        }

        /// <summary>
        /// List of enemy batches.
        /// </summary>
        public List<EnemyBatch> EnemyBatches = new List<EnemyBatch>() { };

        /// <summary>
        /// Updates all enemy batches in the list.
        /// </summary>
        /// <param name="graphics"> graphics device.</param>
        /// <param name="gameTime"> game time.</param>
        public void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            int count = 0;
            foreach (EnemyBatch enemyBatch in this.EnemyBatches)
            {
                enemyBatch.Update(graphics, gameTime);
                count += enemyBatch.EnemiesList.Count;
            }

            Vector2 testVec = new Vector2(100, graphics.Viewport.Height / 2);

            if (count == 0 && gameTime.TotalGameTime.TotalSeconds > 1)
            {
                EnemyBatch enemyBatch = new EnemyBatch(this.ContentManagerRef, 1);
                Enemy enemy = enemyBatch.CreateEnemy("regular", testVec);
                this.EnemyBatches.Add(enemyBatch);
            }

            if (count <= 1 && gameTime.TotalGameTime.TotalSeconds > 3)
            {
                // Spawn early mobs
                Vector2 velocity = new Vector2(2.5F, 0.5F);
                EnemyBatch enemyBatch = new EnemyBatch(this.ContentManagerRef, 2);
                Enemy enemy1 = enemyBatch.CreateEnemy("regular-alt", new Vector2(graphics.Viewport.Width - 50, graphics.Viewport.Height - 50));
                enemy1.ChangeTarget(testVec);
                enemy1.ChangeVelocity(velocity);

                Enemy enemy2 = enemyBatch.CreateEnemy("regular-alt", new Vector2(graphics.Viewport.Width - 50, 50));
                enemy2.ChangeTarget(testVec);
                enemy2.ChangeVelocity(velocity);
                this.EnemyBatches.Add(enemyBatch);

            }
        }

        /// <summary>
        /// Draws all enemy batches in the list.
        /// </summary>
        /// <param name="sprite"> sprite batch.</param>
        public void Draw(SpriteBatch sprite)
        {
            foreach (EnemyBatch enemy in this.EnemyBatches)
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
            foreach (EnemyBatch enemyBatch in this.EnemyBatches)
            {
                count += enemyBatch.EnemiesList.Count;
            }

            return count;
        }
    }
}
