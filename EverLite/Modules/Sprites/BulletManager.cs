// <copyright file="BulletManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using EverLite.Modules.Blaster;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The manager for the bullets.
    /// </summary>
    internal class BulletManager
    {
        private static BulletManager mInstance;
        private List<Bullet> mEnemyBullets;
        private List<Bullet> mPlayerBullets;

        private BulletManager()
        {
            this.mEnemyBullets = new List<Bullet>();
            this.mPlayerBullets = new List<Bullet>();
            mInstance = this;
        }

        public static BulletManager Instance
        {
            get
            {
                if (mInstance == null) mInstance = new BulletManager();
                return mInstance;
            }
        }

        /// <summary>
        /// Add player bullet to list.
        /// </summary>
        /// <param name="b">bullet to be added.</param>
        public void AddPlayerBullet(Bullet b)
        {
            this.PlayerBullets.Add(b);
        }

        /// <summary>
        /// Gets the list of Enemy bullets.
        /// </summary>
        public List<Bullet> EnemyBullets{ get => this.mEnemyBullets; }

        public List<Bullet> PlayerBullets { get => this.mPlayerBullets; }

        /// <summary>
        /// Updates the bullet logic.
        /// </summary>
        /// <param name="gameTime">game time elapsed.</param>
        public void Update(GameTime gameTime)
        {
            foreach (var b in this.PlayerBullets)
            {
                b.Update(gameTime);
            }

            for (int i = this.PlayerBullets.Count - 1; i >= 0; --i)
            {
                Bullet l = this.PlayerBullets[i];
                if (!l.IsAlive) this.PlayerBullets.Remove(l);
            }

            foreach (var b in this.EnemyBullets)
            {
                b.Update(gameTime);
            }

            for (int i = this.EnemyBullets.Count - 1; i >= 0; --i)
            {
                Bullet l = this.EnemyBullets[i];
                if (!l.IsAlive) this.EnemyBullets.Remove(l);
            }
        }

        /// <summary>
        /// Draws the bullets to the screen.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch for drawing.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var b in this.PlayerBullets)
            {
                b.Draw(spriteBatch);
            }

            foreach (var b in this.EnemyBullets)
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
