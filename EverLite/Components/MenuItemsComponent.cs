namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    public class MenuItemsComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private List<MenuItem> items;
        public MenuItem selectedItem;
        private Vector2 position;
        private Color itemColor;
        private Color selectedItemColor;
        private int textSize;

        public MenuItemsComponent(EverLite game, Vector2 position, Color itemColor, Color selectedItemColor) : base(game)
        {
            this.game = game;
            this.position = position;
            this.itemColor = itemColor;
            this.selectedItemColor = selectedItemColor;
            items = new List<MenuItem>();
            selectedItem = null;
            this.textSize = 80;
        }

        public void AddItem(string text)
        {
            // setting up the position according to the item's collection index
            Vector2 p = new Vector2(position.X, position.Y + items.Count * textSize);
            MenuItem item = new MenuItem(text, p);
            items.Add(item);
            // selecting the first item
            if (selectedItem == null)
                selectedItem = item;
        }

        public void SelectNext()
        {
            int index = items.IndexOf(selectedItem);
            if (index < items.Count - 1)
                selectedItem = items[index + 1];
            else
                selectedItem = items[0];
        }

        public void SelectPrevious()
        {
            int index = items.IndexOf(selectedItem);
            if (index > 0)
                selectedItem = items[index - 1];
            else
                selectedItem = items[items.Count - 1];
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // key pressing
            if (game.NewKey(Keys.Up))
                SelectPrevious();
            if (game.NewKey(Keys.Down))
                SelectNext();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            foreach (MenuItem item in items)
            {
                Color color = itemColor;
                if (item == selectedItem)
                    color = selectedItemColor;
                this.game.spriteBatch.DrawString(this.game.FontOriginTech, item.text, item.position, color);
            }
            game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
