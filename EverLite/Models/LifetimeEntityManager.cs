namespace EverLite
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class LifetimeEntityManager
    {
        private List<LifetimeEntity> entities;

        public LifetimeEntityManager()
        {
            this.entities = new List<LifetimeEntity>();
        }

        public List<LifetimeEntity> EntityList { get => this.entities; }

        public void Update(GameTime gameTime)
        {
            for (int i = this.entities.Count - 1; i >= 0; i--)
            {
                LifetimeEntity e = this.entities[i];
                e.Update(gameTime);
                if (!e.IsAlive)
                {
                    this.entities.Remove(e);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var e in this.entities)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}
