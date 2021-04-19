﻿// <copyright file="CollisionDetector.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules
{
    using System.Collections.Generic;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using EverLite.Modules.Sprites;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Class that will monitor and check if object have collided.
    /// </summary>
    internal class CollisionDetector
    {
        /// <summary>
        /// List of all active enemies that were passed.
        /// </summary>
        private List<LifetimeEntity> activeEnemies;

        /// <summary>
        /// List of all enemy bullets.
        /// </summary>
        private List<Bullet> enemyBullets;

        /// <summary>
        /// List of all player bullets.
        /// </summary>
        private List<Bullet> playerBullets;

        private Player player;

        /// <summary>
        /// Access to the GameScore Instance.
        /// </summary>
        private Game1 scoreKeeper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionDetector"/> class.
        /// </summary>
        /// <param name="activeEnemies"> reference to list of all active enemies.</param>
        /// <param name="enemyBullets">reference to enemy bullets.</param>
        /// <param name="playerBullets">reference to player bullet.</param>
        /// <param name="player">reference to a current player.</param>
        /// <param name="score">reference to GameScore instance.</param>
        public CollisionDetector(List<LifetimeEntity> activeEnemies, List<Bullet> enemyBullets, List<Bullet> playerBullets, Player player, Game1 score)
        {
            this.activeEnemies = activeEnemies;
            this.playerBullets = playerBullets;
            this.enemyBullets = enemyBullets;
            this.player = player;
            this.scoreKeeper = score;
        }

        public void Update(GameTime gameTime)
        {
            // Check if enemy bullets collide with the player.
            foreach (Bullet bullet in this.enemyBullets)
            {
                ICollidable collidableObjectBullet = bullet;
                ICollidable collidableObjectPlayer = this.player;

                if (this.player.HitCircle.Contains(bullet.HitCircle))
                {
                    collidableObjectPlayer.CollidesWith(collidableObjectBullet);
                    collidableObjectBullet.CollidesWith(collidableObjectPlayer);
                    break;
                }
                //Rectangle bulletBox = new Rectangle((int)bullet.Position.X, (int)bullet.Position.Y, bullet.Sprite.Texture.Width, bullet.Sprite.Texture.Height);
                //Rectangle playerBox = new Rectangle(
                //    (int)this.player.Position.X + this.player.PlayerSprite.Texture.Width / 4,
                //    (int)this.player.Position.Y,
                //    this.player.PlayerSprite.Texture.Width/2,
                //    this.player.PlayerSprite.Texture.Height);

                //if (bulletBox.Intersects(playerBox))
                //{
                //    collidableObjectPlayer.CollidesWith(collidableObjectBullet);
                //    collidableObjectBullet.CollidesWith(collidableObjectPlayer);
                //    break;
                //}
            }

            // Check if player bullets collide with the player.
            foreach (Bullet bullet in this.playerBullets)
            {
                foreach (LifetimeEntity enemy in this.activeEnemies)
                {
                    ICollidable collidableObjectBullet = bullet;
                    ICollidable collidableObjectEnemy = enemy;


                    Rectangle bulletBox = new Rectangle((int)bullet.Position.X, (int)bullet.Position.Y, bullet.Sprite.Texture.Width, bullet.Sprite.Texture.Height);
                    Rectangle playerBox = new Rectangle(
                        (int)enemy.Position.X,
                        (int)enemy.Position.Y,
                        enemy.Sprite.Texture.Width,
                        enemy.Sprite.Texture.Height);

                    if (bulletBox.Intersects(playerBox))
                    {
                        collidableObjectEnemy.CollidesWith(collidableObjectBullet);
                        collidableObjectBullet.CollidesWith(collidableObjectEnemy);

                        // Currently setup to add 10 points per hit. Simplist solution that still awards more points for tougher enemies.
                        this.scoreKeeper.score.Add(10);
                    }
                }
            }

            // Check if player collide with the enemy.
            foreach (LifetimeEntity enemy in this.activeEnemies)
            {

                ICollidable collidableObjectPlayer = this.player;
                ICollidable collidableObjectEnemy = enemy;
                Rectangle enemyBox = new Rectangle(
                    (int)this.player.Position.X,
                    (int)this.player.Position.Y,
                    this.player.PlayerSprite.Texture.Width,
                    this.player.PlayerSprite.Texture.Height);

                Rectangle playerBox = new Rectangle(
                    (int)enemy.Position.X,
                    (int)enemy.Position.Y,
                    enemy.Sprite.Texture.Width,
                    enemy.Sprite.Texture.Height);

                if (enemyBox.Intersects(playerBox))
                {
                    collidableObjectEnemy.CollidesWith(collidableObjectPlayer);
                    collidableObjectPlayer.CollidesWith(collidableObjectEnemy);
                    enemy.Die();
                }
            }
        }
    }
}
