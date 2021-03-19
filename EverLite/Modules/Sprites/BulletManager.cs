// <copyright file="BulletManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Sprites
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EverLite.Modules.Behavior;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BulletManager
    {
        private static BulletManager mInstance;
        private List<LifetimeEntity> EnemyBullets;
        private List<LifetimeEntity> PlayerBullets;

        private BulletManager()
        {
            this.EnemyBullets = new List<LifetimeEntity>();
            this.PlayerBullets = new List<LifetimeEntity>();
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

        public void AddPlayerBullet(Blaster.Bullet b)
        {
            PlayerBullets.Add(b);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var b in PlayerBullets)
            {
                b.Update(gameTime);
            }

            for (int i = this.PlayerBullets.Count - 1; i >= 0; --i)
            {
                LifetimeEntity l = this.PlayerBullets[i];
                if (!l.IsAlive) this.PlayerBullets.Remove(l);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var b in this.PlayerBullets)
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
