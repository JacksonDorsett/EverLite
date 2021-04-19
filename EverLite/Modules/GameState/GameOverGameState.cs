namespace EverLite.Modules.GameState
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class GameOverGameState : GameState
    {
        public GameOverGameState(Game1 game)
            : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "GAME OVER", new Vector2(this.Game.Window.ClientBounds.X / 2, this.Game.Window.ClientBounds.Y / 2), Color.Red, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "SCORE ", new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 120), Color.Yellow, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, this.Game.score.Score.ToString(), new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 180), Color.Yellow, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTech, "Top Scores", new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 2400), Color.Blue, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.DrawString(this.Game.fontOriginTechSmall, this.Game.score.TopScore.ToString(), new Vector2(this.Game.Window.ClientBounds.Width / 2, (this.Game.Window.ClientBounds.Height / 4) + 260), Color.Blue, 0, new Vector2(.5f, .5f), 1, SpriteEffects.None, 0);
            this.SpriteBatch.End();
        }

        public override void OnEnter()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void OnExit()
        {

        }
    }
}
