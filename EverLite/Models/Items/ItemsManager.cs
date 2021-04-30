namespace EverLite
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class ItemsManager
    {
        private List<Item> items = new List<Item>() { };

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Item item in this.items)
            {
                item.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Item item in this.items)
            {
                item.Update(gameTime);
            }
        }
    }
}
