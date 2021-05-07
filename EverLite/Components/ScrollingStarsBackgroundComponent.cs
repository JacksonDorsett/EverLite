namespace EverLite
{
    using global::EverLite.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Manages the background for the GameScenesk.
    /// </summary>
    public class ScrollingStarsBackgroundComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {        
        private static readonly int SPEED = 250;
        private EverLite game;
        private Rectangle r1;
        private Rectangle r2;
        private Texture2D texture;
        private ScrollState currentState;
        TransformManager transformManager;

        /// <summary>
        /// Enum to cycle through scroll state.
        /// </summary>
        private enum ScrollState
        {
            Stop,
            Start,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollingStarsBackgroundComponent"/> class.
        /// </summary>
        /// <param name="game">game reference object.</param>
        public ScrollingStarsBackgroundComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.texture = this.game.Content.Load<Texture2D>(@"Sprites\background_stars");
            this.r1 = this.texture.Bounds;
            this.r2 = this.r1;
            this.r1.Y = -this.r1.Height;
            this.currentState = ScrollState.Start;
            this.transformManager = TransformManager.Instance;
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            if (this.currentState == ScrollState.Start)
            {
                if (this.r1.Top > this.r1.Height)
                    this.r1.Y = this.r2.Top - this.r1.Height;

                if (this.r2.Top > this.r1.Height)
                    this.r2.Y = this.r1.Top - this.r1.Height;

                this.r1.Y += (int)(SPEED * gameTime.ElapsedGameTime.TotalSeconds);
                this.r2.Y += (int)(SPEED * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// Starts the scrolling.
        /// </summary>
        public void Start()
        {
            this.currentState = ScrollState.Start;
        }

        /// <summary>
        /// Stops scrolling.
        /// </summary>
        public void Stop()
        {
            this.currentState = ScrollState.Stop;
        }

        /// <summary>
        /// Gets the window size.
        /// </summary>
        /// <returns>Window size parameters in triangle.</returns>
        private Rectangle GetWindowSize()
        {
            Rectangle r = this.game.Window.ClientBounds;
            r.X = 0;
            r.Y = 0;
            return r;
        }

        /// <inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            this.game.spriteBatch.Draw(this.texture, Vector2.Transform(new Vector2(r1.X + r1.Width/2, r1.Y + r1.Height/2), transformManager.Transform), null, Color.White, this.transformManager.Angle, new Vector2(r1.Width/2,r1.Height/2),1.3f,SpriteEffects.None,.3f);
            this.game.spriteBatch.Draw(this.texture, Vector2.Transform(new Vector2(r2.X + r2.Width / 2, r2.Y + r2.Height / 2), transformManager.Transform), null, Color.White, this.transformManager.Angle, new Vector2(r2.Width / 2, r2.Height / 2), 1.3f, SpriteEffects.None, .3f);
            //this.game.spriteBatch.Draw(this.texture, Vector2.Transform(new Vector2(r2.X + r2.Width/2, r2.Y + r2.Height/2), transformManager.Transform), Color.White);
            // Draws the scrolling stars background.
            //this.game.spriteBatch.Draw(this.texture, r1, Color.White);
            //this.game.spriteBatch.Draw(this.texture, r2, Color.White);

            this.game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
