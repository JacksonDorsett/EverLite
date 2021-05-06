namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Manages the menu logic for the MenuScene.
    /// </summary>
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private Texture2D background;
        private MenuItemsComponent menuItems;
        private VolumeManager volume;
        private SoundManager sound;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public MenuComponent(EverLite game, MenuItemsComponent menuItems)
            : base(game)
        {
            this.game = game;
            this.menuItems = menuItems;
            this.volume = VolumeManager.Instance;
            this.sound = SoundManager.Instance;
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>(@"Sprites\space");
            base.LoadContent();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            if (game.NewKey(Keys.Enter))
            {
                switch (this.menuItems.selectedItem.text)
                {
                    case "Play":
                        this.game.SceneManager.ChangeMusic(this.sound.DeepSpace);
                        this.game.SceneManager.SwitchScene(game.SceneManager.NewGame);
                        break;
                    case "Top Scores":
                        this.game.SceneManager.ChangeMusic(this.sound.MenuBG);
                        this.game.SceneManager.SwitchScene(game.SceneManager.TopTen);
                        break;
                    case "Player Settings":
                        this.game.SceneManager.ChangeMusic(this.sound.MenuBG);
                        this.game.SceneManager.SwitchScene(game.SceneManager.PlayerSettings);
                        break;
                    case "Quit":
                        this.game.Exit();
                        break;
                }
            }

            // Volume control
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
                this.volume.VolumeUp();
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
                this.volume.VolumeDown();
            if (this.game.NewKey(Keys.D0))
                this.volume.Mute();

            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            game.spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
