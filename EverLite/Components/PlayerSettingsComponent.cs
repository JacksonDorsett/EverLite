namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Manages the player setting logic for the PlayerSettingsScene.
    /// </summary>
    public class PlayerSettingsComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerSettingsComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public PlayerSettingsComponent(EverLite game) 
            : base(game)
        {
            this.game = game;
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();


            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
