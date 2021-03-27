// <copyright file="CollisionSystem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Enemies;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    /// <summary>
    /// Class that will monitor and check if object have collided.
    /// </summary>
    internal class CollisionDetector
    {
        /// <summary>
        /// List of all active enemies that were passed.
        /// </summary>
        private List<Enemy> activeEnemies;

        /// <summary>
        /// List of all enemy bullets.
        /// </summary>
        private List<EnemyBlaster> enemyBullets;

        /// <summary>
        /// List of all player bullets.
        /// </summary>
        private List<PlayerBlaster> playerBullets;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionDetector"/> class.
        /// </summary>
        /// <param name="activeEnemies"> reference to list of all active enemies.</param>
        /// <param name="enemyBullets">reference to enemy bullets.</param>
        /// <param name="playerBullets">reference to player bullet.</param>
        /// <param name="player">reference to a current player.</param>
        public CollisionDetector(List<Enemy> activeEnemies, List<EnemyBlaster> enemyBullets, List<PlayerBlaster> playerBullets)
        {
            this.activeEnemies = activeEnemies;
            this.playerBullets = playerBullets;
            this.enemyBullets = enemyBullets;
        }

        public void Update(GameTime gameTime)
        {
            foreach (EnemyBlaster blaster in this.enemyBullets)
            {
                ICollidable collidableObject = blaster;

            }
        }
    }
}
