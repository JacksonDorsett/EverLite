namespace EverLite.Models.Items
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class ItemsManager
    {
        private List<Item> items = new List<Item>() { };
        private static ItemsManager instance;

        public static ItemsManager Instance
        {
            get
            {
                if (instance == null) instance = new ItemsManager();
                return instance;
            }
            
        }

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Add(Item item)
        {
            this.items.Add(item);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Item item in this.items)
            {
                if (item.IsAlive)
                {
                    item.Draw(spriteBatch);
                }
            }

            this.items.RemoveAll(s => !s.IsAlive);
        }

        public void Update(GameTime gameTime)
        {
            foreach(Item item in this.items)
            {
                if (item.IsAlive)
                {
                    item.Update(gameTime);
                }
            }

            this.items.RemoveAll(s => !s.IsAlive);
        }
    }
}
