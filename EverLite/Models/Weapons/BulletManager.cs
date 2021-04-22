namespace EverLite
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

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
            this.mPlayerBullets.Add(b);
        }

        /// <summary>
        /// Gets the list of Enemy bullets.
        /// </summary>
        public List<Bullet> EnemyBullets { get => this.mEnemyBullets; }

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

            for (int i = this.mPlayerBullets.Count - 1; i >= 0; --i)
            {
                Bullet l = this.mPlayerBullets[i];
                if (!l.IsAlive) this.mPlayerBullets.Remove(l);
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
            foreach (var b in this.mPlayerBullets)
            {
                b.Draw(spriteBatch);
            }

            foreach (var b in this.EnemyBullets)
            {
                b.Draw(spriteBatch);
            }
        }

        public void Clear()
        {
            this.mEnemyBullets.Clear();
            this.mPlayerBullets.Clear();
        }
    }
}
