namespace EverLite
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ScrollingStarsBackgroundComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {        
        private static readonly int SPEED = 250;
        private EverLite game;
        private Rectangle r1;
        private Rectangle r2;
        private Texture2D texture;
        private Texture2D sidePanel;
        private ScrollState currentState;

        private enum ScrollState
        {
            Stop,
            Start,
        }

        public ScrollingStarsBackgroundComponent(EverLite game)
            : base(game)
        {
            this.game = game;
            this.texture = this.game.Content.Load<Texture2D>(@"Sprites\background_stars");
            this.sidePanel = this.game.Content.Load<Texture2D>(@"Sprites\background_narrowspace");
            this.r1 = this.texture.Bounds;
            this.r2 = this.r1;
            this.r1.Y = -this.r1.Height;
            this.currentState = ScrollState.Start;
        }

        public override void Initialize()
        {
        }

        protected override void LoadContent()
        {
            //this.stars = this.game.Content.Load<Texture2D>(@"Sprites\background_stars");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.currentState == ScrollState.Start)
            {
                if (this.r1.Top > this.r1.Height)
                {
                    this.r1.Y = this.r2.Top - this.r1.Height;
                }

                if (this.r2.Top > this.r1.Height)
                {
                    this.r2.Y = this.r1.Top - this.r1.Height;
                }

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

        private Rectangle GetWindowSize()
        {
            Rectangle r = this.game.Window.ClientBounds;
            r.X = 0;
            r.Y = 0;
            return r;
        }

        public override void Draw(GameTime gameTime)
        {
            this.game.spriteBatch.Begin();

            // Draws the scrolling stars background.
            this.game.spriteBatch.Draw(this.texture, r1, Color.White);
            this.game.spriteBatch.Draw(this.texture, r2, Color.White);

            // Draws the planet side panel background.
            this.game.spriteBatch.Draw(this.sidePanel, new Vector2(0,0), Color.White * 0.8f);
            this.game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
