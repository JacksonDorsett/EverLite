namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the background for the GameScenesk.
    /// </summary>
    public class PlanetBackgroundComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private EverLite game;
        private Texture2D planetView;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetBackgroundComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public PlanetBackgroundComponent(EverLite game)
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
        protected override void LoadContent()
        {
            this.planetView = this.game.Content.Load<Texture2D>(@"Sprites\space");

            base.LoadContent();
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            this.game.spriteBatch.Draw(this.planetView, new Vector2(0, 0), Color.White);

            this.game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
