namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    /// <summary>
    /// Manages the menu items logic for the MenuScene.
    /// </summary>
    public class MenuItemsComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private List<MenuItem> items;
        public MenuItem selectedItem;
        private Vector2 position;
        private Color itemColor;
        private Color selectedItemColor;
        private int textSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public MenuItemsComponent(EverLite game, Vector2 position, Color itemColor, Color selectedItemColor)
            : base(game)
        {
            this.game = game;
            this.position = position;
            this.itemColor = itemColor;
            this.selectedItemColor = selectedItemColor;
            items = new List<MenuItem>();
            selectedItem = null;
            this.textSize = 80;
        }

        /// <summary>
        /// Adds a menuItem to the list of menu choices.
        /// </summary>
        /// <param name="text">Name of the menuItem.</param>
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

        /// <summary>
        /// Cycles through the menuOptions.
        /// </summary>
        public void SelectNext()
        {
            int index = items.IndexOf(selectedItem);
            if (index < items.Count - 1)
                selectedItem = items[index + 1];
            else
                selectedItem = items[0];
        }

        /// <summary>
        /// Cycles through the menuOptions.
        /// </summary>
        public void SelectPrevious()
        {
            int index = items.IndexOf(selectedItem);
            if (index > 0)
                selectedItem = items[index - 1];
            else
                selectedItem = items[items.Count - 1];
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            // key pressing
            if (game.NewKey(Keys.Up))
                SelectPrevious();
            if (game.NewKey(Keys.Down))
                SelectNext();

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            foreach (MenuItem item in items)
            {
                Color color = itemColor;
                if (item == selectedItem)
                    color = selectedItemColor;
                this.game.spriteBatch.DrawString(this.game.SceneManager.FontOriginTech, item.text, item.position, color);
            }
            game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
