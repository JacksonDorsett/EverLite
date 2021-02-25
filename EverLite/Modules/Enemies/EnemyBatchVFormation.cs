// <copyright file="EnemyBatchVFormation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Enemies
{
    using System;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// V shape formation batch class.
    /// </summary>
    internal class EnemyBatchVFormation : EnemyBatch
    {
        /// <summary>
        /// Velocity of enemies.
        /// </summary>
        public Vector2 Velocity = new Vector2(0, 2F);

        /// <summary>
        /// Reference to the graphics device.
        /// </summary>
        private Game game;

        /// <summary>
        /// Precent of distance between enemies.
        /// </summary>
        public double DistancePrecent = 0.1;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyBatchVFormation"/> class with the initial capacity.
        /// </summary>
        /// <param name="contentManager"> content manager ref.</param>
        /// <param name="graphicsDevice"> references to the graphics device.</param>
        /// <param name="enemyType"> enemy type.</param>
        /// <param name="number"> initial list capacity.</param>
        public EnemyBatchVFormation(Game game, string enemyType, int number, Player player)
            : base(game, number, player)
        {
            this.game = game;
            this.CreateEnemies(enemyType, number);
        }

        /// <summary>
        /// Creates a certain number of the same type of enemies in formation.
        /// </summary>
        /// <param name="enemyType"> type of enemies to create.</param>
        /// <param name="number"> number of enemies to create.</param>
        public override void CreateEnemies(string enemyType, int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("number of enemies must be positive!");
            }

            while (number > 0)
            {
                Enemy enemy = this.CreateEnemy(enemyType, new Vector2(0, 0), this.mPlayer);
                enemy.ChangeVelocity(this.Velocity);
                number--;
            }

            this.FormTheFormation();
        }

        /// <summary>
        /// Creates a certain number of the same type of enemies in formation with velocity.
        /// </summary>
        /// <param name="enemyType"> type of enemies to create.</param>
        /// <param name="number"> number of enemies to create.</param>
        /// <param name="newVelocity"> new velocity.</param>
        public void CreateEnemies(string enemyType, int number, Vector2 newVelocity)
        {
            if (number < 1)
            {
                throw new ArgumentException("number of enemies must be positive!");
            }

            while (number > 0)
            {
                Enemy enemy = this.CreateEnemy(enemyType, new Vector2(0, 0), this.mPlayer);
                enemy.ChangeVelocity(newVelocity);
                number--;
            }

            this.Velocity = newVelocity;
            this.FormTheFormation();
        }

        /// <summary>
        /// Function that will form enemies into V shape formation.
        /// </summary>
        public void FormTheFormation()
        {
            double distancePrecent = this.DistancePrecent;
            int i = this.EnemiesList.Count;

            // Start from the top and drop down
            for (; i > 1; i -= 2)
            {
                float precentWidth = (float)(this.game.GraphicsDevice.Viewport.Width * distancePrecent);
                float precentHeight = (float)(this.game.GraphicsDevice.Viewport.Height * distancePrecent);
                Enemy enemyLeft = this.EnemiesList[i - 1];
                Enemy enemyRight = this.EnemiesList[i - 2];
                enemyLeft.ChangePosition(new Vector2(0 + precentWidth, 0 + precentHeight));
                enemyRight.ChangePosition(new Vector2(this.game.GraphicsDevice.Viewport.Width - precentWidth, 0 + precentHeight));

                distancePrecent += 0.1;
            }

            // Check if we have even or not number of enemies
            if (this.EnemiesList.Count % 2 != 0)
            {
                float precentWidth = (float)(this.game.GraphicsDevice.Viewport.Width * distancePrecent);
                float precentHeight = (float)(this.game.GraphicsDevice.Viewport.Height * distancePrecent);
                Enemy enemy = this.EnemiesList[i - 1];
                enemy.ChangePosition(new Vector2(this.game.GraphicsDevice.Viewport.Width / 2, 0 + precentHeight));
            }
        }

        /// <summary>
        /// Set velocity for the formation. Y will always be 0.
        /// </summary>
        /// <param name="newVelocity"> new velocity, only X counts.</param>
        public void SetVelocity(Vector2 newVelocity)
        {
            foreach (Enemy enemy in this.EnemiesList)
            {
                enemy.ChangeVelocity(new Vector2(newVelocity.X, 0));
            }
        }

        /// <summary>
        /// Makes enemies leave the map.
        /// </summary>
        public override void LeaveMap()
        {
            int i = this.EnemiesList.Count;

            // Start from the top and drop down
            for (; i > 1; i -= 2)
            {
                Enemy enemyLeft = this.EnemiesList[i - 1];
                Enemy enemyRight = this.EnemiesList[i - 2];
                enemyLeft.ChangeVelocity(new Vector2(-8, 0));
                enemyRight.ChangeVelocity(new Vector2(8, 0));
            }

            // Check if we have even or not number of enemies
            if (this.EnemiesList.Count % 2 != 0)
            {
                Enemy enemy = this.EnemiesList[i - 1];
                enemy.ChangeVelocity(new Vector2(0, -11));
            }
        }
    }
}
