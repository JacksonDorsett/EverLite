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

    class BulletManager
    {
        private static BulletManager mInstance;
        private List<Bullet> mEnemyBullets;
        private List<Bullet> PlayerBullets;

        private BulletManager()
        {
            this.mEnemyBullets = new List<Bullet>();
            this.PlayerBullets = new List<Bullet>();
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

        public void AddPlayerBullet(Bullet b)
        {
            this.PlayerBullets.Add(b);
        }

        public List<Bullet> EnemyBullets{ get => this.mEnemyBullets; }
        public void Update(GameTime gameTime)
        {
            foreach (var b in PlayerBullets)
            {
                b.Update(gameTime);
            }

            for (int i = this.PlayerBullets.Count - 1; i >= 0; --i)
            {
                Bullet l = this.PlayerBullets[i];
                if (!l.IsAlive) this.PlayerBullets.Remove(l);
            }

            foreach (var b in EnemyBullets)
            {
                b.Update(gameTime);
            }

            for (int i = this.EnemyBullets.Count - 1; i >= 0; --i)
            {
                Bullet l = this.EnemyBullets[i];
                if (!l.IsAlive) this.EnemyBullets.Remove(l);
            }
        }

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
