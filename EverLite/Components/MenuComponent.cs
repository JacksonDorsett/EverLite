namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private Texture2D background;
        private MenuItemsComponent menuItems;

        public MenuComponent(EverLite game, MenuItemsComponent menuItems)
            : base(game)
        {
            this.game = game;
            this.menuItems = menuItems;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>(@"Sprites\space");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (game.NewKey(Keys.Enter))
            {
                switch (this.menuItems.selectedItem.text)
                {
                    case "Play":
                        this.game.ChangeMusic(this.game.DeepSpace);
                        //this.game.SwitchScene(this.game.LevelScene);
                        this.game.SceneManager.SwitchScene(game.SceneManager.NewGame);
                        break;
                    case "Top Scores":
                        this.game.ChangeMusic(this.game.SolarSystem);
                        //this.game.SwitchScene(this.game.TopTenScene);
                        this.game.SceneManager.SwitchScene(game.SceneManager.TopTen);
                        break;
                    case "Quit":
                        this.game.Exit();
                        break;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
