namespace EverLite.Modules.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Class that represents a batch of enemies.
    /// </summary>
    internal class EnemyBatch
    {
        /// <summary>
        /// Content manager ref.
        /// </summary>
        public ContentManager ContentManagerRef;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyBatch"/> class.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        public EnemyBatch(ContentManager contentManager)
        {
            this.ContentManagerRef = contentManager;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyBatch"/> class with the initial capacity.
        /// </summary>
        /// <param name="number"> initial list capacity.</param>
        /// <param name="contentManager"> content manager ref.</param>
        public EnemyBatch(ContentManager contentManager, int number)
        {
            this.ContentManagerRef = contentManager;
            this.EnemiesList = new List<Enemy>(number) { };
        }

        /// <summary>
        /// Gets or sets list of enemies.
        /// </summary>
        public List<Enemy> EnemiesList { get; set; } = new List<Enemy>() { };

        /// <summary>
        /// Creates a certain number of the same type of enemies.
        /// </summary>
        /// <param name="enemyType"> type of enemies to create.</param>
        /// <param name="number"> number of enemies to create.</param>
        public virtual void CreateEnemies(string enemyType, int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("number of enemies must be positive!");
            }

            while (number > 0)
            {
                this.CreateEnemy(enemyType, new Vector2(0, 0));
                number--;
            }
        }

        /// <summary>
        /// Creates a certain number of random type of enemies.
        /// </summary>
        /// <param name="number"> number of enemies to create.</param>
        public virtual void CreateEnemiesRandom(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("number of enemies must be positive!");
            }

            string[] enemyTypes = new string[] { "regular", "regular-alt" };
            Random rnd = new Random();

            while (number > 0)
            {
                string enemyType = enemyTypes[rnd.Next(enemyTypes.Length)];
                this.CreateEnemy(enemyType, new Vector2(0, 0));
                number--;
            }
        }

        /// <summary>
        /// Creates an enemy of a given type.
        /// </summary>
        /// <param name="enemyType"> type of an enemy to create.</param>
        /// <param name="newPosition"> new positon.</param>
        /// <returns> enemy created.</returns>
        public virtual Enemy CreateEnemy(string enemyType, Vector2 newPosition)
        {
            Enemy enemy = EnemyFactory.CreateEnemy(enemyType, this.ContentManagerRef, newPosition);
            this.EnemiesList.Add(enemy);
            return enemy;
        }

        /// <summary>
        /// Updates all enemies in the list.
        /// </summary>
        /// <param name="graphics"> graphics device.</param>
        /// <param name="gameTime"> gametime.</param>
        public void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            List<Enemy> enemiesToDelete = new List<Enemy>() { };
            foreach (Enemy enemy in this.EnemiesList)
            {
                if (!enemy.IsVisible)
                {
                    enemiesToDelete.Add(enemy);
                }
                else
                {
                    enemy.Update(graphics, gameTime);
                }
            }

            if (enemiesToDelete.Count > 0)
            {
                this.EnemiesList = this.EnemiesList.Except(enemiesToDelete).ToList();
            }
        }

        /// <summary>
        /// Draws all enemies in the list.
        /// </summary>
        /// <param name="sprite"> sprite batch.</param>
        public void Draw(SpriteBatch sprite)
        {
            foreach (Enemy enemy in this.EnemiesList)
            {
                enemy.Draw(sprite);
            }
        }
    }
}
